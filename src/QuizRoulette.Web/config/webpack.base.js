const webpack = require('webpack');
const ExtractTextWebpackPlugin = require('extract-text-webpack-plugin');
const WebpackManifestPlugin = require('webpack-manifest-plugin');
const cors = require('cors');

const root = require('./helpers').root;
const cssExtractor = new ExtractTextWebpackPlugin({ filename: 'css/[name].css' });

const entryScript = String(process.env.npm_lifecycle_script).trim().split(' ')[0];
const publicPath = entryScript === 'webpack-dev-server'
    ? 'http://localhost:8080/'
    : '/';

module.exports = ({ }) => {
    return {
        output: {
            filename: 'js/[name].js',
            path: root('wwwroot')
        },
        resolve: {
            extensions: ['.ts', '.js']
        },
        module: {
            rules: [
                { test: /\.html$/, loader: ['html-loader'] },
                {
                    test: /\.less$/,
                    oneOf: [
                        {
                            include: root('client/quiz-roulette'),
                            loader: ['raw-loader', 'css-loader?importLoaders=1', 'less-loader']
                        },
                        {
                            loader: cssExtractor.extract(['css-loader', 'less-loader'])
                        }
                    ],
                },
                {
                    test: /\.css$/,
                    exclude: root('client/quiz-roulette'),
                    loader: cssExtractor.extract(['css-loader'])
                },
                {
                    test: /(ttf|woff|woff2|jpeg|eot|svg)$/,
                    loader: 'url-loader',
                    options: {
                        limit: 10000,
                        name: 'static/[name].[hash].[ext]'
                    }
                }
            ]
        },
        plugins: [
            cssExtractor,
            new webpack.optimize.CommonsChunkPlugin({
                names: ['common', 'vendor']
            }),
            new webpack.ProvidePlugin({
                '$': 'jquery',
                'jQuery': 'jquery',
                'jquery': 'jquery'
            }),
            new webpack.ContextReplacementPlugin(
                // The (\\|\/) piece accounts for path separators in *nix and Windows
                /angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/,
                root('client'), // location of your src
                {} // a map of your routes
            ),
            new WebpackManifestPlugin({
                writeToFileEmit: true,
                fileName: 'manifest.json',
                publicPath
            })
        ],
        stats: "minimal",
        cache: true,
        watchOptions: {
            ignored: /(node_modules|manifest\.json$)/
        },
        devServer: {
            setup(app) {
                app.use(cors());
            },
            stats: 'minimal'
        }
    };
};

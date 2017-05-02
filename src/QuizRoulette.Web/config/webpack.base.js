const webpack = require('webpack');
const ExtractTextWebpackPlugin = require('extract-text-webpack-plugin');
const WebpackManifestPlugin = require('webpack-manifest-plugin');

const root = require('./helpers').root;
const cssExtractor = new ExtractTextWebpackPlugin({ filename: 'css/[name].css' });

module.exports = ({ publicPath }) => {
    return {
        entry: {
            'vendor': root('client/vendor.ts'),
            'common': root('client/common.ts'),
            'quiz-roulette': root('client/quiz-roulette/main.ts')
        },
        output: {
            filename: 'js/[name].js',
            path: root('wwwroot')
        },
        resolve: {
            extensions: ['.ts', '.js']
        },
        module: {
            rules: [
                { test: /\.ts$/, loader: ['awesome-typescript-loader', 'angular2-template-loader'] },
                { test: /\.html$/, loader: ['html-loader'] },
                {
                    test: /\.less$/,
                    oneOf: [
                        {
                            include: root('client/quiz-roulette'),
                            loader: ['raw-loader', 'css-loader?importLoaders=1', 'less-loader']
                        },
                        {
                            // exclude: root('client/quiz-roulette'),
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
        }
    };
};

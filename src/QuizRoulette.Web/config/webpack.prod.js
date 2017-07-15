const webpackMerge = require('webpack-merge');
const webpack = require('webpack');
const { AotPlugin } = require('@ngtools/webpack');
const { root } = require('./helpers.js');

const baseConfig = require('./webpack.base.js')({});

module.exports = webpackMerge(baseConfig, {
    entry: {
        'vendor': root('client/vendor.ts'),
        'common': root('client/common.ts'),
        'quiz-roulette': root('client/quiz-roulette/main-aot.ts')
    },
    module: {
        rules: [
            { test: /\.ts$/, loader: ['@ngtools/webpack'] }
        ]
    },
    plugins: [
        new webpack.optimize.UglifyJsPlugin({
            beautify: false,
            mangle: {
                screw_ie8: true,
                keep_fnames: true
            },
            compress: false,
            compress: {
                warnings: false,
                screw_ie8: true
            },
            comments: true
        }),
        new AotPlugin({
            tsConfigPath: root('tsconfig.aot.json'),
            entryModule: root('client/quiz-roulette/quiz-roulette.module.ts#QuizRouletteModule')
        })
    ]
});

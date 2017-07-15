const webpackMerge = require('webpack-merge');
const { root } = require('./helpers');

const baseConfig = require('./webpack.base.js')({});

module.exports = webpackMerge(baseConfig, {
    entry: {
        'vendor': root('client/vendor.ts'),
        'common': root('client/common.ts'),
        'quiz-roulette': root('client/quiz-roulette/main.ts')
    },
    module: {
        rules: [
            { test: /\.ts$/, loader: ['awesome-typescript-loader', 'angular2-template-loader'] }
        ]
    }
});

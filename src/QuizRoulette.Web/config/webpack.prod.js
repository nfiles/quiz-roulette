const webpackMerge = require('webpack-merge');

const publicPath = '/';

const baseConfig = require('./webpack.base.js')({ publicPath });

module.exports = webpackMerge(baseConfig, {});

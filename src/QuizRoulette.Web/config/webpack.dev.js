const webpackMerge = require('webpack-merge');
const cors = require('cors');

const publicPath = 'http://localhost:8080/';

const baseConfig = require('./webpack.base.js')({ publicPath });

module.exports = webpackMerge(baseConfig, {
    devServer: {
        setup(app) {
            app.use(cors());
        },
        stats: 'minimal'
    }
});

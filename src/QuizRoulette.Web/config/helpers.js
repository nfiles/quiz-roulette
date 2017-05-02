const path = require('path');

module.exports = {
    root: (...paths) => path.resolve(__dirname, '..', ...paths)
};

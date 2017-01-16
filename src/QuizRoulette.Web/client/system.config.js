(function () {
    var packages = {
        'rxjs': { defaultExtension: 'js' },
        'app': { defaultExtension: 'js' }
    };
    [
        'common',
        'core',
        'compiler',
        'forms',
        'platform-browser',
        'platform-browser-dynamic',
        'router'
    ].forEach(function (sub) {
        packages['@angular/' + sub] = {
            main: 'bundles/' + sub + '.umd.js',
            defaultExtension: 'js'
        };
    });
    SystemJS.config({
        map: {
            '@angular': '/lib/@angular',
            'rxjs': '/lib/rxjs'
        },
        packages: packages
    });
})();

(function () {
    var packages = {
        'rxjs': { defaultExtension: 'js' },
        'traceur': { main: 'dist/commonjs/traceur.js' },
        'app': {
            defaultExtension: 'js'
        }
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
        //baseURL: '/app',
        map: {
            '@angular': '/lib/@angular',
            'rxjs': '/lib/rxjs',
            'traceur': '/lib/traceur',
        },
        packages: packages
        //defaultJSExtensions: true,
        //transpiler: false,
        //runtime: false
    });
})();

/// <binding Clean='clean' />
'use strict';

const gulp = require('gulp');
const del = require('del');
const concat = require('gulp-concat');
const cssmin = require('gulp-cssmin');
const less = require('gulp-less');
const ts = require('gulp-typescript');
const sourcemaps = require('gulp-sourcemaps');
const uglify = require('gulp-uglify');
const eventStream = require('event-stream');

const webroot = './wwwroot/';
const clientSrc = './client/';
const nodeModules = './node_modules/';
const paths = {
    js: webroot + 'js/**/*.js',
    minJs: webroot + 'js/**/*.min.js',
    css: webroot + 'css/**/*.css',
    minCss: webroot + 'css/**/*.min.css',
    concatJsDest: webroot + 'js/site.min.js',
    concatCssDest: webroot + 'css/site.min.css',
    libDest: webroot + 'lib/',
    clientDest: webroot + 'app/',
    clientSrcTs: clientSrc + '**/*.ts',
    clientSrcJs: clientSrc + '**/*.js',
    clientSrcLess: clientSrc + '**/*.less'
};

const npm_libs = {
    'bootstrap': [
        'dist/css/bootstrap.min.css',
        'dist/js/bootstrap.min.js',
        'dist/fonts/*'
    ],
    'jquery': ['dist/jquery.min.js'],
    'core-js': ['client/shim.min.js'],
    'systemjs': ['dist/system.js'],
    '@angular': ['*/bundles/*.umd.js'],
    'traceur': [
        'bin/traceur.js',
        'bin/BrowserSystem.js',
        'src/bootstrap.js'
    ],
    'rxjs': ['**/*.js'],
    'zone.js': ['dist/zone.js']
};

const quizRouletteTsProject = ts.createProject('tsconfig.json');

gulp.task('clean:js', function () {
    return del(paths.concatJsDest);
});

gulp.task('clean:css', function () {
    return del(paths.concatCssDest);
});

gulp.task('clean:libs', function () {
    return del(paths.libDest);
});

gulp.task('clean:scripts', function () {
    return del(paths.clientDest);
});

gulp.task('clean', ['clean:libs', 'clean:js', 'clean:css', 'clean:scripts']);

gulp.task('min:js', function () {
    return gulp.src([paths.js, '!' + paths.minJs], { base: '.' })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest('.'));
});

gulp.task('min:css', function () {
    return gulp.src([paths.css, '!' + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest('.'));
});

gulp.task('min', ['min:js', 'min:css']);

gulp.task('copy:libs', function () {
    let tasks = Object.keys(npm_libs).map(name => {
        let srcs = npm_libs[name].map(glob => `${nodeModules}${name}/${glob}`);
        return gulp
            .src(srcs, { base: nodeModules + name })
            .pipe(gulp.dest(paths.libDest + name));
    });

    return eventStream.merge(tasks);
});

gulp.task('copy', ['copy:libs']);

gulp.task('build:ts', function () {
    return quizRouletteTsProject.src()
        .pipe(sourcemaps.init())
        .pipe(quizRouletteTsProject())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest(paths.clientDest));
});

gulp.task('build:js', function () {
    return gulp.src(paths.clientSrcJs)
        .pipe(gulp.dest(paths.clientDest));
});

gulp.task('build:less', function () {
    return gulp.src(paths.clientSrcLess)
        .pipe(less())
        .pipe(gulp.dest(paths.clientDest));
})

gulp.task('build', ['build:ts', 'build:js', 'build:less']);

gulp.task('watch', ['copy', 'build'], function () {
    gulp.watch(paths.clientSrcTs, ['build:ts']);
    gulp.watch(paths.clientSrcJs, ['build:js']);
    gulp.watch(paths.clientSrcLess, ['build:less'])
});

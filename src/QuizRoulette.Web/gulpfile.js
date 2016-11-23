/// <binding Clean='clean' />
'use strict';

const gulp = require('gulp');
const rimraf = require('rimraf');
const concat = require('gulp-concat');
const cssmin = require('gulp-cssmin');
const less = require('gulp-less');
const typescript = require('gulp-typescript');
const uglify = require('gulp-uglify');
const merge = require('merge-stream');

const webroot = './wwwroot/';

const paths = {
    js: webroot + 'js/**/*.js',
    minJs: webroot + 'js/**/*.min.js',
    css: webroot + 'css/**/*.css',
    minCss: webroot + 'css/**/*.min.css',
    concatJsDest: webroot + 'js/site.min.js',
    concatCssDest: webroot + 'css/site.min.css',
    libDest: webroot + 'lib/',
    nodeModules: './node_modules/',
    clientSrc: './client/',
    clientDest: webroot + 'dist/'
};
paths.clientSrcTs = paths.clientSrc + '**/*.ts';
paths.clientSrcLess = paths.clientSrc + '**/*.less';

const npm_libs = [{
    name: 'bootstrap',
    css: ['dist/css/bootstrap.min.css'],
    js: ['dist/js/bootstrap.min.js'],
    fonts: ['dist/fonts/*']
}, {
    name: 'jquery',
    js: ['dist/jquery.min.js']
}];

gulp.task('clean:js', function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task('clean:css', function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task('clean:libs', function (cb) {
    rimraf(paths.libDest, cb);
});

gulp.task('clean:scripts', function (cb) {
    rimraf(paths.clientDest, cb);
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
    let tasks = npm_libs.map(lib =>
        ['css', 'js', 'fonts']
            .filter(type => lib[type] && lib[type].length > 0)
            .map(type => {
                let srcPaths = lib[type].map(file => `${paths.nodeModules}${lib.name}/${file}`);
                return gulp.src(srcPaths)
                    .pipe(gulp.dest(`${paths.libDest}${lib.name}/${type}/`));
            })
    );

    return merge(tasks);
});

gulp.task('copy', ['copy:libs']);

gulp.task('build:ts', function () {
    return gulp.src(paths.clientSrcTs)
        .pipe(typescript())
        .pipe(gulp.dest(paths.clientDest));
});

gulp.task('build:less', function () {
    return gulp.src(paths.clientSrcLess)
        .pipe(less())
        .pipe(gulp.dest(paths.clientDest));
})

gulp.task('build', ['build:ts', 'build:less']);

gulp.task('watch', ['copy', 'build'], function () {
    gulp.watch(paths.clientSrcTs, 'build:ts');
});

"use strict";

var paths = {
    wwwroot: './wwwroot/'
};
paths.js = paths.wwwroot + 'js/**/*.js';
paths.minjs = paths.wwwroot + 'js/**/*.min.js';
paths.concatjs = paths.wwwroot + 'js/site.min.js';

var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');

gulp.task('min:js', function() {

    return gulp.src([paths.js, '!' + paths.minjs], { base: '.'})
               .pipe(concat(paths.concatjs))
               .pipe(uglify())
               .pipe(gulp.dest('.'));

});

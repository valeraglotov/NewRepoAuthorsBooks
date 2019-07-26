var gulp = require("gulp");

gulp.task("task1",
    function () {
        return gulp
            .src("node_modules/jquery-ajax-unobtrusive")
            .pipe(gulp.dest("./wwwroot/lib/"));
    });

gulp.task("task2",
    function () {
        return gulp
            .src("node_modules/jquery-ajax-unobtrusive/README.md")
            .pipe(gulp.dest("./wwwroot/lib/jquery-ajax-unobtrusive/"));
    });

gulp.task("task3",
    function () {
        return gulp
            .src("node_modules/jquery-ajax-unobtrusive/package.json")
            .pipe(gulp.dest("./wwwroot/lib/jquery-ajax-unobtrusive/"));
    });

gulp.task("task4",
    function () {
        return gulp
            .src("node_modules/jquery-ajax-unobtrusive/LICENSE.txt")
            .pipe(gulp.dest("./wwwroot/lib/jquery-ajax-unobtrusive/"));
    });

gulp.task("task5",
    function () {
        return gulp
            .src("node_modules/jquery-ajax-unobtrusive/dist")
            .pipe(gulp.dest("./wwwroot/lib/jquery-ajax-unobtrusive/"));
    });

gulp.task("task6",
    function () {
        return gulp
            .src("node_modules/jquery-ajax-unobtrusive/dist/jquery.unobtrusive-ajax.js")
            .pipe(gulp.dest("./wwwroot/lib/jquery-ajax-unobtrusive/dist/"));
    });

gulp.task("task7",
    function () {
        return gulp
            .src("node_modules/jquery-ajax-unobtrusive/dist/jquery.unobtrusive-ajax.min.js")
            .pipe(gulp.dest("./wwwroot/lib/jquery-ajax-unobtrusive/dist/"));
    });

gulp.task("default",
    gulp.series("task1", "task2", "task3", "task4", "task5", "task6", "task7")
);













//var gulp = require("gulp");
//var gnf = require("gulp-npm-files");
//var port = process.env.SERVER_PORT || 8080;
//var nodepath = "node_modules/";

////jquery-ajax-unobtrusive
//gulp.task("server", gulp.series("build", function () {
//    browser.init({ server: "./wwwroot", port: port });
//}));

//// Copy static assets
//gulp.task("copy", function () {
//    //Copy other external font and data assets
//    gulp.src(gnf(), { base: "./" }).pipe(gulp.dest("./wwwroot"));

//});



//gulp.task("copynpm", function(done) {
//    gulp.src(gnf(), { base: "./" }).pipe(gulp.dest("./wwwroot"));
//    done();
//});


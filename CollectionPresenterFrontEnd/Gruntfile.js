module.exports = function (grunt) {
	grunt.initConfig({
		pkg: grunt.file.readJSON('package.json'),
		concat: {
			options: {
				separator: '\n'
			},
			dist: {
				src: [
					'src/scripts/libs/jquery/dist/jquery.js',
					'src/scripts/libs/jquery-ui/jquery-ui.js',
					'src/scripts/libs/metro-ui-css/js/*.js',
					'src/scripts/libs/angular/angular.js',
					'src/scripts/libs/angular-resource/angular-resource.js',
					'src/scripts/libs/angular-route/angular-route.js',
					'src/scripts/*.js', 
					'src/scripts/controllers/*.js',
					'!src/scripts/dev-*.js', //needs to remove dev-settings
				],
				dest: 'dist/scripts/<%= pkg.name %>.js'
			}
		},
		uglify: {
			options: {
				banner: '/*! <%= pkg.name %> <%= grunt.template.today("dd-mm-yyyy") %>*/\n',
			},
			dist: {
				files: {
					'dist/scripts/<%= pkg.name %>.min.js': ['<%= concat.dist.dest %>']
				}
			}
		},
		jshint: {
			files: [
				'src/scripts/*.js', 
				'src/scripts/controllers/*.js'
			]
		},
		watch: {
			files: ['<%= jshint.files %>'],
			tasks: ['jshint']
		},
		cssmin: {
			combine: {
				options: {
					banner: '/*! minified css <%= pkg.name %> <%= grunt.template.today("dd-mm-yyyy") %>*/\n'
				},
				files: {
					'dist/css/<%= pkg.name %>.min.css' : ['src/scripts/libs/metro-ui-css/css/*.css']
				}
			}
		},
		useminPrepare: {
			html: 'src/index.html',
			options: {
				dest: 'dist'
			}
		},
		usemin: {
			html: ['dist/index.html']
		},
		copy: {
			main: {
				files: [
					{ expand: true, cwd: 'src/', src: ['index.html'], dest: 'dist/'},
					{ expand: true, cwd: 'src/templates', src: ['*.html'], dest: 'dist/templates/'},
					{ expand: true, cwd: 'src/views', src: ['*.html'], dest: 'dist/views/'}
				]
			}		
		},
		clean: {
			js: ['dist/scripts/*.js', '!dist/scripts/*.min.js']
		}
	});

	grunt.loadNpmTasks('grunt-contrib-concat');
	grunt.loadNpmTasks('grunt-contrib-uglify');
	grunt.loadNpmTasks('grunt-contrib-jshint');
	grunt.loadNpmTasks('grunt-contrib-watch');
	grunt.loadNpmTasks('grunt-contrib-cssmin');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks('grunt-contrib-clean');
	grunt.loadNpmTasks('grunt-usemin');

	grunt.registerTask('default', [
		'copy', 
		'jshint', 
		'useminPrepare', 
		'concat', 
		'uglify', 
		'cssmin', 
		'usemin',
		'clean'
	]);
	
	grunt.registerTask('test', ['jshint']);
};
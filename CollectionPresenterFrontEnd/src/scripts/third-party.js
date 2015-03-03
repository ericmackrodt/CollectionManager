//item.js
(function (angular) {

	var underscore = angular.module('underscore', []);

	underscore.factory('_', function() {
		return window._;
	});

}) (window.angular)
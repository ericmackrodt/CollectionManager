//main.js
(function (angular) {

	var main = angular.module('CollectionPresenter.Main', ['ngRoute', 'CollectionPresenter.Settings']);

	main.config(['$routeProvider', function($routeProvider) {
	  $routeProvider.when('/', {
	    templateUrl: 'views/Main.html',
	    controller: 'MainController'
	  });
	}]);

	main.controller("MainController", ['$scope', 'main', 'settings', function($scope, main, settings) {
		main.get(function (data) {
			$scope.collections = data.value;
		});

		$scope.headerImage = settings.mainHeaderImage;
	}]);

}) (window.angular);
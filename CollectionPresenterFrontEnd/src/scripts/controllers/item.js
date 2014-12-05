//item.js
(function (angular) {

	var app = angular.module('CollectionPresenter.Item', ['ngRoute']);

	app.config(['$routeProvider', function($routeProvider) {
		$routeProvider.when('/item/:id', {
			templateUrl: 'views/item.html',
			controller: 'ItemController'
		}).otherwise({
			redirectTo: '/'
		});
	}]);

	app.controller("ItemController", ['$scope', '$routeParams', 'items', function($scope, $routeParams, items) {
		items.get({ id: $routeParams.id }, function (data) {
			$scope.item = data.value;
		});
	}]);

}) (window.angular);
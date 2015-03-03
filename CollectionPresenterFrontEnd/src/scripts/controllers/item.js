//item.js
(function (angular) {

	var app = angular.module('CollectionPresenter.Item', ['ngRoute', 'underscore']);

	app.config(['$routeProvider', function($routeProvider) {
		$routeProvider.when('/item/:id', {
			templateUrl: 'views/item.html',
			controller: 'ItemController'
		}).otherwise({
			redirectTo: '/'
		});
	}]);

	app.controller("ItemController", ['$scope', '$routeParams', 'items', '_', function($scope, $routeParams, items, _) {
		items.get({ id: $routeParams.id, $expand: 'characteristics,images,description' }, function (data) {
			$scope.item = data;
			$scope.images = _.where(data.images, {
				imageType: 'Image'
			});
			$scope.screenshots = _.where(data.images, {
				imageType: 'Screenshot'
			});
		});
	}]);

}) (window.angular);
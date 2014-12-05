//app.js
(function (angular) {

	var app = angular.module("CollectionPresenter", [
		'ngRoute',
		'CollectionPresenter.ApiClient',
		'CollectionPresenter.Main',
		'CollectionPresenter.Item',
		'CollectionPresenter.List'
	]);

	app.controller("collectionsController", ['$scope', 'collections', 'settings', function ($scope, collections, settings) {
		$scope.appName = settings.appTitle;
		if ($scope.collections) return;
		collections.get({$expand: 'categories'}, function(data) {
			$scope.collections = data.value;
		});
	}]);

	app.directive("titleBar", function() {
		return {
			templateUrl: 'templates/titleBarTemplate.html',
			restrict: 'E',
			controller: "collectionsController"
		};
	});

	app.directive("categoriesSidebar", function() {
		return {
			templateUrl: 'templates/categoriesSidebarTemplate.html',
			restrict: 'E',
			controller: "collectionsController"
		};
	});

	app.directive("itemPresenter", function() {
		return {
			templateUrl: 'templates/itemTemplate.html',
			restrict: 'E',
			scope: {
				item: '='
			}
		};
	});

	app.directive("itemList", function() {
		return {
			templateUrl: 'templates/itemsListTemplate.html',
			restrict: 'E'
		};
	});

}) (window.angular);


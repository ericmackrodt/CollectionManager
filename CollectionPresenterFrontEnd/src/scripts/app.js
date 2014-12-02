angular.module("CollectionPresenter", [
	'ngRoute',
	'CollectionPresenter.ApiClient',
	'CollectionPresenter.Main',
	'CollectionPresenter.Item',
	'CollectionPresenter.List'
])

.controller("collectionsController", function ($scope, collections) {
	$scope.appName = "Collection";
	if ($scope.collections) return;
	collections.get({$expand: 'categories'}, function(data) {
		$scope.collections = data.value;
	});
})

.directive("titleBar", function() {
	return {
		templateUrl: 'templates/titleBarTemplate.html',
		restrict: 'E',
		controller: "collectionsController"
	};
})

.directive("categoriesSidebar", function() {
	return {
		templateUrl: 'templates/categoriesSidebarTemplate.html',
		restrict: 'E',
		controller: "collectionsController"
	};
})

.directive("itemPresenter", function() {
	return {
		templateUrl: 'templates/itemTemplate.html',
		restrict: 'E',
		scope: {
			item: '='
		}
	};
})

.directive("itemList", function() {
	return {
		templateUrl: 'templates/itemsListTemplate.html',
		restrict: 'E'
	};
});


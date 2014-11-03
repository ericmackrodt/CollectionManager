angular.module("CollectionPresenter", [
	'ngRoute',
	'CollectionPresenter.ApiClient',
	'CollectionPresenter.Main',
	'CollectionPresenter.Item',
	'CollectionPresenter.List'
])

.directive("titleBar", function() {
	return {
		templateUrl: 'templates/titleBarTemplate.html',
		restrict: 'E',
		controller: function ($scope, Collection) {
			$scope.appName = "Collection";
			Collection.query(function(data) {
				$scope.mnCollections = data.collections;
			});
		}
	};
})

.directive("categoriesSidebar", function() {
	return {
		templateUrl: 'templates/categoriesSidebarTemplate.html',
		restrict: 'E',
		controller: function ($scope, Categories) {
			Categories.query(function(data) {
				$scope.sbCollections = data.collections;
			});
		}
	};
})

.directive("itemPresenter", function() {
	return {
		templateUrl: 'templates/itemTemplate.html',
		restrict: 'E',
		scope: {
			item: '='
		}
	}
})

.directive("itemList", function() {
	return {
		templateUrl: 'templates/itemsListTemplate.html',
		restrict: 'E'
	}
});


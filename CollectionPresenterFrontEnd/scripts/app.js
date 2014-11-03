angular.module("CollectionPresenter", [
	'ngRoute',
	'CollectionPresenter.ApiClient',
	'CollectionPresenter.Main',
	'CollectionPresenter.Item',
	'CollectionPresenter.List'
])

.directive("categoriesSidebar", function() {
	return {
		templateUrl: 'templates/categoriesSidebarTemplate.html',
		restrict: 'E',
		controller: function ($scope, Categories) {
			Categories.query(function(data) {
				$scope.collections = data.collections;
			});
		}
	};
})

.directive("itemPresenter", function() {
	return {
		templateUrl: 'templates/itemTemplate.html',
		restrict: 'E'
	}
});


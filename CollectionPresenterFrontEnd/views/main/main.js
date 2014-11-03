angular.module('CollectionPresenter.Main', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/', {
    templateUrl: 'views/main/Main.html',
    controller: 'MainController'
  });
}])

.controller("MainController", function($scope, CollectionItems) {
	CollectionItems.query(function (data) {
		$scope.collections = data.collections;
	});
});
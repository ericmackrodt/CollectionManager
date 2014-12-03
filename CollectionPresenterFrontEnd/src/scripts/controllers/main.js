angular.module('CollectionPresenter.Main', ['ngRoute', 'CollectionPresenter.Settings'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/', {
    templateUrl: 'views/Main.html',
    controller: 'MainController'
  });
}])

.controller("MainController", function($scope, main, settings) {
	main.get(function (data) {
		$scope.collections = data.value;
		$scope.imagesFolder = settings.imagesFolder;
	});
});
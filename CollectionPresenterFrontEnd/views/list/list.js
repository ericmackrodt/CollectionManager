angular.module('CollectionPresenter.List', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/category/:id', {
    templateUrl: 'views/list/list.html',
    controller: 'CategoryController'
  }).when('/collection/:id', {
    templateUrl: 'views/list/list.html',
    controller: 'CollectionController'
  }).otherwise({
  	redirectTo: '/'
  });
}])

.controller("CategoryController", function($scope, $routeParams, Item) {
  $scope.title = "Category";
  /*Item.query(function (data) {
		console.log($routeParams.id);
		$scope.item = data.item;
	});*/
})

.controller("CollectionController", function($scope, $routeParams, Item) {
  $scope.title = "Collection";
  /*Item.query(function (data) {
    console.log($routeParams.id);
    $scope.item = data.item;
  });*/
});
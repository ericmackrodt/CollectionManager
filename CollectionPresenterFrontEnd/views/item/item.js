angular.module('CollectionPresenter.Item', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/item/:id', {
    templateUrl: 'views/item/item.html',
    controller: 'ItemController'
  }).otherwise({
  	redirectTo: '/'
  });
}])

.controller("ItemController", function($scope, $routeParams, Item) {
	Item.get({ id: $routeParams.id }, function (data) {
		$scope.item = data;
	});
});
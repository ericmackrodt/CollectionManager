angular.module('CollectionPresenter.Item', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/item/:id', {
    templateUrl: 'views/item.html',
    controller: 'ItemController'
  }).otherwise({
  	redirectTo: '/'
  });
}])

.controller("ItemController", function($scope, $routeParams, items) {
	items.get({ id: $routeParams.id }, function (data) {
		$scope.item = data.value;
	});
});
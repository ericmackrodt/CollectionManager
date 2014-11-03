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
  var lastSelected = null;

  $scope.title = "Collection";
  Item.get(null, function(data) {
    $scope.items = data;
  });

  $scope.selectItem = function(item) {
    Item.get({ id: item.id }, function(data) {
      $scope.selectedItem = data;

      if (lastSelected)
        lastSelected.selected = false;
      item.selected = true;
      lastSelected = item;
    });
  };
});
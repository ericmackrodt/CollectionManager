(function (angular) {
  var app = angular.module('CollectionPresenter.List', ['ngRoute']);

  app.config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/category/:id', {
      templateUrl: 'views/list.html',
      controller: 'CategoryController'
    }).when('/collection/:id', {
      templateUrl: 'views/list.html',
      controller: 'CollectionController'
    }).otherwise({
      redirectTo: '/'
    });
  }]);

  app.controller("CategoryController", ['$scope', '$routeParams', 'categories', function($scope, $routeParams, categories) {
    $scope.title = "Category";
    categories.getItems({ id: $routeParams.id }, function(data) {
      $scope.items = data.value;
    });
  }]);

  app.controller("CollectionController", ['$scope', '$routeParams', 'collections', 'items', function($scope, $routeParams, collections, items) {
    var lastSelected = null;

    $scope.title = "Collection";
    collections.getItems({ id: $routeParams.id }, function(data) {
      $scope.items = data.value;
    });

    $scope.selectItem = function(item) {
      items.get({ id: item.id, $expand: 'description,characteristics' }, function(data) {
        $scope.selectedItem = data;

        if (lastSelected)
          lastSelected.selected = false;
        item.selected = true;
        lastSelected = item;
      });
    };
  }]);
}) (window.angular);
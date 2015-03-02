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
    categories.get({ id: $routeParams.id }, function(data) {
      $scope.title = data.name;
      $scope.description = data.description;
    });

    categories.getItems({ id: $routeParams.id, $expand: 'characteristics,images' }, function(data) {
      $scope.items = data.value;
    });
  }]);

  app.controller("CollectionController", ['$scope', '$routeParams', 'collections', 'items', function($scope, $routeParams, collections, items) {
    var lastSelected = null;

    collections.get({ id: $routeParams.id }, function(data) {
      $scope.title = data.name;
      $scope.description = data.description;
    });

    collections.getItems({ id: $routeParams.id, $expand: 'characteristics,images' }, function(data) {
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
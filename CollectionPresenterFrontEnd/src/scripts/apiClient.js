//apiClient.js
(function (angular) {

	var app = angular.module("CollectionPresenter.ApiClient", ['ngResource', 'CollectionPresenter.Settings'])

	app.factory("collections", ['$resource', 'settings', function($resource, settings) {
		var odataUrl = settings.baseServiceUrl + '/odata/Collections(:id)';
		return $resource(odataUrl, {}, {
			'getCategories': { method: "GET", url: odataUrl + "/categories" },
			'getItems': { method: "GET", url: odataUrl + "/items" }
		});
	}]);

	app.factory("categories", ['$resource', 'settings', function($resource, settings) {
		var odataUrl = settings.baseServiceUrl + '/odata/Categories(:id)';
		return $resource(odataUrl, {}, {
			'getItems': { method: "GET", url: odataUrl + "/items" }
		});
	}]);

	app.factory("items", ['$resource', 'settings', function($resource, settings) {
		var odataUrl = settings.baseServiceUrl + '/odata/Items(:id)';
		return $resource(odataUrl);	
	}]);

	app.factory("main", ['$resource', 'settings', function($resource, settings) {
		return $resource(settings.baseServiceUrl + '/api/Main');	
	}]);

}) (window.angular);
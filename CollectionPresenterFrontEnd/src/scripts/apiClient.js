angular.module("CollectionPresenter.ApiClient", ['ngResource', 'CollectionPresenter.Settings'])

.factory("collections", function($resource, settings) {
	var odataUrl = settings.baseServiceUrl + '/odata/Collections(:id)';
	return $resource(odataUrl, {}, {
		'getCategories': { method: "GET", url: odataUrl + "/categories" },
		'getItems': { method: "GET", url: odataUrl + "/items" }
	});
})

.factory("categories", function($resource, settings) {
	var odataUrl = settings.baseServiceUrl + '/odata/Categories(:id)';
	return $resource(odataUrl, {}, {
		'getItems': { method: "GET", url: odataUrl + "/items" }
	});
})

.factory("items", function($resource, settings) {
	var odataUrl = settings.baseServiceUrl + '/odata/Items(:id)';
	return $resource(odataUrl);	
})

.factory("main", function($resource, settings) {
	return $resource(settings.baseServiceUrl + '/api/Main');	
});
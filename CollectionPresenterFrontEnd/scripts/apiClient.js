var baseUrl = 'http://localhost/CollectionManagerWebApi';

angular.module("CollectionPresenter.ApiClient", ['ngResource'])

.factory("collections", function($resource) {
	var odataUrl = baseUrl + '/odata/Collections(:id)';
	return $resource(odataUrl, {}, {
		'getCategories': { method: "GET", url: odataUrl + "/categories" },
		'getItems': { method: "GET", url: odataUrl + "/items" }
	});
})

.factory("categories", function($resource) {
	var odataUrl = baseUrl + '/odata/Categories(:id)';
	return $resource(odataUrl, {}, {
		'getItems': { method: "GET", url: odataUrl + "/items" }
	});
})

.factory("items", function($resource) {
	var odataUrl = baseUrl + '/odata/Items(:id)';
	return $resource(odataUrl);	
});;
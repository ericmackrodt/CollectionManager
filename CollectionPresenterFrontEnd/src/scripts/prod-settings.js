//settings.js
(function (angular) {
	var module = angular.module("CollectionPresenter.Settings", []);

	module.constant('settings', {
		baseServiceUrl: "http://localhost/CollectionManagerWebApi",
		apiKey: "",
		serverImagesFolder : "/CollectionManagerWebApi/Content/CollectionImages/",
		appTitle: "Eric Mackrodt's Collection",
		mainHeaderImage: "http://www.hardwareheaven.com/reviewimages/confessions-of-a-retro-gaming-addict/panarama.jpg"
	});
}) (window.angular);
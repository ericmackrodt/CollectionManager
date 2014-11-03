var collections = [
	{ id: 1, name: "Software" },
	{ id: 2, name: "Processadores" },
	{ id: 3, name: "Diversos" }
];

var categories = [
	{ id: 1, name: "Microsoft", collectionId: 1 },
	{ id: 2, name: "IBM", collectionId: 1 },
	{ id: 3, name: "Games", collectionId: 1 },
	{ id: 4, name: "CDs", collectionId: 3 },
	{ id: 5, name: "Mouses", collectionId: 3 },
	{ id: 6, name: "Midia", collectionId: 3 }
];

var items = [
	{
		id: 1,
		name: "Microsoft Windows 95",
		year: 1995,
		developer: "Microsoft",
		publisher: "Microsoft",
		manufacturer: "Microsoft",
		characteristics: ["Box", "Manual", "Diskettes"],
		description: { content: "This is Windows 95, the operating system from MS", source: "Wikipedia", url: "http://www.wikipedia.com" },
		images: [ "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=4", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=3", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=2" ,"http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=1" ],
		screenshots: [ "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=4", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=3", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=2" ,"http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=1" ],
		categories: [1],
		dateAcquired: "10/05/2014",
		youtubeVideo: "wI16xfTff8A"
	},
	{
		id: 2,
		name: "IBM OS/2 Warp 3",
		year: 1993,
		developer: "IBM",
		publisher: "IBM",
		manufacturer: "IBM",
		characteristics: ["Box", "Manual", "Diskettes"],
		description: { content: "This is OS/2 Warp 3", source: "Wikipedia", url: "http://www.wikipedia.com" },
		images: [ "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=4", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=3", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=2" ,"http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=1" ],
		screenshots: [ "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=4", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=3", "http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=2" ,"http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg?a=1" ],
		categories: [2],
		dateAcquired: "10/05/2014",
		youtubeVideo: "something"
	}
];

angular.module("CollectionPresenter.ApiClient", ['ngResource'])

.factory("Collection", function($resource) {
	return {
		query: function(cb) {
			cb({ collections: [
				{ id: 1, name: "Software" },
				{ id: 2, name: "Processadores" },
				{ id: 3, name: "Diversos" }
			] });
		}
	}
})

.factory("Categories", function($resource) {
	return {
		query: function(cb) {
			cb({
				collections: [
					{
						title: "Software",
						categories: [
							{ title: "IBM", id: 1 },
							{ title: "Microsoft", id: 2 },
							{ title: "Games", id: 3 }
						]
					},
					{
						title: "Diversos",
						categories: [
							{ title: "CDs", id: 1 },
							{ title: "Mouses", id: 2 },
							{ title: "Mídia", id: 3 }
						]
					}
				]
			});
		}
	}
})

.factory("CollectionItems", function($resource) {
	return {
		query: function(cb) {
			cb({
				collections: [{
					title: "Software",
					items: [
						{ title: "Windows 95", id: 1, imgUrl: 'http://static.spiceworks.com/attachments/post/0002/6651/OMNIA_227__800x600_.jpg' },
						{ title: "Windows 98", id: 1, imgUrl: 'http://fc08.deviantart.net/fs71/i/2011/151/7/7/windows_98_boot_screen_by_pkmnct-d3hkkxk.jpg' },
						{ title: "Windows XP", id: 1, imgUrl: 'http://3.bp.blogspot.com/-Y4tfgq8z-2U/UPNMuVRXFuI/AAAAAAAAACA/8iZCD6jw2fo/s1600/01fig02+(1).jpg' },
						{ title: "SimTower", id: 1, imgUrl: 'http://kuvat2.huuto.net/c/14/30de1cb7625ef5873e2d9fedf4790-orig.jpg' },
						{ title: "Lemmings", id: 1, imgUrl: 'http://farm9.static.flickr.com/8391/8673787921_a182ee4d8b_m.jpg' },
						{ title: "The Dig", id: 1, imgUrl: 'http://thefloppydisk.com/games/the_dig_ibm/the_dig_ibm.jpg' }
					]
				}
				]
			});
		}
	}
})

.factory("Item", function($resource) {
	return {
		get: function(filter, cb) {
			if (!filter) {
				cb(items);
				return;
			}

			var item = items[filter.id - 1];
			cb(item);
		}
	}
});
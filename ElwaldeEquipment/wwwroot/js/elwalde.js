window.startCarousel=(carouselId) =>{
	var myCarousel = document.getElementById(carouselId);
	var carousel = new bootstrap.Carousel(myCarousel);
	carousel.cycle(); // NOTE: this will cause the carousel to start immediately
}
window.alertMessage = (message) => {
	alert("Hello World");
}
window.loadBingMap = (raw) => {

	if (typeof Microsoft === 'undefined') {
		setTimeout(loadBingMap, 100);
	} else {
		// Your map code here
	
	var map = new Microsoft.Maps.Map("#map");
	map.setView({
		mapTypeId: raw== "arial"?

			 Microsoft.Maps.MapTypeId.aerial:
		
			 Microsoft.Maps.MapTypeId.road
		,
		center: new Microsoft.Maps.Location(9.064258, 38.716437),
		zoom: 17
	});
	var pin = new Microsoft.Maps.Pushpin(map.getCenter(), {
		//Set the value for text, title and subTitle properties.
		text: '1',
		title: 'Elwalde Office',
		subTitle: 'Behind EBC New Station'

	});

	//Add the pushpin to the map.
			map.entities.push(pin);
		var EbcLocation = new Microsoft.Maps.Location(9.065465, 38.714426);
		var pin2 = new Microsoft.Maps.Pushpin(EbcLocation, {
			//Set the value for text, title and subTitle properties.
			text: '2',
			title: 'EBC New Station',
			subTitle: 'Behind Shegole Ring'
		});
		map.entities.push(pin2);
		//Load the GeoJSON module.
		Microsoft.Maps.loadModule('Microsoft.Maps.GeoJSON', function () {
			//Create a sample GeoJSON object.
			var geoJson = {
				"type": "FeatureCollection",
				"features": [
					{
						"type": "Feature",
						"geometry": {
							"type": "Point",
							"coordinates": [9.064358, 38.714337]
						},
						"properties": {
							"title": "Microsoft",
							"icon": "https://www.bingmapsportal.com/Content/images/poi_custom.png"
						}
					}
				]
			};

			//Parse the GeoJSON object into an array of Bing Maps shapes.
			var shapes = Microsoft.Maps.GeoJSON.read(geoJson);

			//Add the shapes to the map.
			map.entities.push(shapes);
		});

	//Microsoft.Maps.loadModule("Microsoft.Maps.GeoJson", function () {
	//	for (var geojson_item of JSON.parse(String(raw))) {
	//		var shape = Microsoft.Maps.GeoJson.read(geojson_item, {
	//			polygonOptions: {
	//				fillColor: 'rgba(255, 0, 0, 0.5)',
	//				strokeColor: 'white',
	//				strokeThickness: 5
	//			}
	//		});
	//		map.entities.push(shape);
	//		var pins = new Microsoft.Maps.Pushpin(Microsoft.Maps.Location(geojson_item.geometry.coordinates[1], geojson_item.geometry.coordinates[0]), {
	//			title: geojson_item.properties.name
	//		});
	//		map.entities.push(pins);
	//	}
	//});
	}
}
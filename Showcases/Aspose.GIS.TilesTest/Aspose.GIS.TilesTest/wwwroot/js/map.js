var map = L.map('map').setView([47.59995, 19.36623], 13);
const tiles = L.tileLayer('/tiles/{z}/{x}/{y}.png', {
	maxZoom: 19,
	minZoom: 11
}).addTo(map);
(function () {
	"use strict";

	angular
		.module("common.services")
		.factory("registrationResource", ["$resource", "appSettings", registrationResource])
		
	function registrationResource($resource, appSettings) {
		return $resource(appSettings.serverPath + "/api/registrations/", null,
		{
			'registerUser':{method:'POST'},
		});
	}
}());
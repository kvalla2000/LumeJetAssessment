(function () {
	"use strict";
	angular
        .module("registrations")
        .controller("registratonCtrl",["$scope","registrationResource", registratonctrl]);

	function registratonctrl($scope, registrationResource) {
        	var vm = this;
        	vm.message ="";
        	vm.registration = {};

        	registrationResource.query(function (data) {
        		vm.registrations = data;
        	});        	
     }
}());

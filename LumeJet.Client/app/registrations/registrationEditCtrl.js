(function () {
    "use strict";

    angular
        .module("registrations")
        .controller("registrationEditCtrl",
                     registrationEditCtrl);

    function registrationEditCtrl(registrationResource) {
        var vm = this;
        vm.registration = {
        	userName: '',
			emailId: ''
        };
        vm.message = '';
        vm.isLoggedIn = false;

        vm.submit = function () {
        	registrationResource.registerUser(vm.registration,function (data) {
			 	vm.registration = data;
			 	vm.isLoggedIn = true;
			 });
        };   

    }
}());

using LumeJet.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LumeJet.WebApi.Controllers
{
	[EnableCorsAttribute("*","*","*")]
    public class RegistrationsController : ApiController
    {
        // GET: api/Registrations
        public IEnumerable<Registration> Get()
        {
			var registrationRepository = new RegistrationRepository();
			var registrations = registrationRepository.Retrieve();

			return registrations;
        }

        // GET: api/Registrations/5
        public Registration Get(int id)
        {
			Registration registration;
			var registrationRepository = new RegistrationRepository();
			if(id>0)
			{
				var registrations = registrationRepository.Retrieve();
				registration = registrations.FirstOrDefault(p => p.RegistrationId == id);
            }
			else
			{
				registration = registrationRepository.Create();
			}
			return registration;
        }

        // POST: api/Registrations
        public void Post([FromBody]Registration registartion)
        {
			var registrationRepository = new RegistrationRepository();
			var registrations = registrationRepository.Save(registartion);
		}

        // PUT: api/Registrations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Registrations/5
        public void Delete(int id)
        {
        }
    }
}

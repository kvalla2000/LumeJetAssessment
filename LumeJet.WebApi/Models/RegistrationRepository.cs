using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;

namespace LumeJet.WebApi.Models
{
	/// <summary>
	/// Stores the data in a json file so that no database is required for this
	/// sample application
	/// </summary>
	public class RegistrationRepository
	{

		/// <summary>
		/// Creates a new registartion.
		/// </summary>
		/// <returns></returns>
		internal Registration Create()
		{
			Registration registration = new Registration();
			
			return registration;
		}

		/// <summary>
		/// Retrieves the list of registrations.
		/// </summary>
		/// <returns></returns>
		internal List<Registration> Retrieve()
		{
			var filePath = HostingEnvironment.MapPath(@"~/App_Data/registration.json");

			var json = System.IO.File.ReadAllText(filePath);

			var registrations = JsonConvert.DeserializeObject<List<Registration>>(json);

			return registrations;
		}

		/// <summary>
		/// Saves a new registration.
		/// </summary>
		/// <param name="registration"></param>
		/// <returns></returns>
		internal Registration Save(Registration registration)
		{
			// Read in the existing registrations
			var registrations = this.Retrieve();

			// Assign a new Id
			var maxId = registrations.Max(p => p.RegistrationId);
			registration.RegistrationId = maxId + 1;
			registrations.Add(registration);

			WriteData(registrations);
			return registration;
		}

		/// <summary>
		/// Updates an existing registration
		/// </summary>
		/// <param name="id"></param>
		/// <param name="registration"></param>
		/// <returns></returns>
		internal Registration Save(int id, Registration registration)
		{
			// Read in the existing products
			var registrations = this.Retrieve();

			// Locate and replace the item
			var itemIndex = registrations.FindIndex(r => r.RegistrationId == registration.RegistrationId);
			if (itemIndex > 0)
			{
				registrations[itemIndex] = registration;
			}
			else
			{
				return null;
			}

			WriteData(registrations);
			return registration;
		}

		private bool WriteData(List<Registration> registrations)
		{
			// Write out the Json
			var filePath = HostingEnvironment.MapPath(@"~/App_Data/registration.json");

			var json = JsonConvert.SerializeObject(registrations, Formatting.Indented);
			System.IO.File.WriteAllText(filePath, json);

			return true;
		}

	}
}
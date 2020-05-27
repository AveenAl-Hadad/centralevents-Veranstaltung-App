using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CentralEvent.Business.Contracts.Models;

namespace CentralEvents.Web.Api.Controllers
{
	public class CesController
	{

		public IEnumerable<EventModel> CreateStammdaten()
		{
			IList<string> rowS = File.ReadAllLines(@"..\\CentralEvents.Commons\CEname.csv").Skip(1).ToList();
			IList<EventModel> eventListe = new List<EventModel>();

			foreach (string row in rowS)
			{
				eventListe.Add(this.EventModelFromStringList(row));
			}

			return eventListe;
		}
		
		private EventModel EventModelFromStringList(string row)
		{
			EventModel eventModel = new EventModel
			{
				Name = Convert.ToString(row).Trim()
			};
			return eventModel;
		}

	}
}

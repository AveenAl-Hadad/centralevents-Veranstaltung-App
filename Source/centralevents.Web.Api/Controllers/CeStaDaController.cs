namespace CentralEvents.Web.Api.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	using CentralEvent.Business.Contracts.Models;

	public class CeStaDaController
	{
		public IEnumerable<EventModel> CreateStammdaten()
		{
			string rawData = File.ReadAllText(@"..\\CentralEvents.Commons\CE.csv");
			string[] rowS = rawData.Split("$$$");

			IList<EventModel> eventListe = new List<EventModel>();

			foreach (string row in rowS)
			{
				eventListe.Add(this.EventModelFromString(row));
			}

			return eventListe;
		}

		private EventModel EventModelFromString(string row)
		{
			string[] entries = row.Split(";");

			EventModel eventModel = new EventModel
									{
										Name = entries[0].Trim(),
										Ort = this.GetOrtFromEntry(entries[1].Trim()),
										Datum = this.GetBeginnDateFromEntries(entries[2].Trim()),
										BeginnUhrzeit = entries[3].Trim(),
										EndeUhrzeit = entries[4].Trim(),
										Eintritt = Convert.ToDouble(entries[5].Replace("€", "").Replace("-", "0").Trim()),
										Beschreibung = entries[6].Replace('\"'.ToString(), "").Trim(),
										GesamtanzahlEintrittskarten = Convert.ToInt16(entries[7].Replace("-", "-1")),
										Restbestand = Convert.ToInt16(entries[7].Replace("-", "-1"))
									};
			return eventModel;
		}

		private string GetOrtFromEntry(string e)
		{
			return e.Substring(6);
		}

		private DateTime GetBeginnDateFromEntries(string d)
		{
			DateTime dateTime = new DateTime();
			dateTime = Convert.ToDateTime(d);
			return dateTime;
		}
	}
}
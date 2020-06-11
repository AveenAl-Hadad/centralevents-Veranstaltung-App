namespace CentralEvent.Business.Contracts.Models
{
	using System.Text.Json.Serialization;
	using Newtonsoft.Json;


	public class TestTextModel
	{
		[JsonProperty("Text")]
		public string Text { get; set; }
	}
}
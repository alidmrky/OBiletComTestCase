using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Dtos.Request.Journey
{
    public class GetBusJourneyRequest : BaseRequest
    {
        [JsonProperty("data")]
        public GetBusJourneyData Data { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    public class GetBusJourneyData
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }
        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }
        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}

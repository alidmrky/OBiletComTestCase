using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Dtos.Request.Location
{
    public class GetBusLocationRequest : BaseRequest
    {
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}

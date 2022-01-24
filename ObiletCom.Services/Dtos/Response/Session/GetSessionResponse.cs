using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Dtos.Response.Session
{
    public class GetSessionResponse : BaseResponse
    {
        [JsonProperty("data")]
        public GetSessionResponseData Data { get; set; }
    }

    public class GetSessionResponseData
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}

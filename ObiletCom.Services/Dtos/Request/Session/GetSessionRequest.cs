using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Dtos.Request.Session
{
    public class GetSessionRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("connection")]
        public Connection Connection { get; set; }
        [JsonProperty("browser")]
        public Browser Browser { get; set; }


    }
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAdress { get; set; }
        [JsonProperty("port")]
        public string Port { get; set; }
    }
    public class Browser
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }
}

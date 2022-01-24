using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Dtos.Response.Location
{
    public class GetBusLocationResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<GetBusLocationResponseData> Data { get; set; }
    }
    public class GetBusLocationResponseData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("parent-id")]
        public int? ParentId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }
        [JsonProperty("zoom")]
        public string Zoom { get; set; }
        [JsonProperty("tz-code")]
        public string TZCode { get; set; }
        [JsonProperty("weather-code")]
        public string WeatherCode { get; set; }
        [JsonProperty("rank")]
        public int? Rank { get; set; }
        [JsonProperty("reference-code")]
        public string ReferenceCode { get; set; }
        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
    public class GeoLocation
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("zoom")]
        public string Zoom { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Dtos
{
    public class BusLocationInfoDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public GeoLocation GeoLocation { get; set; }
        public string Zoom { get; set; }
        public string TZCode { get; set; }
        public string WeatherCode { get; set; }
        public int? Rank { get; set; }
        public string ReferenceCode { get; set; }
        public string Keywords { get; set; }
    }
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Zoom { get; set; }
    }
}

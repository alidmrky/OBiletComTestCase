using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Dtos
{
    public class GetBusJourneysInfoDto
    {     
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public decimal Price { get; set; }

    }
}

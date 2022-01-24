using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletComWeb.Models
{
    public class GetBusJourneyModel
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}

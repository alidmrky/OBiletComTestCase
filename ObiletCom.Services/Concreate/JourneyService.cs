using ObiletCom.Domain.Helpers;
using ObiletCom.Services.Abstract;
using ObiletCom.Services.Dtos;
using ObiletCom.Services.Dtos.Request;
using ObiletCom.Services.Dtos.Request.Journey;
using ObiletCom.Services.Dtos.Response.Journey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Concreate
{
    public class JourneyService : IJourneyService
    {
        private readonly ISessionService _sessionService;
        private readonly IRestClientHelper _restClientHelper;
        public JourneyService(ISessionService sessionService, IRestClientHelper restClientHelper)
        {
            _sessionService = sessionService;
            _restClientHelper = restClientHelper;
        }
        public async Task<Response<List<GetBusJourneysInfoDto>>> GetBusJourneys(GetBusJourneyModelDto getBusJourneyModelDto)
        {
            string baseUrl = "https://v2-api.obilet.com/api/journey/getbusjourneys";

            var sessionResponse = _sessionService.GetSession();
            if (!sessionResponse.Result.IsSuccess)
                return new Response<List<GetBusJourneysInfoDto>>() { IsSuccess = false };

            var sessionData = sessionResponse.Result.Data;
            if (sessionData == null)
                return new Response<List<GetBusJourneysInfoDto>>() { IsSuccess = false };

            var prepareData = PrepareGetBusJourneyRequest(getBusJourneyModelDto, sessionData.DeviceId, sessionData.SessionId);

            var busJourneyResponse = await _restClientHelper.ExecuteReqeust<GetBusJourneyResponse>(baseUrl, HttpMethod.Post, prepareData, CreateHeaders());

            if (!busJourneyResponse.IsSuccess)
                return new Response<List<GetBusJourneysInfoDto>>() { IsSuccess = false, Message = busJourneyResponse.Message };

            var busJourneyData = busJourneyResponse.Data.Data.Select(x => new GetBusJourneysInfoDto()
            {
                Destination = x.Journey.Destination,
                DestinationLocation = x.DestinationLocation,
                Origin = x.Journey.Origin,
                OriginLocation = x.OriginLocation,
                Arrival = x.Journey.Arrival,
                Departure = x.Journey.Departure,
                Price = x.Journey.OriginalPrice           
            }).ToList();

            return new Response<List<GetBusJourneysInfoDto>>() { Data = busJourneyData, IsSuccess = true };
        }
        private Dictionary<string, string> CreateHeaders()
        {
            var additionalHeaders = new Dictionary<string, string>();
            var apiClientToken = "JEcYcEMyantZV095WVc3G2JtVjNZbWx1";
            string auth = string.Format("{0} {1}", "Basic", apiClientToken);
            additionalHeaders.Add("Authorization", auth);
            return additionalHeaders;
        }
        private GetBusJourneyRequest PrepareGetBusJourneyRequest(GetBusJourneyModelDto getBusJourneyModelDto, string deviceId, string sessionId)
        {
            return new GetBusJourneyRequest()
            {
                Date = DateTime.Now,
                DeviceSession = new DeviceSession
                {
                    DeviceId = deviceId,
                    SessionId = sessionId
                },
                Data = new GetBusJourneyData()
                {
                    OriginId = getBusJourneyModelDto.OriginId,
                    DestinationId = getBusJourneyModelDto.DestinationId,
                    DepartureDate = getBusJourneyModelDto.DepartureDate
                },
                Language = "en-EN"
            };
        }
    }
}

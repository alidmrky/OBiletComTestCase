using ObiletCom.Domain.Helpers;
using ObiletCom.Services.Abstract;
using ObiletCom.Services.Dtos;
using ObiletCom.Services.Dtos.Request;
using ObiletCom.Services.Dtos.Request.Location;
using ObiletCom.Services.Dtos.Response.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Concreate
{
    public class LocationService : ILocationService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly ISessionService _sessionService;

        public LocationService(IRestClientHelper restClientHelper, ISessionService sessionService)
        {
            _restClientHelper = restClientHelper;
            _sessionService = sessionService;

        }
        public async Task<Response<List<BusLocationInfoDto>>> GetBusLocations()
        {
            string baseUrl = "https://v2-api.obilet.com/api/location/getbuslocations";
            // Take session info
            var sessionResponse = _sessionService.GetSession();
            if (!sessionResponse.Result.IsSuccess)
                return new Response<List<BusLocationInfoDto>>() { IsSuccess = false };

            var sessionData = sessionResponse.Result.Data;
            if (sessionData == null)
                return new Response<List<BusLocationInfoDto>>() { IsSuccess = false };
            // Prepare Data
            var prepareData = PrepareGetBusLocationRequest(sessionData.SessionId, sessionData.DeviceId);

            var busLocationResponse = await _restClientHelper.ExecuteReqeust<GetBusLocationResponse>(baseUrl, HttpMethod.Post, prepareData, CreateHeaders());
            if (!busLocationResponse.IsSuccess)
                return new Response<List<BusLocationInfoDto>>() { IsSuccess = false, Message = busLocationResponse.Message };

            var busLocationData = busLocationResponse.Data.Data.Select(x => new BusLocationInfoDto()
            {
                Id = x.Id,
                Keywords = x.Keywords,
                Name = x.Name,
                ParentId = x.ParentId,
                Rank = x.Rank,
                ReferenceCode = x.ReferenceCode,
                Type = x.Type,
                TZCode = x.TZCode,
                WeatherCode = x.WeatherCode,
                Zoom = x.Zoom,
                GeoLocation = new Dtos.GeoLocation()
                {
                    Latitude = x.GeoLocation.Latitude,
                    Longitude = x.GeoLocation.Longitude,
                    Zoom = x.GeoLocation.Zoom
                }
            }).ToList();

            return new Response<List<BusLocationInfoDto>>() { Data = busLocationData, IsSuccess = true };
        }
        private Dictionary<string, string> CreateHeaders()
        {
            var additionalHeaders = new Dictionary<string, string>();
            var apiClientToken = "JEcYcEMyantZV095WVc3G2JtVjNZbWx1";
            string auth = string.Format("{0} {1}", "Basic", apiClientToken);
            additionalHeaders.Add("Authorization", auth);
            return additionalHeaders;
        }
        private GetBusLocationRequest PrepareGetBusLocationRequest(string sessionId, string deviceId)
        {
            return new GetBusLocationRequest()
            {
                Date = DateTime.Now,
                Data = string.Empty,
                DeviceSession = new DeviceSession()
                {
                    DeviceId = deviceId,
                    SessionId = sessionId
                },
                Language = "en-EN"
            };
        }
    }
}

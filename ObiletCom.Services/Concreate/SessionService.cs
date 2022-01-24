using ObiletCom.Domain.Helpers;
using ObiletCom.Services.Abstract;
using ObiletCom.Services.Dtos;
using ObiletCom.Services.Dtos.Request.Session;
using ObiletCom.Services.Dtos.Response.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Concreate
{
    public class SessionService : ISessionService
    {
        private readonly IRestClientHelper _restClientHelper;
        public SessionService(IRestClientHelper restClientHelper)
        {
            _restClientHelper = restClientHelper;
        }

        #region Public Methods
        public async Task<Response<SessionInfoDto>> GetSession()
        {
            string baseUrl = "https://v2-api.obilet.com/api/client/getsession";

            var response = await _restClientHelper.ExecuteReqeust<GetSessionResponse>(baseUrl, HttpMethod.Post, CreateGetSessionRequest(), CreateHeaders());

            if (!response.IsSuccess)
                return new Response<SessionInfoDto>() { IsSuccess = false, Message = response.Message };

            var sessionResponseData = response.Data;
            var sessionInfoDto = new SessionInfoDto()
            {
                SessionId = sessionResponseData.Data.SessionId,
                DeviceId = sessionResponseData.Data.DeviceId
            };

            return new Response<SessionInfoDto>() { Data = sessionInfoDto, IsSuccess = true };
        }

        #endregion

        #region Private Methods
        private Dictionary<string, string> CreateHeaders()
        {
            var additionalHeaders = new Dictionary<string, string>();
            var apiClientToken = "JEcYcEMyantZV095WVc3G2JtVjNZbWx1";
            string auth = string.Format("{0} {1}", "Basic", apiClientToken);
            additionalHeaders.Add("Authorization", auth);
            return additionalHeaders;
        }
        private GetSessionRequest CreateGetSessionRequest()
        {
            return new GetSessionRequest()
            {
                Browser = new Browser()
                {
                    EquipmentId = "distribusion",
                    Name = "chrome",
                    Version = "1.0.0.0"
                },
                Connection = new Connection()
                {
                    IpAdress = "212.252.125.171",
                    Port = "8080"
                },
                Type = "7"
            };
        }
        #endregion

    }
}

using ObiletCom.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Abstract
{
    public interface IRestClientHelper
    {
        Task<Response<T>> ExecuteReqeust<T>(string requestUri, HttpMethod httpMethod, object postData = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null, string stringPostData = null);
    }
}

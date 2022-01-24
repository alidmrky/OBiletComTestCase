using ObiletCom.Domain.Helpers;
using ObiletCom.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Abstract
{
    public interface ISessionService
    {
        Task<Response<SessionInfoDto>> GetSession();
    }
}

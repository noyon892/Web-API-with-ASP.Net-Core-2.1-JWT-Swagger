using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Areas.IB.Models;
using WebAPI.Areas.IB.Repository;

namespace WebAPI.Helper
{
    public interface IAuthenticateServices
    {
        TokenModel Authenticate(string userName, string Password);
    }
}

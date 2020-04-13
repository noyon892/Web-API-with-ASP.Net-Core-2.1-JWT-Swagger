using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Areas.IB.Models;
using WebAPI.Helper;

namespace WebAPI.Areas.IB.IRepository
{
    public interface ILogin
    {
        TokenModel Authenticate(string userName, string Password);
    }
}

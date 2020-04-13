using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Areas.IB.Models;

namespace WebAPI.Areas.IB.IRepository
{
    public interface IUser
    {
        List<Userlist> GetAll();
        Userlist Get(int id);
    }
}

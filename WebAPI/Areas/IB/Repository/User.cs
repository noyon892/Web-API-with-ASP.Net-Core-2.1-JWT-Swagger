using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Areas.IB.IRepository;
using WebAPI.Areas.IB.Models;

namespace WebAPI.Areas.IB.Repository
{
    public class User:IUser
    {
        private List<Userlist> users = null;
        public User()
        {
            users = new List<Userlist>()
            {
                new Userlist(){UserId = 0, Username = "Noyon892", Firstname = "Md. Hasan", Lastname = "Uzzaman Noyon", Password = "B.h.p.892"},
                new Userlist(){UserId = 1, Username = "Moni", Firstname = "Sirajum", Lastname = "Munira", Password = "1234567890"}
            };
        }
        public List<Userlist> GetAll()
        {
            return users;
        }

        public Userlist Get(int id)
        {
            Userlist user = users.FirstOrDefault(u => u.UserId == id);
            return user;
        }
    }
}

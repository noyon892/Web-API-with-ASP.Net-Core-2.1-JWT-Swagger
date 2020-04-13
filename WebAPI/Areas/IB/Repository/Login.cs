using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Areas.IB.IRepository;
using WebAPI.Areas.IB.Models;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Areas.IB.Repository
{
    public class Login : ILogin
    {
        private readonly AppSettings _appSettings;

        public Login(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        private List<TokenModel> users = new List<TokenModel>()
        {
            new TokenModel()
            {
                UserId = 1, Username = "Noyon892", Firstname = "Md. Hasan", Lastname = "Uzzaman Noyon",
                Password = "B.h.p.892"
            }
        };

        public TokenModel Authenticate(string userName, string password)
        {
            var user = users.SingleOrDefault(x => x.Username == userName && x.Password == password);
            //return null
            if (users == null)
            {
                return null;
            }

            //User Found
            var tokenHandlar = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V2.1")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandlar.CreateToken(tokenDescriptor);
            user.Token = tokenHandlar.WriteToken(token);
            user.Password = null;
            return user;
        }
    }
}

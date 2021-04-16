using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        //token ın kullanıcı kitlesi:
        public string Audience { get; set; }
        //imzalayan:
        public string Issuer { get; set; }
        //geçerlilik süresi (dk) :
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}

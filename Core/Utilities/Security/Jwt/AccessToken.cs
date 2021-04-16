using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken
        //erişim anahtarı
    {
        //token'ın kendisi:
        public string Token { get; set; }
        //token ne kadar süre geçerli olacak:
        public DateTime Expiration { get; set; }
    }
}

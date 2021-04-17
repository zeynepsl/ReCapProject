using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        //Configuration dosyası, yapısı vasıtasıyla appsettings deki TokenOptions bilgilerini okuyacağız:
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //Configuration dan TokenOptions section nını(bölümünü )al
            //TokenOptions nesnesine bağla aktar
            //artık elimde bir nesne var

            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//bu token ne zaman bitecek 

            //bir tokenı oluştururken kendimize şifreli bir token oluşturucaz
            //bunu böyle de yazabilirdim ama ben bunu diğer projelerde de kullanmak istiyorum:
            //var securitykey= return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //_tokenOptions daki security key i kullanarak security key oluştur
            //Bu token ı oluşturacak elimde güvenlik anahtarı var

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //hangi anahtarı, algoritmayı kullanacak

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            //bu nesneyle(handler vasıtasıyla) elimdeki token bilgisini yazdırıcam:
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);//elimizdeki token nesnesini string e çevirdik

            //artık AccessToken döndürmeliym
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, 
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                //expires:tokenOptions.AccessTokenExpiration,  AccessTokenExpiration int olarak tutmuştuk hata verdi, datetime a çevirmeliyiz
                notBefore:DateTime.Now,
                //claims:operationClaims,
                claims:SetClaim(user, operationClaims),
                signingCredentials:signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaim(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            //claims.Add(new Claim("email", user.Email));//bu çalışır ama extends edicez claim nesnesini
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(oC => oC.Name).ToArray());//operationClaims bir koleksiyon onu array e çevir
            return claims;
        }
    }
}

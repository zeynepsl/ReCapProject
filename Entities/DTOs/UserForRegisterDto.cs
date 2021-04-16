using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //Register olmak isteyen user ın entity si
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }
        //kullanıcıdan basit bir şefre alacağız,tuzlayıp  hash e çevirip veritabanı ile kontrol edeceğiz
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

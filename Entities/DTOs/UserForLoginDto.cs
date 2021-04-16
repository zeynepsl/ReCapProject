using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //login olmak isteyen birinin entity si
    public class UserForLoginDto:IDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

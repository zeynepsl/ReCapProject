using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var accessToken = _authService.CreateAccessToken(userToLogin.Data);
            if (accessToken.Success)
            {
                return Ok(accessToken.Data);
            }
            return BadRequest(accessToken.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (userExists.Success==false)
            {
                return BadRequest(userExists.Message);
            }
            var userToRegister = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var accessToken = _authService.CreateAccessToken(userToRegister.Data);
            if (accessToken.Success)
            {
                return Ok(accessToken.Data);
            }
            return BadRequest(accessToken.Message);
        }
    }
}

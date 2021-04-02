using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    //Colors'a, gelen requestleri yönetmesi için controller veriyoruz
    {
        //Business katmanındaki ColorManager'deki tüm metotlarımızı birer request haline getireceğiz
        //bunu yapabilmek için :
        IColorService _colorService;//loosely coupled - gevşek bağımlılık - soyuta bağımlılık
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet("getall")] 
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcolorsbycolorid")]
        public IActionResult GetColorsByColorId()
        {
            var result = _colorService.GetColorsByColorId(1);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

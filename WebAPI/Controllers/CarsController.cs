using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class CarsController : ControllerBase
    //Arabalar'a, gelen requestleri yönetmesi için controller veriyoruz
    //sistemimizi kullanacak client'lar(angular, mobil vs..) bize hangi operasyonlar için nasıl istekte bulunur bunu controller'a yazıyoruz
    {
        //Business katmanındaki CarManager'deki tüm metotlarımızı birer request haline getireceğiz
        //bunu yapabilmek için : 
        ICarService _carService;
        //katmanlar birbirini new' lememeli veya somut sınıf üzerinden gitmemeli
        //loosely coupled - gevşek bağımlılık - soyuta bağımlılık == Manager değişirse sorun olmayacak
        //çünkü Manager'ların referansını ICarservice tutabilliyor

        public  CarsController(ICarService carService)
        {
            _carService = carService;
        }
        //bu şekilde çalıştırırsak hata alırız: Çözümleyemedim der 
        //çözümlemek == ICarService a bağlı olan bir sınıfı new' lemek demek
        //********bunun sorunu : ICarService ile ilgili elinde somut bir referans yok. Bunun İçin :
        //IoC Container -- inversion of control
        //bellekteki listemize ==== new CarManager(), new EfCartDal() referansları koyacağız
        //Kim ihtiyaç duyarsa ona vereceğiz -->AutofacBusinessModule

        [HttpGet("getall")] //"get request" gerçekleştiriyor
        //https://localhost:44334/api/cars/getall birisi böyle bir istekte bulunursa ona "Arabaların Tümünü" Listele : 
        //[Authorize(Roles ="Cars.List")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetCarsByBrandId()
        {
            var result = _carService.GetCarsByBrandId(1);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetCarsByColorId()
        {
            var result = _carService.GetCarsByColorId(1);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

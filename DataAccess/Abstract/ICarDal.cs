using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        //List<Car> GetAll();
        //List<Car> GetById(int Id);

        List<CarDetailsDto> GetCarDetails();
    }
}

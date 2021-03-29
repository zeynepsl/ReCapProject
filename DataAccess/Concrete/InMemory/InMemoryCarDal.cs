using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId=1, BrandId=1, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=600000, Description="mercedes 1"},
                new Car{ CarId=2, BrandId=1, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=800000, Description="mercedes 2"},
                new Car{ CarId=3, BrandId=2, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=500000, Description="audi 1"},
                new Car{ CarId=4, BrandId=2, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=450000, Description="audi 2"},
                new Car{ CarId=5, BrandId=3, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=500000, Description="bmw 1"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(cartoDelete);
        }

        public Car Get()
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car cartoUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            cartoUpdate.CarId = car.CarId;
            cartoUpdate.BrandId = car.BrandId;
            cartoUpdate.ColorId = car.ColorId;
            cartoUpdate.ModelYear = car.ModelYear;
            cartoUpdate.DailyPrice = car.DailyPrice;
            cartoUpdate.Description = car.Description;
        }
    }
}

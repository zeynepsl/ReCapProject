using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{ Id=1, BrandId=1, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=600000, Description="mercedes 1"},
                new Car{ Id=2, BrandId=1, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=800000, Description="mercedes 2"},
                new Car{ Id=3, BrandId=2, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=500000, Description="audi 1"},
                new Car{ Id=4, BrandId=2, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=450000, Description="audi 2"},
                new Car{ Id=5, BrandId=3, ColorId=1, ModelYear=new DateTime(2020), DailyPrice=500000, Description="bmw 1"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(cartoDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car cartoUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            cartoUpdate.Id = car.Id;
            cartoUpdate.BrandId = car.BrandId;
            cartoUpdate.ColorId = car.ColorId;
            cartoUpdate.ModelYear = car.ModelYear;
            cartoUpdate.DailyPrice = car.DailyPrice;
            cartoUpdate.Description = car.Description;
        }
    }
}

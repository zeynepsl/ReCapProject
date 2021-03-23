using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            //mevcut arabalrı listeleyelim
            ArabaListele(carManager);

            //araba ekleyelim
            InMemoryCarDal carDal = new InMemoryCarDal();
            Car car = new Car
            {
                Id = 1,
                ColorId = 2,
                ModelYear = new DateTime(2020),
                DailyPrice = 350000,
                BrandId = 1,
                Description = "audi",
            };
            carDal.Add(car);

            //tüm arabaları yeniden listeleyelim
            Console.WriteLine("yeni eklenen ürünlerle oluşan yeni araba listesi: ");
            ArabaListele(carManager);
        }

        private static void ArabaListele(CarManager carManager)
        {
            //arabaları listeleyelim
            Console.WriteLine("mevcut araba listesi : ");
            foreach (var car1 in carManager.GetAll())
            {
                Console.WriteLine(car1.Description);
            }
        }

    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car
            {
                CarId=3,
                ColorId = 1,
                BrandId = 1,
                DailyPrice = 200,
                ModelYear = new DateTime(2020, 6, 6),
                Description = "mercedes, otomatik"
            };

            //araba ekleyelim
            //burada arayüzden arabanın özelliklerini girerek yeni bir araba eklemeye çalışıyoruz
            //arayüzden Business a bağlanıyoruz
            //Business daki iş kodlarından (if..... vs..) geçerse DataAccess katmanına bağlanacağız
            //DataAccess de araba kaydedilecek
            carManager.Add(car);


            //mevcut arabalrı listeleyelim
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

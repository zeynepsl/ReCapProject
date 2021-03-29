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
                CarName="bmw",
                CarId = 5,
                ColorId = 2,
                BrandId = 1,
                DailyPrice = 200,
                ModelYear = new DateTime(2020, 1, 4),
                Description = "bmw, otomatik"
            };

            //araba ekleyelim
            //burada arayüzden arabanın özelliklerini girerek yeni bir araba eklemeye çalışıyoruz
            //arayüzden Business a bağlanıyoruz
            //Business daki iş kodlarından (if..... vs..) geçerse DataAccess katmanına bağlanacağız
            //DataAccess de araba kaydedilecek
            carManager.Add(car);

            //mevcut arabaları listeleyelim
            ArabaListele(carManager);

            //biraz önce eklediğimiz arabayı silelim
            //carManager.Delete(car);

            //arabanın özelliklerini güncelleyelim
            //car.Description = "volvo, otomatik, deri koltuk";
            //carManager.Update(car);

            Console.WriteLine("arabalar : ");
            foreach(var car1 in carManager.GetCarDetails())
            {
                Console.WriteLine(car1.CarName + " - " + car1.BrandName + " - " + car1.ColorName + " - " + car1.DailyPrice);
            }

            //Brandtest();
            //ColorTest();

        }

        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand
            {
                BrandId = 3,
                BrandName = "bmw"
            };
            brandManager.Add(brand);//veritabanına yeni marka ekleyelim 

            Console.WriteLine("marka listesi:");
            foreach(var brand1 in brandManager.GetAll())
            {
                Console.WriteLine(brand1.BrandName);
            }
            brand.BrandName = "volvo";//yeni eklediğimiz markayı güncelleyelim
            brandManager.Update(brand);

            Console.WriteLine("güncel marka listesi:");
            foreach (var brand1 in brandManager.GetAll())
            {
                Console.WriteLine(brand1.BrandName);
            }

            brandManager.Delete(brand);//oluşturduğumuz markayı silelim
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color()
            {
                ColorId = 5,
                ColorName = "siyah"
            };
            colorManager.Add(color);

            Console.WriteLine("renk listesi:");
            foreach(var color1 in colorManager.GetAll())
            {
                Console.WriteLine(color1.ColorName);
            }
            color.ColorName = "beyaz";
            colorManager.Update(color);

            Console.WriteLine("güncel renk listesi:");
            foreach (var color1 in colorManager.GetAll())
            {
                Console.WriteLine(color1.ColorName);
            }
            colorManager.Delete(color);

            Console.WriteLine("güncel renk listesi:");
            foreach (var color1 in colorManager.GetAll())
            {
                Console.WriteLine(color1.ColorName);
            }
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

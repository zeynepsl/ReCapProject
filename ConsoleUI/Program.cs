using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            //CarTest();

            //Brandtest();

            // ColorTest();

            //OzellikleriyleArabaListele();

            //KullaniciEkleme();

            //ArabaKiralamaDetaylariGöster();

            ArabaKirala();

        }

        private static IResult ArabaKirala()
        {
            Console.WriteLine("araba kiralama");

            int _carId, _customerId;
            DateTime _rentDate, _returnDate;

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " : " + car.CarId);
            }

            Console.WriteLine("Kiralamak istediğiniz arabanın Id bilgisini girniz : ");
            _carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("kullanıc Id bilginizi giriniz : ");
            _customerId = Convert.ToInt32(Console.ReadLine());

            _rentDate = DateTime.Now;
            _returnDate = DateTime.Now.AddDays(5);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CarId = _carId, CustomerId = _customerId, RentDate = _rentDate , ReturnDate=_returnDate};

            rentalManager.Add(rental);
            return new SuccessResult();
        }

        private static void ArabaKiralamaDetaylariGöster()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            Console.WriteLine("araba kiralama  detayları : ");
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarDescription + " - " + rental.BrandName + " - " + rental.CarModelYear);
                }
            }
        }

        private static IResult KullaniciEkleme()
        {
            string _firstName, _lastName, _email;
            int _password;
            Console.WriteLine("-- KULLANICI EKLEME --");

            Console.WriteLine("adınızı girin :");
            _firstName = Console.ReadLine();
            Console.WriteLine("soyadınızı girin :");
            _lastName = Console.ReadLine();
            Console.WriteLine("e-posta adresinizi girin :");
            _email = Console.ReadLine();
            Console.WriteLine("şifrenizi girin (sadece rakamlar):");
            _password = Convert.ToInt32(Console.ReadLine());

            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = _firstName, LastName = _lastName, Email = _email, Password = _password };
            userManager.Add(user);
            return new SuccessResult();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car
            {
                CarName = "bmw",
                CarId = 6,
                ColorId = 2,
                BrandId = 1,
                DailyPrice = 200,
                ModelYear = new DateTime(2020, 1, 4),
                Description = "bmw, otomatik"
            };

            carManager.Add(car);
            ArabaListele();
            car.Description = "volvo, otomatik, deri koltuk";
            carManager.Update(car);
            carManager.Delete(car);
        }

        private static void OzellikleriyleArabaListele()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            Console.WriteLine("arabalar : ");
            if (result.Success==true)
            {
                foreach (var car1 in result.Data)
                {
                    Console.WriteLine(car1.CarName + " - " + car1.BrandName + " - " + car1.ColorName + " - " + car1.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ArabaListele()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            //arabaları listeleyelim
            Console.WriteLine("mevcut araba listesi : ");
            if (result.Success)
            {
                foreach (var car1 in result.Data)
                {
                    Console.WriteLine(car1.Description);
                }
            }
        }

        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand
            {
                BrandId = 3,
                BrandName = "bmw"
            };
            brandManager.Add(brand);

            Console.WriteLine("marka listesi:");
            foreach(var brand1 in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand1.BrandName);
            }

            brand.BrandName = "volvo";
            brandManager.Update(brand);

            Console.WriteLine("güncel marka listesi:");
            foreach (var brand1 in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand1.BrandName);
            }

            brandManager.Delete(brand);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color()
            {
                ColorId = 5,
                ColorName = "beyaz"
            };

            colorManager.Add(color);

            Console.WriteLine("renk listesi:");
            foreach(var color1 in colorManager.GetAll().Data)
            {
                Console.WriteLine(color1.ColorName);
            }

            color.ColorName = "beyaz";
            colorManager.Update(color);

            Console.WriteLine("güncel renk listesi:");
            foreach (var color1 in colorManager.GetAll().Data)
            {
                Console.WriteLine(color1.ColorName);
            }
            colorManager.Delete(color);

            Console.WriteLine("güncel renk listesi:");
            foreach (var color1 in colorManager.GetAll().Data)
            {
                Console.WriteLine(color1.ColorName);
            }
        }

        

    }
}

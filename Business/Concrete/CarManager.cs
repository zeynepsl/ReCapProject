using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
         ICarDal _carDal;
        /*business sadece bunu biliyor inmemory vs bilmiyor
         * şu an bu inmemeory de olabilir öbür gün entityframework de olabilir, bunlar alternarif == veri erişim alternatifleri
         * 
         *bir iş sınıfı başka sınıfları new lemez
         * CarManager new lendiğinde bu kurucu metot diyecek ki bana ICarDal referansı ver
         */
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //if (car.Description.Length > 2 && car.DailyPrice > 0)//eğer ki iş kodlarından geçerse,
            //{
            //    _carDal.Add(car);//DataAccess katmanına bağlanacağız.
            //    return new SuccessResult(Messages.CarAdded);
            //} ARTIK FLUENT_VALIDATION İLE ÇALIŞIYORUZ:

            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //ama burada değişen sadece CarValidator ve car, Core a aktaracağız evrensel kulllanılabilir hale getireceğiz

            // ValidationTool.Validate(new CarValidator(), car);

            //log, cache, transaction vs gelecek buraya karışacak, bunun yerine AOP kullanıyoruz
            //metodun en üstüne yazdık

            //business codes

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded); 
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);

            //döndürdüğüm data       (Data)     : _carDal.GetAll()
            //işlem sonucum          (Success)  : true
            //bilgilendirici mesajım (Messsage) : Messages.CarsListed
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            if(car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }

            return new ErrorResult(Messages.CarDescriptionInValid);
        }

    }
}

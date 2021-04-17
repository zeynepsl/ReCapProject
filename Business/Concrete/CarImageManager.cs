using Business.Abstract;
using Core.Utilities.Results;
using System;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules;
using Core.Utilities.Business;
using Business.ValidationRules.FluentValidation;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helper;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfNumberOfPictures(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = new FileHelper().Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) 
                + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            IResult result = BusinessRules.Run(new FileHelper().Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfNumberOfPictures(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) 
                + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = new FileHelper().Update(oldpath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<CarImage> Get(CarImage carImage)
        {
            //IResult result = BusinessRules.Run(CheckIfThereIsPictureOfCar(carImage.CarId));
            //if (result != null)
            //{
            //    return new ErrorDataResult<CarImage>();
            //}
            //return new SuccessDataResult<CarImage>(CheckIfThereIsPictureOfCar(carImage.CarId));
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carImage.CarId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfThereIsPictureOfCar(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfThereIsPictureOfCar(carId).Data);
        }

        public IDataResult<List<CarImage>> GetImagesByDate(DateTime date)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Date == date));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        private IResult CheckIfNumberOfPictures(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result>5)
            {
                return new ErrorResult(Messages.CarImageLimited);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfThereIsPictureOfCar(int carId)
        {
            try
            {
                string path = @"\Images\default.png";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        
    }
}

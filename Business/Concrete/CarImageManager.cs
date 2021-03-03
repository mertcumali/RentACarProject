using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Aspects.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        private readonly string DefaultImage = Environment.CurrentDirectory + @"\wwwroot\Images\rentlogo.jpg";

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile image, CarImage img)
        {
            IResult result = BusinessRules.Run(CheckIfCarImagesLimitExceded(img.CarId));

            if (result != null)
            {
                return result;
            }

            img.ImagePath = FileHelper.Add(image);
            img.Date = DateTime.Now;
            _carImageDal.Add(img);
            return new SuccessResult(Messages.CarImageAdded);

        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile image, CarImage img)
        {
            IResult result = BusinessRules.Run(CheckIfCarImagesLimitExceded(img.CarId));
            if (result != null)
            {
                return result;
            }
            var carImg = _carImageDal.Get(c => c.CarImageId == img.CarImageId);
            carImg.Date = DateTime.Now;
            carImg.ImagePath = FileHelper.Add(image);
            FileHelper.Delete(img.ImagePath);
            _carImageDal.Update(carImg);

            return new SuccessResult(Messages.CarImageUpdated);
        }
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            FileHelper.Delete(carImage.ImagePath);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == id));
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }


        private IResult CheckIfCarImagesLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();

        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { 
                    new CarImage 
                    {
                        CarId = carId, ImagePath = DefaultImage, Date = DateTime.Now 
                    } 
                };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
        }


    }
}

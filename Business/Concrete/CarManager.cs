using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            if (car.Description.Length > 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        public IResult Update(Car car)
        {
            if (car.Description.Length > 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 2)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>( _carDal.Get(p => p.CarId == id));
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}

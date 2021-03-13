using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Aspects.Validation;
using Business.ValidationRules.FluentValidation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Caching;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("rental.add,admin")]
        public IResult Add(Rental rental)
        {
            var wantedCar = _rentalDal.Get(p => p.CarId == rental.CarId);
            if (wantedCar.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);

        }

        [SecuredOperation("rental.update,admin")]
        public IResult Update(Rental rental)
        {
            var wantedCar = _rentalDal.Get(p => p.CarId == rental.CarId);
            if (wantedCar.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdated);
        }

        [SecuredOperation("rental.delete,admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}

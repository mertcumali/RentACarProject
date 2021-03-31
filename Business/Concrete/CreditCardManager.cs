using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), Messages.CreditCardsListed);
        }

        public IDataResult<CreditCard> GetByCreditCardNumber(int creditCardNumber)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(p => p.CreditCardNumber == creditCardNumber));
        }

        public IDataResult<CreditCard> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(p => p.CustomerId == customerId));
        }

        public IResult Payment(decimal price, CreditCard creditCard)
        {
            var result = BusinessRules.Run(CheckIfCreditCardsExist(creditCard.Id));
            if (result != null)
            {
                return result;
            }
            if (price > creditCard.Balance)
            {
                return new ErrorResult();
            }
            creditCard.Balance = creditCard.Balance - price;
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        private IResult CheckIfCreditCardsExist(int creditCardId)
        {
            var result = _creditCardDal.Get(p => p.Id == creditCardId);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

     
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<CreditCard> GetByCreditCardNumber(int creditCardNumber);
        IDataResult<CreditCard> GetByCustomerId(int customerId);
        IResult Payment(decimal price, CreditCard creditCard);
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll();
    }
}

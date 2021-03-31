using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public decimal Balance { get; set; }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join r in context.Rentals
                             on ca.CarId equals r.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join u in context.Users
                             on cu.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                CompanyName = cu.CompanyName,
                                CarName =ca.Description,
                                DailyPrice=ca.DailyPrice,
                                BrandName = b.BrandName,
                                ColorName = co.ColorName,
                                RentDate =r.RentDate,
                                ReturnDate=r.ReturnDate

                             };
                return result.ToList();
            }

        }
    }
}

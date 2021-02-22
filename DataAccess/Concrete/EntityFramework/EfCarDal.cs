using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(RentACarContext context=new RentACarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join c in context.Colors
                             on ca.ColorId equals c.ColorId
                             select new CarDetailDto
                             {
                                 CarName = ca.Description,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = ca.DailyPrice

                             };
                return result.ToList();
            }
        }
    }
}

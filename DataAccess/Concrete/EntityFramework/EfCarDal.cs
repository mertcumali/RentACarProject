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
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join c in context.Colors
                             on ca.ColorId equals c.ColorId
                             join ci in context.CarImages
                             on ca.CarId equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = ca.CarId,
                                 BrandName = b.BrandName,
                                 BrandId = b.BrandId,
                                 ColorName = c.ColorName,
                                 ColorId = c.ColorId,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 ImagePath = ci.ImagePath

                             };
                return result.ToList();
            }
        }
    }
}

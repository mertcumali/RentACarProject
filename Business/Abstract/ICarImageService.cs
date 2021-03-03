using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int id);
        IResult Add(IFormFile image, CarImage img);
        IResult Update(IFormFile image, CarImage img);
        IResult Delete(CarImage carImage);
    }
}

﻿using Core.Utilities.Results;
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
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> GetById(int id);
        IResult Add(IFormFile file,CarImage carImager);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file,CarImage carImage);
    }
}

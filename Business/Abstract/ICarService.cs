using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult <List<CarDetailDto>>GetCarDetailDtos();
        IDataResult<List<CarDetailDto>> GetAllByDetailDtos(int carId);

        IDataResult<Car> GetById(int id);

    }
}

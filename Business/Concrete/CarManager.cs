using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
       

        //[SecuredOperation("Car.Add,Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

          IResult result =  BusinessRules.Run(CheckIfCarNameExists(car.Description),
                CheckIfCarCountOfBrandCorrect(car.BrandId));

            if(result!= null)
            {
                return result;
            }
                   
                _carDal.Add(car);
                return new SuccessResult(Message.CarAdded);
            
            
        }

     

        public IResult Delete(Car car)
        {
         
           _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }


        public IDataResult< List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Message.MaintanenceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Message.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>> ( _carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetAllByDetailDtos(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(c => c.CarId == carId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car> ( _carDal.Get(c => c.Id == id));
        }
        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return  new SuccessDataResult<List<Car>> ( _carDal.GetAll(c => c.DailyPrice >= 10 && c.DailyPrice <= 12000));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult <List<CarDetailDto>> ( _carDal.GetCarDetailDtos());
        }

        public IResult Update(Car car)
        {
         _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int BrandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == BrandId).Count;
            if (result >= 100)
            {
                return new ErrorResult(Message.CarCountOfBrandError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarNameExists(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description);
            if (result == null)
            {
                return new ErrorResult(Message.CarNameAlreadyExists);

            }
            return new SuccessResult();
        }
    }
}

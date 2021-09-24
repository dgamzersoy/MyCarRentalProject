using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal(){
            _cars = new List<Car>
            {
 

                new Car {Id=1 , BrandId=1, ColorId=1, DailyPrice=2000, ModelYear=1994, Description="bmw"},
                 new Car {Id=2 , BrandId=5, ColorId=1, DailyPrice=2000, ModelYear=1995, Description="audi"},
                 new Car {Id=3 , BrandId=5, ColorId=6, DailyPrice=8000, ModelYear=1995, Description="renault"}


            };
            }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(result);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
           return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public CarDetailDto GetCarDetailById(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.Id == car.Id);
            result.Id = car.Id;
            result.ColorId = car.ColorId;
            result.BrandId = car.BrandId;
            result.DailyPrice = car.DailyPrice;
            result.Description = car.Description;
            result.ModelYear = car.ModelYear;
        }
    }
}

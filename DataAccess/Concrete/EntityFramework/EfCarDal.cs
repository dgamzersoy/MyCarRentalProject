using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public CarDetailDto GetCarDetailById(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             

                             select new CarDetailDto() 
                             {
                                 BrandId = c.BrandId, 
                                 BrandName = b.BrandName, 
                                 CarId = c.Id, 
                                 ColorId = c.ColorId, 
                                 ColorName = color.ColorName, 
                                 DailyPrice = c.DailyPrice, 
                                 CarName = c.Description 
                             };
                var cars = result.Where(filter).ToList();
                foreach (var car in cars)
                {
                    return car;
                }
                return null;
            }
        }

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             
                          
                             select new CarDetailDto
                             {
                                 CarId =c.Id,
                                 BrandId=c.BrandId,
                                 ColorId=c.ColorId,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CarImages = (from i in context.CarImages
                                              where c.Id == i.CarId
                                              select new CarImage { Id = i.Id, CarId = i.CarId, ImagePath = i.ImagePath, Date = i.Date }).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
            
        }
       
    }
}

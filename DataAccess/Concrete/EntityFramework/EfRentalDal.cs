using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDto()
        {
           using(CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             select new CarRentalDetailDto 
                             { 
                             Description = c.Description,
                             CustomerName= cs.CampanyName,
                             RentTime=r.RentDate,
                             ReturnTime= (DateTime)r.ReturnDate
                                 };

                return result.ToList();

            }
        }
    }
}

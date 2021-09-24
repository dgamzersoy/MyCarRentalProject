using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService,ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(DateCheck(rental),CarCheck(rental),CustomerCheck(rental));
            if (result !=null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Message.CarRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.CarRentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<CarRentalDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDto());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.CarRentalUpdated);
        }
        private IResult DateCheck(Rental rental)
        {
            var carCheck = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var date in carCheck)
            {
                if (date.RentDate <= rental.RentDate && date.ReturnDate >= rental.RentDate)
                    return new ErrorResult(Message.InvalidDate);
                if (date.RentDate <= rental.ReturnDate && date.ReturnDate >= rental.ReturnDate)
                    return new ErrorResult(Message.InvalidDate);
                if (date.RentDate >= rental.RentDate && date.ReturnDate <= rental.ReturnDate)
                    return new ErrorResult(Message.InvalidDate);
            }
            return new SuccessResult();
        }

        private IResult CarCheck(Rental rental)
        {
            var car = _carService.GetById(rental.CarId);
            if (car.Data == null)
            {
                return new ErrorResult(Message.NoCar);
            }
            return new SuccessResult();
        }

        private IResult CustomerCheck(Rental rental)
        {
            var customer = _customerService.GetById(rental.CustomerId);
            if(customer.Data== null)
            {
                return new ErrorResult(Message.NoCustomer);
            }
            return new SuccessResult();
        }
    }
}

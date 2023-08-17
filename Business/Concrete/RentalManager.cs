using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(IsRentenable(rental.CarId, rental.RentDate));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll(c => c.CarId == id).OrderByDescending(r=> r.Id).FirstOrDefault(),Messages.Listed);
        }


        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        public IResult NewCarAdd(int id)
        {
            IResult result = BusinessRules.Run(CheckRental(id));
            if (result != null)
            {
                return new ErrorResult(Messages.ExistRental);
            }
            _rentalDal.Add(new Rental { CarId = id });
            return new SuccessResult(Messages.RentalAdded);
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        private IResult CheckRental(int id)
        {
            bool newCar = _rentalDal.GetAll().Any(c => c.CarId == id);
            if (newCar)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult IsRentenable(int id,DateTime? rentalDate)
        {
            var carDate = _rentalDal.GetAll(r => r.CarId == id).OrderByDescending(r=> r.ReturnDate).FirstOrDefault();
            if (carDate.ReturnDate <= DateTime.Now || carDate.ReturnDate == null || carDate.ReturnDate<=rentalDate)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.RentalReturnDateNotNull);
        }

    }
}


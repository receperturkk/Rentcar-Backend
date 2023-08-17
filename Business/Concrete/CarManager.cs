using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValildationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
            #region Add
            //if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            //{
            //    _carDal.Add(car);
            //    return new SuccessResult(Messages.CarAdded);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}
            #endregion

        }


        [SecuredOperation("admin,moderator")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id).ToList(), Messages.BrandsListed); //BrandId'ye göre fitreleme yapar
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max).ToList(), Messages.Listed); //fiyat aralığına göre filtrelemek için
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id), Messages.Listed);
        }


        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id).ToList(), Messages.ColorsListed); //ColorId'ye göre fitreleme yapar
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            var result = _carDal.GetCarDetailsByCarId(carId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetailsByColorId(colorId);
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetailsByBrandId(brandId);
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByFilter(int brandId, int colorId)
        {
            var result = _carDal.GetCarDetailsByFilter(brandId,colorId);
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }
        #region ConsoleUI için oluşturuldu
        public IResult CheckList(int id)
        {
            var result = _carDal.GetAll(c => c.Id == id);
            if (result != null)
            {
                return new SuccessResult(Messages.CarsListed);
            }
            else
            {
                return new ErrorResult();
            }
        }

        


        #endregion
    }
}

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
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             //join cı in context.CarImages
                             //on c.Id equals cı.CarId into carImage
                             //from cı in carImage.DefaultIfEmpty()
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 //ImagePath = cı.ImagePath.Cast<List<string>>(),
                                 ImagePath = context.CarImages.Where(cı => cı.CarId == c.Id).Select(ı => ı.ImagePath).ToList(),
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             //join cı in context.CarImages
                             //on c.Id equals cı.CarId into carImage
                             //from cı in carImage.DefaultIfEmpty()
                             where c.Id == carId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 //ImagePath = cı.ImagePath.Cast<List<string>>(),
                                 ImagePath = context.CarImages.Where(cı => cı.CarId == c.Id).Select(ı => ı.ImagePath).ToList(),
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             //join cı in context.CarImages
                             //on c.Id equals cı.CarId into carImage
                             //from cı in carImage.DefaultIfEmpty()
                             where co.Id == colorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 //ImagePath = cı.ImagePath.Cast<List<string>>(),
                                 ImagePath = context.CarImages.Where(cı => cı.CarId == c.Id).Select(ı => ı.ImagePath).ToList(),
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             //join cı in context.CarImages
                             //on c.Id equals cı.CarId into carImage
                             //from cı in carImage.DefaultIfEmpty()
                             where b.Id == brandId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 //ImagePath = cı.ImagePath.Cast<List<string>>(),
                                 ImagePath = context.CarImages.Where(cı => cı.CarId == c.Id).Select(ı => ı.ImagePath).ToList(),
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByFilter(int brandId,int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             //join cı in context.CarImages
                             //on c.Id equals cı.CarId into carImage
                             //from cı in carImage.DefaultIfEmpty()
                             where co.Id == colorId && b.Id == brandId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 //ImagePath = cı.ImagePath.Cast<List<string>>(),
                                 ImagePath = context.CarImages.Where(cı => cı.CarId == c.Id).Select(ı => ı.ImagePath).ToList(),
                             };
                return result.ToList();
            }
        }
    }
}

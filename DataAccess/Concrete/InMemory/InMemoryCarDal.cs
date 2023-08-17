using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //Global tanımlar genelde _ ile tanımlanır
        List<Car> _cars;

        //Bellekte çalışması için ctor(constructor)'ın içinde yazarız
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                //Id, BrandId, ColorId, ModelYear, DailyPrice, Description
                new Car { Id = 1,CarName = "Araba", BrandId = 1, ColorId = 1, ModelYear = 2023, DailyPrice = 350, Description = "Aile arabası"},
                new Car { Id = 2,CarName = "Araba", BrandId = 2, ColorId = 2, ModelYear = 2021, DailyPrice = 450, Description = "Nakliye arabası"},
                new Car { Id = 3,CarName = "Araba", BrandId = 2, ColorId = 2, ModelYear = 2022, DailyPrice = 300, Description = "Off-Road arabası"},
                new Car { Id = 4,CarName = "Araba", BrandId = 3, ColorId = 3, ModelYear = 2020, DailyPrice = 250, Description = "2 Kapılı araba"},
                new Car { Id = 5,CarName = "Araba", BrandId = 3, ColorId = 3, ModelYear = 2019, DailyPrice = 550, Description = "Spor otomobil"},
                new Car { Id = 6,CarName = "Araba", BrandId = 3, ColorId = 3, ModelYear = 2018, DailyPrice = 400, Description = "Yolcu arabası"},
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public bool CheckList(int id)
        {
            // any bool değer döndürür varmı yokmu diye bakar
            return _cars.Any(c => c.Id == id);
        }

        public int Count()
        {
            return _cars.Count();
        }

        public void Delete(int id)
        {
            //NORMAL YOLLA SİLME İŞLEMİ
            //Car car = null;
            //foreach (var c in _cars)
            //{
            //    if (car.Id == c.Id)
            //    {
            //        carToDelete = c;
            //    }
            //}

            //LINQ - LANGUAGE INTEGRATED QUERY İLE SİLME İŞLEMİ
            //SingleOrDefault() 1 tane arar genellikle id aramalarında kullanılır. Foreach gibi çalışır.
            //GÖNDERDİĞİM ÜRÜN İD'SİNE SAHİP OLAN LİSTEDEKİ ÜRÜNÜ BUL productToD
            Car? carToDelete = _cars.SingleOrDefault(c => c.Id == id);
            _cars.Remove(carToDelete);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
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

        public List<Car> GetById(int id)
        {
            List<Car> searchedCar = _cars.Where(c => c.Id == id).ToList();
            return searchedCar;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByFilter(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //GÖNDERDİĞİM ÜRÜN İD'SİNE SAHİP OLAN LİSTEDEKİ ÜRÜNÜ BUL carToUpdate ATA
            Car? carToUpdate = _cars.SingleOrDefault(c=> c.Id == car.Id);
            carToUpdate.CarName = car.CarName;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

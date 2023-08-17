using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var item in rentalManager.GetAll().Data)
            {
                var result=item.Id + " " + item.CarId;
                Console.WriteLine(result);
            }
            Rental rental = new Rental();
            rental.CarId = 1;
            rental.CustomerId = 2;
            rental.RentDate = new DateTime(2023,07,30);
            rental.ReturnDate = new DateTime(2023, 08, 05);
            var result1 = rentalManager.Add(rental);
            if (result1.Success)
            {
                Console.WriteLine(result1.Message);
            }
            else
            {
                Console.WriteLine(result1.Message);
            }
            

            string? choice = null;
            while (choice != "6") {
                Console.WriteLine("----SHADOW RENT A CAR---- \n***HOŞGELDİNİZ*** \n1-Tüm Araçları Getir \n2-Id'ye Göre Getir \n3-Araç Ekle \n" +
                "4-Araç Güncelle \n5-Araç Sil \n6-Kapat");
                choice = Console.ReadLine();
                switch (choice)
                {
                    //Tüm Araçları Getir
                    case "1": 
                        Console.Clear();
                        Console.WriteLine("Tüm Araçlar\n-------------------------------------------------------------------------------------------------------------");
                        var result = carManager.GetCarDetails();
                        if (result.Success)
                        {
                            foreach (var getCar in result.Data)
                            {
                                Console.WriteLine(
                                    " CarName: " + getCar.CarName +
                                    " BrandId: " + getCar.BrandName +
                                    " ColorId: " + getCar.ColorName +
                                    " DailyPrice: " + getCar.DailyPrice + "TL");
                            }
                        }
                        MainPageRoute();
                        break;

                    //Id'ye Göre Getir
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Getirmek istediğiniz aracın id'sini giriniz");
                        int id = Convert.ToInt32(Console.ReadLine());
                        CheckToGetById(carManager, id);
                        break;

                    //Araç Ekle
                    case "3":
                        Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır\nAraba günlük fiyatı 0'dan büyük olmalıdır.");
                        Console.WriteLine("Eklemek istediğiniz aracın bilgilerini eksiksiz doldurun");
                        Car carToAdded = new Car();
                        CarVariable(carToAdded);
                        var addResult = carManager.Add(carToAdded);
                        if (addResult.Success)
                        {
                            Console.WriteLine(addResult.Message);
                            Rental newCar = new Rental();
                            newCar.CarId = carToAdded.Id;
                            newCar.RentDate = null;
                            newCar.ReturnDate = null;
                            newCar.CustomerId = null;
                            rentalManager.Add(newCar);
                            MainPageRoute();
                        }
                        else
                        {
                            Console.WriteLine(addResult.Message);
                            MainPageRoute();
                        }
                        
                        break;

                    //Araç Güncelle
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Güncellemek istediğiniz arabanın id'sini giriniz:");
                        int idUpdate = Convert.ToInt32(Console.ReadLine());
                        CheckToUpdate(carManager, idUpdate);
                        break;

                    //Araç Sil
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Silmek istediğiniz arabanın id'sini giriniz:");
                        int idDelete;
                        idDelete = Convert.ToInt32(Console.ReadLine());
                        AracıGetir(carManager, idDelete);
                        Car car = carManager.GetById(idDelete).Data;
                        Car deletedCar = new Car {
                            Id = car.Id,
                            CarName = car.CarName,
                            DailyPrice = car.DailyPrice,
                            BrandId = car.BrandId,
                            ColorId = car.ColorId,
                            Description = car.Description,
                            ModelYear = car.ModelYear
                };
                        
                        Console.WriteLine("Silmek istediğinize eminmisiniz? (EVET/HAYIR)");
                        if (Console.ReadLine().ToUpper() == "EVET")
                        {
                            carManager.Delete(deletedCar);
                            Console.WriteLine("Araç silindi.");
                            MainPageRoute();
                        }
                        else
                        {
                            MainPageRoute();
                        }
                        break;
                }
                Console.Clear();
            }
        }
        private static void CheckToGetById(CarManager carManager, int id)
        {
            if (carManager.CheckList(id).Success)
            {
                AracıGetir(carManager, id);
                MainPageRoute();
            }
            else
            {
                Console.WriteLine("Veritabanında olan bir id yazınız");
                Console.WriteLine("Getirmek istediğiniz aracın id'sini giriniz");
                int getById = Convert.ToInt32(Console.ReadLine());
                CheckToGetById(carManager, getById);
            }
        }

        private static void CheckToUpdate(CarManager carManager, int idUpdate)
        {
            if (carManager.CheckList(idUpdate).Success)
            {
                AracıGetir(carManager, idUpdate);
                Console.WriteLine("Güncellemek istediğiniz aracın bilgilerini eksiksiz doldurun");
                Car carToUpdate = new Car();
                carToUpdate.Id = idUpdate;
                CarVariable(carToUpdate);
                carManager.Update(carToUpdate);
                MainPageRoute();
            }
            else
            {
                Console.WriteLine("Veritabanında olan bir id yazınız");
                Console.WriteLine("Güncellemek istediğiniz arabanın id'sini giriniz:");
                int id = Convert.ToInt32(Console.ReadLine());
                CheckToUpdate(carManager , id);
            }
        }

        private static void CarVariable(Car car)
        {
            Console.WriteLine("CarName: ");
            car.CarName = Console.ReadLine();
            Console.WriteLine("BrandId: ");
            car.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ColorId: ");
            car.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ModelYear: ");
            car.ModelYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("DailyPrice: ");
            car.DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Description: ");
            car.Description = Console.ReadLine();
        }

        private static void MainPageRoute()
        {
            Console.WriteLine("Ana sayfaya dönmek için herhangi bir tuşa basınız");
            Console.ReadLine();
            Console.Clear();
        }

        private static void AracıGetir(CarManager carManager, int id)
        {
            Car car = carManager.GetById(id).Data;
            Console.WriteLine("Id: " + car.Id +
                " CarName: " + car.CarName +
                " BrandId: " + car.BrandId +
                " ColorId: " + car.ColorId +
                " ModelYear: " + car.ModelYear +
                " DailyPrice: " + car.DailyPrice + "TL" +
                " Description: " + car.Description);
            
        }
    }
}
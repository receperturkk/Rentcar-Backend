using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string Listed = "Listelendi";
        public static string CarAdded = "Araba eklendi";
        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalReturnDateNotNull = "Araba kiralanmış";
        public static string CarNameInvalid = "Car name is invalid";
        public static string MaintenanceTime = "System in maintenance";
        public static string CarsListed = "Cars listed";
        public static string ColorsListed = "Colors listed";
        public static string CarDeleted = "Car deleted";
        public static string CarUpdated = "Car updated";
        public static string BrandsListed = "Brands Listed";
        public static string CarImagesAdded = "Araba resmi eklendi";
        public static string CarImagesUpdated = "Araba resmi güncellendi";
        public static string CarImagesDeleted = "Araba resmi silindi";
        public static string CheckIfCarImagesCarLimit = "Bir araba için en fazla 5 resim eklenebilir";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string ExistRental = "Kiralamalar tablosuna önceden eklenmiş";
    }
}

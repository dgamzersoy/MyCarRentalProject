using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
  public static  class Message
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarListed = " Arabalar Listelendi";
        public static string CarInValid = "Geçersiz giriş";
        public static string MaintanenceTime = "Sistem kapandı";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string ColorUpdated = "Renk GÜNCELLENDİ";
        public static string ColorAdded = "Renk Eklendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "mÜşteri silindi";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi";
        public static string CarRental = "Araba kiralandı";
        public static string CarRentalUpdated = "Satış Güncellendi";
        public static string CarRentalDeleted = "satış silindi";
        public static string CarRentalInValid = "Araba yok";

        public static string CarImageAdded = "Araba fotoğrafı eklendi";
        public static string CarImageDeleted = "Araba fotoğrafı silindi";
        public static string UserNotFound = "Kullanıcı bulamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı ";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "AccessTokenCreated";
        public static string NoCar = "NoCar";

        public static string MaintenanceTime= "Zaman doldu";

        public static string Success = "Başarılı";

        public static string UserRegistered = "kullanıcı kayıtlı";

        public static string AuthorizationDenied = " ";

        public static string CarImageUpdated = "Arabanın fotoğrafı güncellendi";
        public static string CarImageError = "Beşten fazla araba fotoğrafı girilemez";

        public static string CarNameAlreadyExists = "Zaten bu isimde araba eklendi";

        public static string CarCountOfBrandError = "En fazla 200 ürün bulunabilir.";
        public static string userAdded = "Kullanıcı Eklendi";
        public static string InvalidDate = "InvalidDate";
        public static string NoCustomer = "NoCustomer";
    }
}

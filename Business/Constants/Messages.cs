using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    //new lemeden kullanabilmek için static yazdık
    //static == bu Class new lenemez
    {
        public static string CarDescriptionInValid = "Araba açıklaması geçersiz";
        public static string CarAdded = "araba eklendi";
        public static string MaintenanceTime = "sistem bakımda";
        public static string CarsListed = "arabalar listelendi";
        public static string CarUpdated = "araba güncellendi";
        public static string Added = "Eklendi";
        public static string Updated = "Güncellendi";
        public static string NameInValid = "İsim geçersiz";
        public static string Deleted = "Silindi";
        public static string Listed = "listelendi";
        public static string CarImageLimited = "araba resmi limitine ulaşıldı";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin = "giriş başarılı";
        public static string UserAlreadyExist = "kullanıcı zaten mevcut";
        public static string UserRegistered = "kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başrıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
    }
}

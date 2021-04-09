using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    //Mesajlar Class ı niye new lensin
    //Bu yüzden new lemeden kullanabilmek için static yazdık
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
    }
}

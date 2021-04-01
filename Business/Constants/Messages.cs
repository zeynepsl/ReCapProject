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
        internal static string CarAdded = "araba eklendi";
        internal static string MaintenanceTime = "sistem bakımda";
        internal static string CarsListed = "arabalar listelendi";
        internal static string CarUpdated = "araba güncellendi";
        internal static string Added = "Eklendi";
        internal static string Updated = "Güncellendi";
        internal static string NameInValid = "İsim geçersiz";
        internal static string Deleted = "Silindi";
    }
}

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UnitAdded ="Birim Eklendi";
        public static string UnitNameInvalid = "Birim ismi geçersiz";
        public static string MaintananceTime = "Sistem bakım zamanı";
        public static string UnitListed = "Birimler Listelendi ";
        public static string UnitDeleted = "Birim Silindi";
        public static string UnitUpdated = "Birim Güncellendi";
        public static string UnitNotFound = "Kayıt Bulunamadı";
        public static string CarCountOfBrandError = "Bu markaya eklenebilecek araç sayısı aşıldı";
        public static string CarDescriptionAlreadyExists = "Bu açıklamayla daha önce ekleme yapılmış";
        public static string BrandLimitExceded = "Daha fazla marka ekleyemezsiniz";
        public static string CarImageLimitExceded = "Bir aracın en fazla 5 resmi olabilir";
        public static string ImageAddedMsg = "Resim başarıyla yüklendi";
        public static string CarNameExists = "Bu Araç isminden vardır.";
    }
}

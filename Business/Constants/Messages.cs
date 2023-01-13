using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    //static yapma sebebimiz  sürekli newleme gerek olmadığı için/ 
    public static class Messages
    {
        #region DailyRecordMessage
        public static string DailyRecordAdded = "Kayit Eklendi";
        public static string DailyRecordDelete = "Kayit Silindi";
        public static string DailyRecordUpdate = "Kayıt güncellendi";


        public static string DailyRecordAddedInvalid = "Kayit Eklenemedi";
        public static string DailyRecordDeleteInvalid = "Kayit silinemedi";
        public static string DailyRecordUpdateInvalid = "Kayıt güncellenemedi";

        public static string MaintenanceTime = "Sistem Bakımda";
        public static string DailyRecordListed = "Kayıtlar listelendi";

        public static string DailyRecordByIdList = "Kayıt listelendi";
        public static string DailyRecordByIdListInvalid = "Kayıt bulunamadı.";
        #endregion

        #region WorkingTypeMessage
        public static string WorkingTypeAdded = "Çalışma Kategorisi eklendi.";
        public static string WorkingTypeUpdated = "Çalışma Kategorisi güncellendi.";
        public static string WorkingTypeDeleted = "Çalışma Kategorisi silindi.";

        public static string WorkingTypeListed = " Çalışma Kategorisi Kayıtları listelendi.";
        public static string WorkingTypeByIdListed = "Çalışma Kategorisi Kaydı listelendi";

        public static string WorkingTypeByIdListedInvalid = "Çalışma Kategorisi Kaydı bulunamadı.";
        #endregion

        #region AppointmentTypeMessage
        public static string AppointmentTypeAdded = "Randevu Kategorisi eklendi.";
        public static string AppointmentTypeUpdated = "RandevuKategorisi güncellendi.";
        public static string AppointmentTypeDeleted = "Randevu Kategorisi silindi.";

        public static string AppointmentTypeListed = " Randevu Kategorisi Kayıtları listelendi.";
        public static string AppointmentTypeByIdListed = "Randevu Kategorisi Kaydı listelendi";

        public static string AppointmentTypeByIdListedInvalid = "Randevu Kategorisi Kaydı bulunamadı.";
        #endregion

        #region EmployeeMessage
        public static string EmployeeAdded = "Çalışan eklendi.";
        public static string EmployeeUpdated = "Çalışan güncellendi.";
        public static string EmployeeDeleted = "Çalışan silindi.";

        public static string EmployeeListed = "Çalışan Kayıtları listelendi.";
        public static string EmployeeByIdListed = "Çalışan Kaydı listelendi";

        public static string EmployeeByIdListedInvalid = "Çalışan Kaydı bulunamadı.";

        public static string EmployeeTheSameNameSurnameAddedInvalid = "Aynı isim ve soyisimde Çalışan eklenemez";
        #endregion

        #region AppointmentMessage
        public static string AppointmentAdded = "Randevu eklendi.";
        public static string AppointmentUpdated = "Randevu  güncellendi.";
        public static string AppointmentDeleted = "Randevu  silindi.";

        public static string AppointmentListed = "Randevu  Kayıtları listelendi.";
        public static string AppointmentByIdListed = "Randevu  Kaydı listelendi";

        public static string AppointmentByIdListedInvalid = "Randevu Kaydı bulunamadı.";
        #endregion

        #region EmployeeWorkMessage
        public static string EmployeeWorkAdded = "Çalışan randevu için atandı.";
        public static string EmployeeWorkUpdated = "Çalışan randevu için güncellendi.";
        public static string EmployeeWorkDeleted = "Çalışan randevu için silindi.";

        public static string EmployeeWorkListed = "Çalışan Randevu  Kayıtları listelendi.";
        public static string EmployeeWorkByIdListed = "Çalışan Randevu  Kaydı listelendi";

        public static string EmployeeWorkByIdListedInvalid = "Çalışan Randevu Kaydı bulunamadı.";
        #endregion

        #region AppointmentDateMessage
        public static string AppointmentDateAdded = "Randevu için Tarih atandı.";
        public static string AppointmentDateUpdated = "Randevu için Tarih güncellendi.";
        public static string AppointmentDateDeleted = "Randevu için Tarih silindi.";

        public static string AppointmentDateListed = "Randevu için Tarih Kayıtları listelendi.";
        public static string AppointmentDateByIdListed = "Randevu için Tarih Kaydı listelendi";

        public static string AppointmentDateByIdListedInvalid = "Randevu için Tarih Kaydı bulunamadı.";

        public static string InvalidAppointmentDate = "Bu gün için 3 den fazla çekim olduğu için ve Price 1000 tl altında olduğu için randevu alınamaz.";

        #endregion

        public static string AuthorizationDenied="Access Denied";
    }
}

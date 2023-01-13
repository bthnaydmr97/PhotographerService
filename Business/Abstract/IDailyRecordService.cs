using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDailyRecordService
    {
        // IDATAREsult yapı yaparsak hem datayı döndüğrüpü hem de sonuç mesajını döndüren generic yapı oluşturabiliriz. Böylelikle GetAll sınıfı List<DailyRecord> sorununu hallederiz.
        IResult Add(DailyRecord record);
        IResult Update(DailyRecord record);
        IResult Delete(DailyRecord record);
        IDataResult<List<DailyRecord>> GetAll();
        IDataResult<DailyRecord> GetDailyRecordById(int id);
        IResult AddTransactionalTest(DailyRecord record);

        //double GetAllSumPrice();
        //List<DailyRecord> GetByDates(DateTime date, int addDate, string filterDate);
        ////List<DailyRecord> GetByDates(DateTime date, int addDate, string filterDate);
        //double GetSumPriceWithDates(DateTime date);
        //double GetSumPriceByDate(DateTime date);
        //DailyRecord GetAllIsPaid(bool isPaid);
        //DailyRecord GetIsPaidWithDates(DateTime date, bool isPaid);
        //DailyRecord GetIsPaidByDate(DateTime date, bool isPaid);

    }
}

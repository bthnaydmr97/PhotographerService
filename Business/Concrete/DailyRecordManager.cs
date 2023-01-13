using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Concrete
{
    public class DailyRecordManager : IDailyRecordService
    {
        private IDailyRecordDal _dailyRecordDal;
        //Bir EntityManager kendisi hariç başka bir dalı enjekte edemezdir. Ancak farklı bir servisi enjekte edebiliriz.
        public DailyRecordManager(IDailyRecordDal dailyRecordDal)
        {
            _dailyRecordDal = dailyRecordDal;
        }

        [SecuredOperation("dailyrecord.add,admin")]
        [ValidationAspect(typeof(DailyRecordValidator))]
        public IResult Add(DailyRecord record)
        {
            record.CreatedOn = DateTime.Now;
            _dailyRecordDal.Add(record);

            return new SuccessResult(Messages.DailyRecordAdded);
        }
        [ValidationAspect(typeof(DailyRecordValidator))]
        public IResult Delete(DailyRecord record)
        {
            _dailyRecordDal.Delete(record);

            return new SuccessResult(Messages.DailyRecordDelete);
        }

        [ValidationAspect(typeof(DailyRecordValidator))]
        [CacheRemoveAspect("IDailyRecordService.Get")]
        public IResult Update(DailyRecord record)
        {
            _dailyRecordDal.Update(record);

            return new SuccessResult(Messages.DailyRecordUpdate);
        }
        
        [CacheAspect]
        public IDataResult<List<DailyRecord>> GetAll()
        {
            return new SuccessDataResult<List<DailyRecord>>(_dailyRecordDal.GetAll(), Messages.DailyRecordListed);
        }

        [ValidationAspect(typeof(DailyRecordValidator))]
        [CacheAspect]
        public IDataResult<DailyRecord> GetDailyRecordById(int id)
        {
            var result = _dailyRecordDal.Get(d => d.Id == id);

            if (result == null)
                return new ErrorDataresult<DailyRecord>(Messages.DailyRecordByIdListInvalid);

            return new SuccessDataResult<DailyRecord>(_dailyRecordDal.Get(d => d.Id == id), Messages.DailyRecordByIdList);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(DailyRecord record)
        {
            //100 lira hesapta para var. 10 lira aktarma işlemi için Benim hesabımı 10 lira azaltıp update çekmesi diğer hesabı 10 lira ekleyip update etmesi gerekiyor. 
            //Ancak bu iki update işleminin ilkini yaptı ikincisinde sistem hata verdi. Yapılan tüm değişiklikleri geri almak için bunu kullanabiliriz.
            Add(record);
            if (record.Id < 10)
            {
                throw new Exception("");
            }
            
            Add(record);
            return null;
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppointmentDateManager : IAppointmentDateService
    {
        //Manager içine kendi dal ı hariç entegre edemeyiz. Ancak farklı bir service injection yapabilriz. Örnek olarak E devlet doğrulamasıonı bu proıjeye entegre istersek bu şekilde yazılır. 
        private IAppointmentDateDal _appointmentDateDal;
        private IAppointmentService _appointmentService;

        public AppointmentDateManager(IAppointmentDateDal appoinmentDate, IAppointmentService appointmentService)
        {
            _appointmentDateDal = appoinmentDate;
            _appointmentService = appointmentService;
        }
        [ValidationAspect(typeof(AppointmentDateValidator))]
        public IResult Add(AppoinmentDate appoinmentDate)
        {
            //Bu şekilde kullanım yapabilirim. İstediğim kadar parametre geçilebilir.
            //IResult result = BusinessRules.Run(CheckAppointmentDate(appoinmentDate.Date, appoinmentDate.AppoinmentId),CheckAppointmentDate(appoinmentDate.Date,appoinmentDate.AppoinmentId));
            IResult result = BusinessRules.Run(CheckAppointmentDate(appoinmentDate.Date, appoinmentDate.AppoinmentId));

            if (result != null)
                return result;

            _appointmentDateDal.Add(appoinmentDate);

            return new SuccessResult(Messages.DailyRecordAdded);
        }
        public IResult Delete(AppoinmentDate appoinmentDate)
        {
            _appointmentDateDal.Delete(appoinmentDate);

            return new SuccessResult(Messages.DailyRecordAdded);
        }
        public IResult Update(AppoinmentDate appoinmentDate)
        {
            _appointmentDateDal.Update(appoinmentDate);

            return new SuccessResult(Messages.DailyRecordAdded);
        }
        //Aynı tarih için Appo'ntmentId si 3 den byük olursa. Bu kadar fazla bir kişi için eklenemez hatası dönsün.
        private IResult CheckAppointmentDate(DateTime date, int appointmentId)
        {
            var count = _appointmentDateDal.GetAll(d => d.Date == date).Count;
            var price = _appointmentService.GetAppointmentById(appointmentId);
            if ((price.Data.Price < 1000) && (count > 3))
                return new ErrorResult(Messages.InvalidAppointmentDate);

            return new SuccessResult();

        }
        //public IDataResult<List<AppoinmentDate>> GetAll()
        //{
        //    if (DateTime.Now.Hour == 24)
        //    { 
        //        return new ErrorDataresult<List<AppoinmentDate>>(Messages.MaintenanceTime);
        //    }
        //    return new SuccessDataResult<List<AppoinmentDate>>(_appointmentDateDal.GetAll(), Messages.DailyRecordListed);
        //}
    }
}

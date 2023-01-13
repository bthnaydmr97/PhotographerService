using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class AppointmentManager : IAppointmentService
    {
        IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        [ValidationAspect(typeof(AppointmentValidator))]
        public IResult Add(Appointment appointment)
        {
            appointment.CreatedOn = DateTime.Now;
            _appointmentDal.Add(appointment);

            return new SuccessResult(Messages.AppointmentAdded);
        }


        public IResult Delete(Appointment appointment)
        {
            _appointmentDal.Delete(appointment);

            return new SuccessResult(Messages.AppointmentDeleted);
        }

        public IResult Update(Appointment appointment)
        {
            _appointmentDal.Update(appointment);

            return new SuccessResult(Messages.AppointmentUpdated);
        }
        public IDataResult<List<Appointment>> GetAll()
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(), Messages.AppointmentListed);
        }

        public IDataResult<Appointment> GetAppointmentById(int id)
        {
            var result = _appointmentDal.Get(a => a.Id == id);

            if (result == null)
            {
                return new ErrorDataresult<Appointment>(Messages.AppointmentByIdListedInvalid);
            }

            return new SuccessDataResult<Appointment>(Messages.AppointmentByIdListed);
        }
    }
}

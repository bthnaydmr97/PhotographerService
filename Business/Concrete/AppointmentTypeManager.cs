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
    public class AppointmentTypeManager : IAppointmentTypeService
    {
        private IAppointmentTypeDal _appointmentTypeDal;

        public AppointmentTypeManager(IAppointmentTypeDal appointmentTypeDal)
        {
            _appointmentTypeDal = appointmentTypeDal;
        }

        [ValidationAspect(typeof(AppointmentTypeValidator))]
        public IResult Add(AppointmentType appointmentType)
        {
            _appointmentTypeDal.Add(appointmentType);

            return new SuccessResult(Messages.AppointmentTypeAdded);
        }

        [ValidationAspect(typeof(AppointmentTypeValidator))]
        public IResult Delete(AppointmentType appointmentType)
        {
            _appointmentTypeDal.Delete(appointmentType);

            return new SuccessResult(Messages.AppointmentTypeDeleted);
        }

        [ValidationAspect(typeof(AppointmentTypeValidator))]
        public IResult Update(AppointmentType appointmentType)
        {
            _appointmentTypeDal.Update(appointmentType);

            return new SuccessResult(Messages.AppointmentTypeUpdated);
        }

        [ValidationAspect(typeof(AppointmentTypeValidator))]
        public IDataResult<List<AppointmentType>> GetAll()
        {
            return new SuccessDataResult<List<AppointmentType>>(_appointmentTypeDal.GetAll(), Messages.AppointmentTypeListed);
        }
    }
}

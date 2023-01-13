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
    public class WorkingTypeManager : IWorkingTypeService
    {
        IWorkingTypeDal _workingTypeDal;

        public WorkingTypeManager(IWorkingTypeDal workingTypeDal)
        {
            _workingTypeDal = workingTypeDal;
        }

        [ValidationAspect(typeof(WorkingTypeValidator))]
        public IResult Add(WorkingType workingType)
        {
            _workingTypeDal.Add(workingType);

            return new SuccessResult(Messages.WorkingTypeAdded);
        }

        [ValidationAspect(typeof(WorkingTypeValidator))]
        public IResult Delete(WorkingType workingType)
        {
            _workingTypeDal.Delete(workingType);

            return new SuccessResult(Messages.WorkingTypeDeleted);
        }

        [ValidationAspect(typeof(WorkingTypeValidator))]
        public IDataResult<List<WorkingType>> GetAll()
        {
            return new SuccessDataResult<List<WorkingType>>(_workingTypeDal.GetAll(), Messages.WorkingTypeListed);
        }

        [ValidationAspect(typeof(WorkingTypeValidator))]
        public IResult Update(WorkingType workingType)
        {
            _workingTypeDal.Update(workingType);

            return new SuccessResult(Messages.WorkingTypeUpdated);
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtoS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeWorkManager : IEmployeeWorkService
    {

        private IEmployeeWorkDal _employeeWorkDal;

        public EmployeeWorkManager(IEmployeeWorkDal employeeWorkDal)
        {
            _employeeWorkDal = employeeWorkDal;
        }

        [ValidationAspect(typeof(EmployeeWorkValidator))]
        public IResult Add(EmployeeWork employeeWork)
        {
            employeeWork.CreatedOn = DateTime.Now;
            _employeeWorkDal.Add(employeeWork);

            return new SuccessResult(Messages.EmployeeWorkAdded);
        }

        public IResult Delete(EmployeeWork employeeWork)
        {
            _employeeWorkDal.Delete(employeeWork);

            return new SuccessResult(Messages.EmployeeWorkDeleted);
        }

        public IDataResult<EmployeeWorkDetailDto> Get(int id)
        {
            var result = _employeeWorkDal.GetEmployeeWorkDetailsById(id);

            if (result == null)
            {
                return new ErrorDataresult<EmployeeWorkDetailDto>(Messages.EmployeeWorkByIdListedInvalid);
            }

            return new SuccessDataResult<EmployeeWorkDetailDto>(result, Messages.EmployeeWorkByIdListed);
        }

        public IDataResult<List<EmployeeWorkDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeWorkDetailDto>>(_employeeWorkDal.GetEmployeeWorkDetails(), Messages.EmployeeWorkListed);
        }

        public IResult Update(EmployeeWork employeeWork)
        {
            employeeWork.CreatedOn = DateTime.Now;
            _employeeWorkDal.Update(employeeWork);

            return new SuccessResult(Messages.EmployeeWorkUpdated);
        }
    }
}

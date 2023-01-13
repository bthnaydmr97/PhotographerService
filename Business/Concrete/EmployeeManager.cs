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
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Add(Employee employee)
        {
            IResult result = BusinessRules.Run(CheckIfNameSurnameExist(employee.Name, employee.Surname));

            if (result != null)
                return result;

            employee.CreatedOn = DateTime.Now;
            _employeeDal.Add(employee);

            return new SuccessResult(Messages.EmployeeAdded);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);

            return new SuccessResult(Messages.EmployeeDeleted);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Update(Employee employee)
        {
            employee.CreatedOn = DateTime.Now;
            _employeeDal.Update(employee);

            return new SuccessResult(Messages.EmployeeUpdated);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IDataResult<Employee> GetEmployeeById(int id)
        {
            var result = _employeeDal.Get(e => e.Id == id);

            if (result == null)
                return new ErrorDataresult<Employee>(Messages.EmployeeByIdListedInvalid);

            return new SuccessDataResult<Employee>(result, Messages.EmployeeByIdListed);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), Messages.EmployeeListed);
        }


        private IResult CheckIfNameSurnameExist(string name, string surname)
        {
            //Any ile de yapabiliriz. Data var mı yok mu kontrolü ile boolen
            var result = _employeeDal.GetAll(e => e.Name == name && e.Surname == surname).Count;
            if (result > 0)
            {
                return new ErrorResult(Messages.EmployeeTheSameNameSurnameAddedInvalid);
            }
            return new SuccessResult();
        }
    }
}

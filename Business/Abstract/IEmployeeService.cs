using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(Employee record);
        IResult Update(Employee record);
        IResult Delete(Employee record);
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetEmployeeById(int id);
    }
}

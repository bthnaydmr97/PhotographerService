using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DtoS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeWorkService
    {
        IResult Add(EmployeeWork employeeWork);
        IResult Update(EmployeeWork employeeWork);
        IResult Delete(EmployeeWork employeeWork);
        IDataResult<List<EmployeeWorkDetailDto>> GetAll();
        IDataResult<EmployeeWorkDetailDto> Get(int id);
    }
}

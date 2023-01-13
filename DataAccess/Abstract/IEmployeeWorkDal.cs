using Core;
using Entities.Concrete;
using Entities.DtoS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeWorkDal : IEntityRepository<EmployeeWork>
    {
        List<EmployeeWorkDetailDto> GetEmployeeWorkDetails();

        EmployeeWorkDetailDto GetEmployeeWorkDetailsById(int id);
    }
}

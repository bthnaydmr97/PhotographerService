using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppointmentDateService
    {
        IResult Add(AppoinmentDate record);
        IResult Update(AppoinmentDate record);
        IResult Delete(AppoinmentDate record);

        //DTO yapılacak Aynı employeede ki gibi.
        //IDataResult<List<AppoinmentDate>> GetAll();
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppointmentTypeService
    {
        IResult Add(AppointmentType record);
        IResult Update(AppointmentType record);
        IResult Delete(AppointmentType record);
        IDataResult<List<AppointmentType>> GetAll();

    }
}

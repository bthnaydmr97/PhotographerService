using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        //Crud
        IResult Add(Appointment record);
        IResult Update(Appointment record);
        IResult Delete(Appointment record);
        IDataResult<List<Appointment>> GetAll();
        IDataResult<Appointment> GetAppointmentById(int id);
    }
}

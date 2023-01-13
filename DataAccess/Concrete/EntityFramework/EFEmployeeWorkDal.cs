using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtoS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFEmployeeWorkDal : EntityRepositoryBase<EmployeeWork, PhotographerContext>, IEmployeeWorkDal
    {
        public List<EmployeeWorkDetailDto> GetEmployeeWorkDetails()
        {
            using (PhotographerContext context = new PhotographerContext())
            {
                var result = from e in context.EmployeeWorks
                             join emp in context.Employees on e.EmployeeId equals emp.Id
                             join w in context.WorkingTypes on e.TypeId equals w.Id
                             join a in context.Appointments on e.AppointmentId equals a.Id
                             join ad in context.AppoinmentDates on a.Id equals ad.AppoinmentId
                             join apt in context.AppointmentTypes on ad.AppointmentTypeId equals apt.Id
                             select new EmployeeWorkDetailDto
                             {
                                 Date = ad.Date,
                                 Price = e.Price,
                                 PhoneNumber = emp.PhoneNumber,
                                 NameSurname = emp.Name + " " + emp.Surname,
                                 AppointmentAdress = a.Adress,
                                 AppointmentDescription = a.Description,
                                 WorkingType = w.Type,
                                 AppointmentTypes = apt.Type
                             };

                return result.ToList();
            }
        }

        public EmployeeWorkDetailDto GetEmployeeWorkDetailsById(int id)
        {
            using (PhotographerContext context = new PhotographerContext())
            {
                var result = from e in context.EmployeeWorks
                             where e.Id == id
                             join emp in context.Employees on e.EmployeeId equals emp.Id
                             join w in context.WorkingTypes on e.TypeId equals w.Id
                             join a in context.Appointments on e.AppointmentId equals a.Id
                             join ad in context.AppoinmentDates on a.Id equals ad.AppoinmentId
                             join apt in context.AppointmentTypes on ad.AppointmentTypeId equals apt.Id
                             select new EmployeeWorkDetailDto
                             {
                                 Date = ad.Date,
                                 Price = e.Price,
                                 PhoneNumber = emp.PhoneNumber,
                                 NameSurname = emp.Name + " " + emp.Surname,
                                 AppointmentAdress = a.Adress,
                                 AppointmentDescription = a.Description,
                                 WorkingType = w.Type,
                                 AppointmentTypes = apt.Type
                             };

                return result.SingleOrDefault();
            }
        }
    }
}

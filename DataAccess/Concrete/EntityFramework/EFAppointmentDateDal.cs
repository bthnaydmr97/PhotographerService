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
    public class EFAppointmentDateDal : EntityRepositoryBase<AppoinmentDate, PhotographerContext>, IAppointmentDateDal
    {
        public List<AppointmentDetailDto> GetAppointmentDateDetails()
        {
            using (PhotographerContext context = new PhotographerContext())
            {
                var result = from ad in context.AppoinmentDates
                             join a in context.Appointments on ad.AppoinmentId equals a.Id
                             join at in context.AppointmentTypes on ad.AppointmentTypeId equals at.Id
                             select new AppointmentDetailDto
                             {
                                 Date = ad.Date,
                                 NameSurname = a.Name + " " + a.Surname,
                                 PhoneNumber = a.PhoneNumber,
                                 AppointmentDescription = a.Description,
                                 Price = a.Price,
                                 AppointmentType = at.Type
                             };

                return result.ToList();
            }
        }

        public AppointmentDetailDto GetAppointmentDateDetailsById(int id)
        {
            using (PhotographerContext context = new PhotographerContext())
            {
                var result = from ad in context.AppoinmentDates
                             where ad.Id == id
                             join a in context.Appointments on ad.AppoinmentId equals a.Id
                             join at in context.AppointmentTypes on ad.AppointmentTypeId equals at.Id
                             select new AppointmentDetailDto
                             {
                                 Date = ad.Date,
                                 NameSurname = a.Name + " " + a.Surname,
                                 PhoneNumber = a.PhoneNumber,
                                 AppointmentDescription = a.Description,
                                 Price = a.Price,
                                 AppointmentType = at.Type
                             };

                return result.SingleOrDefault();
            }
        }
    }
}

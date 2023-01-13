using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DtoS
{
    public class AppointmentDetailDto : IDto
    {
        public DateTime Date { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string AppointmentDescription { get; set; }
        public string AppointmentAdress { get; set; }
        public double Price { get; set; }
        public string AppointmentType { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DtoS
{
    public class EmployeeWorkDetailDto : IDto
    {
        //DTO ile inner join yapıp farklı tabloları birleştirip Client gösterme işlemi yapacağız .
        public DateTime Date { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public double Price { get; set; }
        public string WorkingType { get; set; }
        public string AppointmentAdress { get; set; }
        public string AppointmentDescription { get; set; }
        public string AppointmentTypes { get; set; }

    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeWork : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int AppointmentId { get; set; }
        public int TypeId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}

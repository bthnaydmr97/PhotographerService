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
    public class DailyRecord : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

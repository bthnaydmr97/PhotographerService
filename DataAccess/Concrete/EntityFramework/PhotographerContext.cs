using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Db tabloları ile proje classlarına bağlamak.
    public class PhotographerContext : DbContext
    {   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8NDAKUE\SQLEXPRESS;Database=PhotographerDB;Integrated Security=SSPI");
        }
       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeWork> EmployeeWorks { get; set; }
        public DbSet<WorkingType> WorkingTypes { get; set; }
        public DbSet<DailyRecord> DailyRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppoinmentDate> AppoinmentDates { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Appointment>().HasData(
        //        new Appointment
        //        {
        //            UserId = 1,
        //            Barber = Barber.Steveo,
        //            //AppointmentDateTime = Convert.ToDateTime(05 - 29 - 2015),
        //            ServiceRequested = Service.MilitaryCut,
        //            Comments = "I need to be in and out quick , I have a meeting to get to",
        //            AppointmentId = 1
        //        }
        //        );
        //}

    }
}

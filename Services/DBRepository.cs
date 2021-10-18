using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Models;

namespace BarberShop.Services
{
    public class DBRepository : IRepository
    {//TODO ADD DB CONTEXT 
        private ApplicationDbContext ApplicationDbContext; //variable of Database
        public DBRepository(ApplicationDbContext context)
        {//initialize prdloyecontext when this is called
            ApplicationDbContext = context;
        }
        public Appointment AddAppointment(Appointment p)
        {
            //add MAX LOGIC FOR GETTING ID 
            //p.AppointmentId = ApplicationDbContext.Appointments.Max(p => p.UserId) + 1;
            ApplicationDbContext.Appointments.Add(p);
            ApplicationDbContext.SaveChanges();
            return p;
        }

        public Appointment DeleteAppointment(int id)
        {
            Appointment prd = ApplicationDbContext.Appointments.FirstOrDefault(e => e.AppointmentId == id); //selecting the Appointment tthat we selecting
            if (prd != null)
            {//if its not null then remove from list
                ApplicationDbContext.Appointments.Remove(prd);
                ApplicationDbContext.SaveChanges();
            }
            return prd;
        }

        public Appointment GetAppointment(int id)
        {
            return ApplicationDbContext.Appointments.FirstOrDefault(p => p.AppointmentId == id); //selecting the Appointment tthat we selecting/getting reference then returning it back 
        }

        public IEnumerable<Appointment> GetAppointment()
        {
            return ApplicationDbContext.Appointments.ToList(); //returning the Appointments so need to get it as a list
        }

        public Appointment UpdateAppointment(Appointment appchanges)
        {
            Appointment prd = ApplicationDbContext.Appointments.FirstOrDefault(e => e.AppointmentId == appchanges.AppointmentId); //selecting the Appointment tthat we updating by both id
            if (prd != null)
            {//assigning what is in the appchanges to the current prd
                prd.Barber = appchanges.Barber;
                prd.ServiceRequested = appchanges.ServiceRequested;
                prd.AppointmentDateTime = appchanges.AppointmentDateTime;
                prd.Comments = appchanges.Comments;

                ApplicationDbContext.SaveChanges();

            }
            return prd;
        }
        
    }
}

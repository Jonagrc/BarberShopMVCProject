using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Models;

namespace BarberShop.Services
{
    public interface IRepository
    {
        public Appointment GetAppointment(int id);//returns 1 Appointment found with id
        public IEnumerable<Appointment> GetAppointment();//this give you list of all meployees
        public Appointment AddAppointment(Appointment p);//adding an Appointment
        public Appointment UpdateAppointment(Appointment appchanges);//any changes you made will be reflected
        public Appointment DeleteAppointment(int id);//want to have a reference to show the user to what Appointment you deleted but might not use this returned Appointment
        // still performing the function of deleting a Appointment
       // public IEnumerable<Enum> GetBarbers();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BarberShop.Models;

namespace BarberShop.ViewModel
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public Barber Barber { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public Service ServiceRequesting { get; set; }
        public string Comments { get; set; }


    }
}


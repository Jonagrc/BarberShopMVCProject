using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Models
{
    public enum Barber
    {
        Steveo,
        Johnio,
        Hungo,
        Nathano,
        Juano,
        Json,
        Christo

    }
    public enum Service
    {
        RegularHaircut,
        MilitaryCut,
        BeardTrim,
        HaircutandBeard,
        KidsHaircut,
        MensShapeUp,
        KidsShapeUp,
        MobileCuts

    }

    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public Barber Barber { get; set; }
        public DateTime AppointmentDateTime { get;set; }
        public Service ServiceRequested { get; set; }
        public string Comments { get; set; }
        //public string Id { get; set; } //foriegn key
        public int UserId { get; set; } //relates to user 
    }
}

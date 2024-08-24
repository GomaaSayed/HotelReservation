
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Reservation> Reservations { get; set; }
        [NotMapped]
        public string Password { get; set; }
    }
}

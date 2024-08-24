using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Entities
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        public int NO { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public Guid FloorId { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}

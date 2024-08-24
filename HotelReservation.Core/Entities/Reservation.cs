using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.Entities
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        public int NO { get; set; }
        [ForeignKey("RoomId")]
        public Guid RoomId { get; set; }
        public Room room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User user { get; set; }
        public int NumberOfDayes { get; set; }

        public bool IsCompleted { get; set; }
        public decimal TotalPrice { get; set; }
        public string ReservationStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}

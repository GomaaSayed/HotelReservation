using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.DTOs
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public Guid FloorId { get; set; }
    }
}

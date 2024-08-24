using HotelReservation.Core.Entities;
using HotelReservation.Core.IRepositories;
using HotelReservation.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(HotelReservationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByRoomIdAsync(Guid Id, Guid RoomId)
        {
            return await _context.Reservations.Where(s => s.RoomId == RoomId && s.Id != Id).ToListAsync();
        }
    }
}

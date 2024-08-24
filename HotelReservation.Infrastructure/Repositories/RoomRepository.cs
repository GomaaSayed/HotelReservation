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
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelReservationDbContext context) : base(context)
        {
        }

    


    }
}

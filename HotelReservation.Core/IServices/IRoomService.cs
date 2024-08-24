using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.IServices
{
    public interface IRoomService
    {

        Task<string> AddRoomAsync(Room Room);
        Task<string> DeleteRoomAsync(Guid Id);
        Task<string> EditRoomRoomAsync(Room Room);
        Task<IEnumerable<Room>> GetAllRoomsAsync();

    }
}

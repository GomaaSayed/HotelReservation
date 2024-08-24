
using HotelReservation.Core.Entities;
using HotelReservation.Core.IRepositories;
using HotelReservation.Core.IServices;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<string> AddRoomAsync(Room Room)
        {
            string Msg = "";
            try
            {
                await _roomRepository.AddAsync(Room);
                Msg = "OK";
            }
            catch (Exception ex)
            {
                Msg = "Oops! There was an error processing your request. Please try again.";


            }
            return Msg;

        }

        public async Task<string> DeleteRoomAsync(Guid Id)
        {
            string Msg = "";
            try
            {
                var room = new Room { Id = Id };
                await _roomRepository.DeleteAsync(room);
                Msg = "OK";
            }
            catch (Exception ex)
            {
                Msg = "Oops! There was an error processing your request. Please try again.";
            }
            return Msg;
        }

        public async Task<string> EditRoomRoomAsync(Room Room)
        {
            string Msg = "";
            try
            {
                var OldRoom = await _roomRepository.GetByIdAsync(Room.Id);
                OldRoom.Capacity = Room.Capacity;
                OldRoom.Price = Room.Price;
                OldRoom.FloorId = Room.FloorId;
                await _roomRepository.UpdateAsync(OldRoom);
                Msg = "OK";
            }
            catch (Exception ex)
            {
                Msg = "Oops! There was an error processing your request. Please try again.";

            }
            return Msg;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllAsync();
        }


    }
}

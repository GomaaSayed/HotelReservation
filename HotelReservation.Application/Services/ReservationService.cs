
using HotelReservation.Application.DTOs;
using HotelReservation.Core.Entities;
using HotelReservation.Core.IRepositories;
using HotelReservation.Core.IServices;

namespace HotelReservation.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;

        public ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsForUserAsync(string userId)
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return reservations.Where(r => r.UserId == userId);
        }

        public async Task<bool> IsRoomAvailableAsync(Guid roomId, Guid Id, DateTime startDate, DateTime endDate)
        {
            var existingReservations = await _reservationRepository.GetReservationsByRoomIdAsync(Id, roomId);

            foreach (var reservation in existingReservations)
            {

                if ((startDate < reservation.EndDate && endDate > reservation.StartDate) ||
                    (startDate >= reservation.StartDate && startDate <= reservation.EndDate) ||
                    (endDate >= reservation.StartDate && endDate <= reservation.EndDate))
                {
                    return false;
                }
            }

            return true;
        }


        public async Task<string> AddReservationAsync(Reservation reservation)
        {
            string Msg = "";
            try
            {
                if (await IsRoomAvailableAsync(reservation.RoomId, reservation.Id, reservation.StartDate, reservation.EndDate))
                {
                    await _reservationRepository.AddAsync(reservation);
                    Msg = "OK";

                }
                else
                    Msg = "Sorry, the room is not available for the selected dates. Please choose different dates or select another room.";
            }
            catch (Exception ex)
            {
                Msg = "Oops! There was an error processing your request. Please try again.";

            }
            return Msg;
        }
        public async Task<string> EditReservationAsync(Reservation reservation)
        {
            string Msg = "";
            try
            {
                if (await IsRoomAvailableAsync(reservation.RoomId, reservation.Id, reservation.StartDate, reservation.EndDate))
                {
                    var oldReservation = await _reservationRepository.GetByIdAsync(reservation.Id);
                    oldReservation.RoomId = reservation.RoomId;
                    oldReservation.StartDate = reservation.StartDate;
                    oldReservation.EndDate = reservation.EndDate;
                    oldReservation.IsCompleted = true;
                    oldReservation.Notes = reservation.Notes;
                    oldReservation.TotalPrice = reservation.TotalPrice;
                    oldReservation.UserId = reservation.UserId;
                    await _reservationRepository.UpdateAsync(oldReservation);
                    Msg = "OK";

                }
                else
                    Msg = "Sorry, the room is not available for the selected dates. Please choose different dates or select another room.";

            }
            catch (Exception ex)
            {
                Msg = "Oops! There was an error processing your request. Please try again.";


            }
            return Msg;
        }
        public async Task<string> DeleteReservationAsync(Guid Id)
        {
            string Msg = "";
            try
            {
                var Reservation = new Reservation { Id = Id };
                await _reservationRepository.DeleteAsync(Reservation);
                Msg = "OK";
            }
            catch (Exception ex)
            {
                Msg = "Oops! There was an error processing your request. Please try again.";
            }
            return Msg;
        }
    }
}

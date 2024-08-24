using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.IServices
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservationsForUserAsync(string userId);
        Task<string> AddReservationAsync(Reservation reservation);
        Task<string> DeleteReservationAsync(Guid Id);
        Task<string> EditReservationAsync(Reservation reservation);


    }
}


using HotelReservation.Application.DTOs;
using HotelReservation.Application.Services;
using HotelReservation.Application.Validators;
using HotelReservation.Core.Entities;
using HotelReservation.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace HotelReservationSystem.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("GetUserReservations/{userId}")]
        public async Task<IActionResult> GetUserReservations(string userId)
        {
            var reservations = await _reservationService.GetReservationsForUserAsync(userId);
            return Ok(reservations);
        }

        [HttpPost("CreateReservation")]
        public async Task<ActionResult> CreateReservation([FromBody] ReservationDto reservationDto)
        {
            var validator = new ReservationValidator();
            var validationResult = validator.Validate(reservationDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            Response<string> response = new Response<string>();
            TimeSpan difference = reservationDto.EndDate - reservationDto.StartDate;
            int daysCount = difference.Days == 0 ? 1 : difference.Days;
            var reservation = new Reservation
            {
                RoomId = reservationDto.RoomId,
                UserId = reservationDto.UserId,

                StartDate = reservationDto.StartDate,
                EndDate = reservationDto.EndDate,
                NumberOfDayes = daysCount,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsCompleted = reservationDto.IsCompleted,
                Notes = reservationDto.Notes,
                ReservationStatus = reservationDto.ReservationStatus,
                TotalPrice = reservationDto.TotalPrice,

            };
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var result = await _reservationService.AddReservationAsync(reservation);
            if (result == "OK")
            {
                response.Message = "Thank you, " + userName + "! Your reservation has been successfully added";
                response.Success = true;
                return Ok(response);
            }
            response.Success = false;
            response.Message = result;
            return StatusCode(500, response);

        }

        [HttpPost("EditReservation")]
        public async Task<ActionResult> EditReservation([FromBody] ReservationDto reservationDto)
        {
            var validator = new ReservationValidator();
            var validationResult = validator.Validate(reservationDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Response<string> response = new Response<string>();
            TimeSpan difference = reservationDto.EndDate - reservationDto.StartDate;
            int daysCount = difference.Days == 0 ? 1 : difference.Days;
            var reservation = new Reservation
            {
                Id = reservationDto.Id,
                RoomId = reservationDto.RoomId,
                UserId = reservationDto.UserId,

                StartDate = reservationDto.StartDate,
                EndDate = reservationDto.EndDate,
                NumberOfDayes = daysCount,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsCompleted = reservationDto.IsCompleted,
                Notes = reservationDto.Notes,
                ReservationStatus = reservationDto.ReservationStatus,
                TotalPrice = reservationDto.TotalPrice,

            };
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var result = await _reservationService.EditReservationAsync(reservation);
            if (result == "OK")
            {
                response.Message = "Thank you, " + userName + "! Your reservation has been successfully updated";
                response.Success = true;
                return Ok(response);
            }
            response.Success = false;
            response.Message = result;
            return StatusCode(500, response);

        }
        [HttpDelete("DeleteReservation/{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            Response<string> response = new Response<string>();
            var result = await _reservationService.DeleteReservationAsync(id);
            if (result == "OK")
            {
                response.Success = true;
                response.Message = "Reservation successfully deleted.";
                return Ok(response);
            }
            response.Success = false;
            response.Message = result;
            return StatusCode(500, response);


        }
    }
}

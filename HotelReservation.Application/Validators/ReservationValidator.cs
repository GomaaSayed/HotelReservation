using FluentValidation;
using HotelReservation.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationDto>
    {
        public ReservationValidator()
        {

            RuleFor(reservation => reservation.RoomId)
                .NotEmpty()
                .WithMessage("Room ID is required.");

            RuleFor(reservation => reservation.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Start date cannot be in the past.");


            RuleFor(reservation => reservation.EndDate)
                .GreaterThanOrEqualTo(reservation => reservation.StartDate)
                .WithMessage("End date must be after the start date.");


            RuleFor(reservation => reservation.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");


        
            RuleFor(reservation => reservation.TotalPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total price must be a non-negative value.");


            RuleFor(reservation => reservation.ReservationStatus)
                .NotEmpty()
                .WithMessage("Reservation status is required.");

            RuleFor(reservation => reservation.Notes)
                .MaximumLength(500)
                .WithMessage("Notes cannot exceed 500 characters.");
        }
    }
}

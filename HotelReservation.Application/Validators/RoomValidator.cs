using FluentValidation;
using HotelReservation.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.Validators
{
    public class RoomValidator : AbstractValidator<RoomDto>
    {
        public RoomValidator()
        {
            RuleFor(room => room.Capacity)
                .GreaterThan(0).WithMessage("Room capacity must be greater than 0.");
            RuleFor(room => room.Price)
                .GreaterThan(0).WithMessage("Room price must be greater than 0.");

        }
    }
}

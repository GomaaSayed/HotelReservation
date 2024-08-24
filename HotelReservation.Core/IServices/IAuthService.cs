using HotelReservation.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.IServices
{
    public interface IAuthService
    {

        Task<IdentityResult> RegisterAsync(User model);
        Task<string> LoginAsync(User model);

    }
}

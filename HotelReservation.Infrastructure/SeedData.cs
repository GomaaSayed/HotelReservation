using HotelReservation.Core.Entities;
using HotelReservation.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure
{
    public static class SeedData
    {
        public static void Initialize(HotelReservationDbContext context)
        {
          
            if (context.Users.Any() || context.Rooms.Any())
            {
                return;  
            }

          
            context.Users.AddRange(
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Email = "admin@example.com",
                    PasswordHash= "$2y$10$ilV.aRbqYw12TgpAv8wHROP4bLOv26LScNblQYigZXks3/0qc66VC" //Password= 1234@Admin

                }
            );

          
            context.Rooms.AddRange(
                new Room
                {
                    Id = Guid.NewGuid(),
                    Capacity = 2,
                    Price = 100.00m,
                    FloorId = Guid.NewGuid()
                },
                new Room
                {
                    Id = Guid.NewGuid(),
                    Capacity = 4,
                    Price = 150.00m,
                    FloorId = Guid.NewGuid()
                }
            );

            context.SaveChanges();
        }
    }

}

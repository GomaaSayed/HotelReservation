using Microsoft.EntityFrameworkCore;
using HotelReservation.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace HotelReservation.Infrastructure.Contexts
{
    public class HotelReservationDbContext : IdentityDbContext<User>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public HotelReservationDbContext(DbContextOptions<HotelReservationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Room>()
          .Property(r => r.NO)
          .ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Reservation>()
     .Property(r => r.NO)
     .ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(b => { b.ToTable("Users"); });
            modelBuilder.Entity<IdentityRole>(b => { b.ToTable("Roles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(b => { b.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("RoleClaims"); });
            modelBuilder.Entity<IdentityUserToken<string>>(b => { b.ToTable("UserTokens"); });
            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18, 4)");
            });
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.TotalPrice)
                      .HasColumnType("decimal(18, 4)");
            });

          
            modelBuilder.Entity<Room>().HasData(
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
                },
                new Room
                {
                    Id = Guid.NewGuid(),
              
                    Capacity = 3,
                    Price = 200.00m,
                    FloorId = Guid.NewGuid()
                }
            );

           
            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@1234"),
                    SecurityStamp = "admin_security_stamp",
                    ConcurrencyStamp = "admin_concurrency_stamp",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User@1234"),
                    SecurityStamp = "user_security_stamp",
                    ConcurrencyStamp = "user_concurrency_stamp",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
            );
        }

    }
}

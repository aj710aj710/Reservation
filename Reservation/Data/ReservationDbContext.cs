using Microsoft.EntityFrameworkCore;
using Reservation.Entity;

namespace Reservation.Entity

{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options): base(options)
        {
        }

        public DbSet<Reservation_1> Reservations { get; set; }
    }
}
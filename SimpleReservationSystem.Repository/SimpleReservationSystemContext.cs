namespace SimpleReservationSystem.Repository;

using SimpleReservationSystem.Model;
using Microsoft.EntityFrameworkCore;

public class SimpleReservationSystemContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public SimpleReservationSystemContext(DbContextOptions<SimpleReservationSystemContext> options) : base(options)
    {
    }
}
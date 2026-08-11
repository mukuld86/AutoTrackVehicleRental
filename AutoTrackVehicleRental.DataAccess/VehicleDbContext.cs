using Microsoft.EntityFrameworkCore;
using AutoTrackVehicleRental.DataAccess.Models;

namespace AutoTrackVehicleRental.DataAccess;

public class VehicleDbContext : DbContext
{
    public VehicleDbContext()
    {
    }
    public DbSet<Vehicle> Vehicles { get; set; }
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=MUKUL-PC\\SQLEXPRESS;Database=AutoTrackVehicleRentalDb;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
    }
}
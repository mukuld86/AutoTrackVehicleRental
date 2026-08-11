using AutoTrackVehicleRental.DataAccess.Interfaces;
using AutoTrackVehicleRental.DataAccess.Models;

namespace AutoTrackVehicleRental.DataAccess.Repositories;

public class Repository : IRepository
{
    private readonly VehicleDbContext _context;

    public Repository(VehicleDbContext context)
    {
        _context = context;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        _context.SaveChanges();
    }

    public List<Vehicle> ViewAllVehicles()
    {
        return _context.Vehicles.ToList();
    }

    public Vehicle GetVehicle(int vehicleId)
    {
        return _context.Vehicles
            .FirstOrDefault(v => v.VehicleId == vehicleId);
    }

    public void UpdateVehicle(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        _context.SaveChanges();
    }

    public void RemoveVehicle(int vehicleId)
    {
        var vehicle = GetVehicle(vehicleId);

        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }
    }

    public List<Vehicle> SearchVehicleByType(string type)
    {
        return _context.Vehicles
            .Where(v => v.Type == type)
            .ToList();
    }
}
using AutoTrackVehicleRental.DataAccess.Interfaces;
using AutoTrackVehicleRental.DataAccess.Models;
using AutoTrackVehicleRental.Services.Interfaces;

namespace AutoTrackVehicleRental.Services.Services;

public class VehicleService : IVehicleService
{
    private readonly IRepository _repository;

    public VehicleService(IRepository repository)
    {
        _repository = repository;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        _repository.AddVehicle(vehicle);
    }

    public List<Vehicle> ViewAllVehicles()
    {
        return _repository.ViewAllVehicles();
    }

    public Vehicle GetVehicle(int vehicleId)
    {
        return _repository.GetVehicle(vehicleId);
    }

    public void UpdateVehicle(Vehicle vehicle)
    {
        _repository.UpdateVehicle(vehicle);
    }

    public void RemoveVehicle(int vehicleId)
    {
        _repository.RemoveVehicle(vehicleId);
    }

    public List<Vehicle> SearchVehicleByType(string type)
    {
        return _repository.SearchVehicleByType(type);
    }
}
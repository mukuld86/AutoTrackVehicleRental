using AutoTrackVehicleRental.DataAccess.Models;

namespace AutoTrackVehicleRental.Services.Interfaces;

public interface IVehicleService
{
    void AddVehicle(Vehicle vehicle);

    List<Vehicle> ViewAllVehicles();

    Vehicle GetVehicle(int vehicleId);

    void UpdateVehicle(Vehicle vehicle);

    void RemoveVehicle(int vehicleId);

    List<Vehicle> SearchVehicleByType(string type);
}
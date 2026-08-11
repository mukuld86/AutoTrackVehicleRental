using Microsoft.AspNetCore.Mvc;
using AutoTrackVehicleRental.Services.Interfaces;
using AutoTrackVehicleRental.Web.Models;

namespace AutoTrackVehicleRental.Web.Controllers;

public class VehicleController : Controller
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }
    public IActionResult ViewAllVehicles()
    {
        try
        {
            var vehicles = _vehicleService.ViewAllVehicles();

            var vehicleViewModels = vehicles.Select(vehicle =>
                new VehicleViewModel
                {
                    VehicleId = vehicle.VehicleId,
                    VehicleName = vehicle.VehicleName,
                    Type = vehicle.Type,
                    AvailabilityStatus = vehicle.AvailabilityStatus,
                    DateOfRegistration = vehicle.DateOfRegistration
                }).ToList();

            return View(vehicleViewModels);
        }
        catch (Exception)
        {
            return View("Error");
        }
    }
    [HttpGet]
    public IActionResult AddVehicle()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddVehicle(VehicleViewModel vehicle)
    {
        if (!ModelState.IsValid)
        {
            return View(vehicle);
        }

        try
        {
            var dataVehicle = new AutoTrackVehicleRental.DataAccess.Models.Vehicle
            {
                VehicleName = vehicle.VehicleName,
                Type = vehicle.Type,
                AvailabilityStatus = vehicle.AvailabilityStatus,
                DateOfRegistration = vehicle.DateOfRegistration
            };

            _vehicleService.AddVehicle(dataVehicle);

            return RedirectToAction(nameof(ViewAllVehicles));
        }
        catch (Exception)
        {
            return View("Error");
        }
    }
    [HttpGet]
    public IActionResult UpdateVehicle(int vehicleId)
    {
        try
        {
            var vehicle = _vehicleService.GetVehicle(vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }

            var viewModel = new VehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                VehicleName = vehicle.VehicleName,
                Type = vehicle.Type,
                AvailabilityStatus = vehicle.AvailabilityStatus,
                DateOfRegistration = vehicle.DateOfRegistration
            };

            return View(viewModel);
        }
        catch (Exception)
        {
            return View("Error");
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateVehicle(VehicleViewModel vehicle)
    {
        if (!ModelState.IsValid)
        {
            return View(vehicle);
        }

        try
        {
            var dataVehicle = new AutoTrackVehicleRental.DataAccess.Models.Vehicle
            {
                VehicleId = vehicle.VehicleId,
                VehicleName = vehicle.VehicleName,
                Type = vehicle.Type,
                AvailabilityStatus = vehicle.AvailabilityStatus,
                DateOfRegistration = vehicle.DateOfRegistration
            };

            _vehicleService.UpdateVehicle(dataVehicle);

            return RedirectToAction(nameof(ViewAllVehicles));
        }
        catch (Exception)
        {
            return View("Error");
        }
    }
    [HttpGet]
    public IActionResult RemoveVehicle(int vehicleId)
    {
        try
        {
            var vehicle = _vehicleService.GetVehicle(vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }

            var viewModel = new VehicleViewModel
            {
                VehicleId = vehicle.VehicleId,
                VehicleName = vehicle.VehicleName,
                Type = vehicle.Type,
                AvailabilityStatus = vehicle.AvailabilityStatus,
                DateOfRegistration = vehicle.DateOfRegistration
            };

            return View(viewModel);
        }
        catch (Exception)
        {
            return View("Error");
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult RemoveVehicleConfirmed(int vehicleId)
    {
        try
        {
            _vehicleService.RemoveVehicle(vehicleId);

            return RedirectToAction(nameof(ViewAllVehicles));
        }
        catch (Exception)
        {
            return View("Error");
        }
    }
    [HttpPost]
    public IActionResult SearchVehicle(string type)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return RedirectToAction(nameof(ViewAllVehicles));
            }

            var vehicles = _vehicleService.SearchVehicleByType(type);

            var vehicleViewModels = vehicles.Select(vehicle =>
                new VehicleViewModel
                {
                    VehicleId = vehicle.VehicleId,
                    VehicleName = vehicle.VehicleName,
                    Type = vehicle.Type,
                    AvailabilityStatus = vehicle.AvailabilityStatus,
                    DateOfRegistration = vehicle.DateOfRegistration
                }).ToList();

            return View("ViewAllVehicles", vehicleViewModels);
        }
        catch (Exception)
        {
            return View("Error");
        }
    }
}
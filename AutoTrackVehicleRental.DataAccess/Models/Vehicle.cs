using System.ComponentModel.DataAnnotations;

namespace AutoTrackVehicleRental.DataAccess.Models;

public class Vehicle
{
    [Key]
    public int VehicleId { get; set; }

    [Required]
    [StringLength(40)]
    public string VehicleName { get; set; }

    [Required]
    [StringLength(30)]
    public string Type { get; set; }

    public bool AvailabilityStatus { get; set; }

    [Required]
    public DateTime DateOfRegistration { get; set; }
}
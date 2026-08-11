using System.ComponentModel.DataAnnotations;

namespace AutoTrackVehicleRental.Web.Models;

public class VehicleViewModel
{
    [Key]
    public int VehicleId { get; set; }

    [Required(ErrorMessage = "Vehicle name is required")]
    [StringLength(49, ErrorMessage = "Vehicle name must be less than 50 characters")]
    public string VehicleName { get; set; }

    [Required(ErrorMessage = "Vehicle type is required")]
    [StringLength(29, ErrorMessage = "Vehicle type must be less than 30 characters")]
    public string Type { get; set; }

    public bool AvailabilityStatus { get; set; }

    [Required(ErrorMessage = "Date of registration is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfRegistration { get; set; }
}
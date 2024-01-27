using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AirCraftName
{
    public class CreateAirCraftNameDto : IAirCraftNameDto
    {
        public int AirCraftNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? OverallLength { get; set; }
        public string? WingSpan { get; set; }
        public string? Height { get; set; }
        public string? MaxRange { get; set; }
        public string? Endurance { get; set; }
        public string? MaxTakeoffAndLandingWt { get; set; }
        public string? BasicOperatingWt { get; set; }
        public string? CruisingSpeed { get; set; }
        public string? FuelCapacity { get; set; }
        public string? Crew { get; set; }
        public int? AircraftStatus { get; set; }
        public string? MadeBy { get; set; }
        public string? Manufacturer { get; set; }
        public string? ManufacturerMobile { get; set; }
        public string? Email { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
        public int? MaintenenceState { get; set; } 

        public IFormFile? Photo { get; set; }
    }
}

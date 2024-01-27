namespace SchoolManagement.Application.DTOs.ServiceLifeTypes
{
    public class CreateServiceLifeTypeDto : IServiceLifeTypeDto
    {
        public int ServiceLifeTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}

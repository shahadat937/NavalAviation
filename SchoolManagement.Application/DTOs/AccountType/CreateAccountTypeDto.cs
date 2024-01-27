namespace SchoolManagement.Application.DTOs.AccountType
{
    public class CreateAccountTypeDto : IAccountTypeDto
    {
        public int AccountTypeId { get; set; }
        public string? AccoutType { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}

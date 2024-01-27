using MediatR;

namespace SchoolManagement.Application.Features.AccountTypes.Requests.Commands
{
    public class DeleteAccountTypeCommand : IRequest
    {
        public int AccountTypeId { get; set; }
    }
}

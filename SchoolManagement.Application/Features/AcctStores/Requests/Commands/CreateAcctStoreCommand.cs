using MediatR;
using SchoolManagement.Application.DTOs.AcctStores;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AcctStores.Requests.Commands
{
    public class CreateAcctStoreCommand : IRequest<BaseCommandResponse>
    {
        public CreateAcctStoreDto AcctStoreDto { get; set; }
    }
}

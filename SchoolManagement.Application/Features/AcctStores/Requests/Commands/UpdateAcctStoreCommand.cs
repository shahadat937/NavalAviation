using MediatR;
using SchoolManagement.Application.DTOs.AcctStores;

namespace SchoolManagement.Application.Features.AcctStores.Requests.Commands
{
    public class UpdateAcctStoreCommand : IRequest<Unit>
    { 
        public AcctStoreDto AcctStoreDto { get; set; }
    }
}

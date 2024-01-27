using MediatR;

namespace SchoolManagement.Application.Features.AcctStores.Requests.Commands
{
    public class DeleteAcctStoreCommand : IRequest
    {
        public int AcctStoreId { get; set; }
    }
} 

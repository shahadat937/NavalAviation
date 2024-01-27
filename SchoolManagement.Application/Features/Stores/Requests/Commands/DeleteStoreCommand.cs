using MediatR;

namespace SchoolManagement.Application.Features.Stores.Requests.Commands
{
    public class DeleteStoreCommand : IRequest
    {
        public int StoreId { get; set; }
    }
}

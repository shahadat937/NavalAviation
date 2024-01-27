using MediatR;
using SchoolManagement.Application.DTOs.Store;

namespace SchoolManagement.Application.Features.Stores.Requests.Commands
{
    public class UpdateStoreCommand : IRequest<Unit>
    {
        public StoreDto StoreDto { get; set; }
    }
}

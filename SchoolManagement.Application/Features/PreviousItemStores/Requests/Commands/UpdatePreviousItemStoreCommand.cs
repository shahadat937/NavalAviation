using MediatR;
using SchoolManagement.Application.DTOs.PreviousItemStore;

namespace SchoolManagement.Application.Features.PreviousItemStores.Requests.Commands
{
    public class UpdatePreviousItemStoreCommand : IRequest<Unit>
    { 
        public PreviousItemStoreDto PreviousItemStoreDto { get; set; }
    }
}
 
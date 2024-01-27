using MediatR;

namespace SchoolManagement.Application.Features.PreviousItemStores.Requests.Commands
{
    public class DeletePreviousItemStoreCommand : IRequest
    {
        public int PreviousItemStoreId { get; set; }
    }
} 

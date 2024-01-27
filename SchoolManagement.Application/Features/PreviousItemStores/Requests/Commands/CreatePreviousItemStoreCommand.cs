using MediatR;
using SchoolManagement.Application.DTOs.PreviousItemStore;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.PreviousItemStores.Requests.Commands
{
    public class CreatePreviousItemStoreCommand : IRequest<BaseCommandResponse>
    {
        public CreatePreviousItemStoreDto PreviousItemStoreDto { get; set; }
    }
}

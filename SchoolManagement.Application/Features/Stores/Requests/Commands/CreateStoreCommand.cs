using MediatR;
using SchoolManagement.Application.DTOs.Store;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Stores.Requests.Commands
{
    public class CreateStoreCommand : IRequest<BaseCommandResponse>
    {
        public CreateStoreDto StoreDto { get; set; }
    }
}

using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetAllStoreListofDocumentSpRequest : IRequest<object>
    {
        public int ItemStorId { get; set; }
    }
}

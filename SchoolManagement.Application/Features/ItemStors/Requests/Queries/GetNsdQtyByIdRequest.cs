using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetNsdQtyByIdRequest : IRequest<List<SelectedModel>> 
    {
        public int ItemStorId { get; set; }   
    }
}   

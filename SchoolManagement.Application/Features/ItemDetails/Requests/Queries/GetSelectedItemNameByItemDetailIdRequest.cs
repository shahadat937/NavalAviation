using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetSelectedItemNameByItemDetailIdRequest : IRequest<List<SelectedModel>>
    {
        public int ItemDetailId { get; set; }  
    }
}   
    
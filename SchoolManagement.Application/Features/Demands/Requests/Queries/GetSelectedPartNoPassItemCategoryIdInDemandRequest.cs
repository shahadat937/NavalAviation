using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetSelectedPartNoPassItemCategoryIdInDemandRequest : IRequest<List<SelectedModel>>
    {
        public int ItemDetailId { get; set; } 
    }
}   
   
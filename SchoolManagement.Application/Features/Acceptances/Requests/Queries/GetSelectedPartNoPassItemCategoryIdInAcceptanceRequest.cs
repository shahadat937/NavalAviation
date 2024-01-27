using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Queries
{
    public class GetSelectedPartNoPassItemCategoryIdInAcceptanceRequest : IRequest<List<SelectedModel>>
    {
        public int ItemDetailId { get; set; }
        //public int DemandId { get; set; }
    }
}   
   
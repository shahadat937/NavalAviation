using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Procurements.Requests.Queries
{
    public class GetSelectedPartNoPassItemCategoryIdInProcurementRequest : IRequest<List<SelectedModel>>
    {
        public int ItemDetailId { get; set; }
        //public int DemandId { get; set; }
    }
}   
   
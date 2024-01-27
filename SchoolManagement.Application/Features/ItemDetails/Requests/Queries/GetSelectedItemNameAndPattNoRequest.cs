using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetSelectedItemNameAndPattNoRequest : IRequest<List<SelectedModel>>
    {
    }
} 

using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AcctStores.Requests.Queries
{
    public class GetSelectedAcctStoreRequest : IRequest<List<SelectedModel>>
    {
    }
} 

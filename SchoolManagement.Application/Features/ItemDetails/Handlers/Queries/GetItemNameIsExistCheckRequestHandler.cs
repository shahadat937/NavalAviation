using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetItemNameIsExistCheckRequestHandler : IRequestHandler<GetItemNameIsExistCheckRequest, bool>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository; 
        public GetItemNameIsExistCheckRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository)
        {
            _ItemDetailRepository = ItemDetailRepository;
        }
          
        public async Task<bool> Handle(GetItemNameIsExistCheckRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemDetail> bookList = await _ItemDetailRepository.FilterAsync(x => x.IsActive);
            bool isExist = bookList.Any(x => x.NameOfItem == request.NameOfItem);
            if (isExist)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
      }
}

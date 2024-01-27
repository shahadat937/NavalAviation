using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Handlers.Queries
{
    public class GetSelectedShelfLifeCategoryRequestHandler : IRequestHandler<GetSelectedShelfLifeCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ShelfLifeCategory> _ShelfLifeCategoryRepository;


        public GetSelectedShelfLifeCategoryRequestHandler(ISchoolManagementRepository<ShelfLifeCategory> ShelfLifeCategoryRepository)
        {
            _ShelfLifeCategoryRepository = ShelfLifeCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedShelfLifeCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<ShelfLifeCategory> codeValues = await _ShelfLifeCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ShelfLifeCategoryId
            }).ToList();
            return selectModels;
        }
    }
}

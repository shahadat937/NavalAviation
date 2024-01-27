using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Manufactures.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Manufactures.Handlers.Queries
{
    public class GetSelectedManufactureRequestHandler : IRequestHandler<GetSelectedManufactureRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Manufacture> _ManufactureRepository;


        public GetSelectedManufactureRequestHandler(ISchoolManagementRepository<Manufacture> ManufactureRepository)
        {
            _ManufactureRepository = ManufactureRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedManufactureRequest request, CancellationToken cancellationToken)
        {
            ICollection<Manufacture> codeValues = await _ManufactureRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ManufactureId
            }).ToList();
            return selectModels;
        }
    }
}

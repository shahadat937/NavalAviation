using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Thanas.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Thanas.Handlers.Queries
{
    public class GetSelectedThanaByDistrictHandler : IRequestHandler<GetSelectedThanaByDistrictRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Thana> _ThanaRepository;

        public GetSelectedThanaByDistrictHandler(ISchoolManagementRepository<Thana> ThanaRepository)
        {
            _ThanaRepository = ThanaRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedThanaByDistrictRequest request, CancellationToken cancellationToken)
        {
            ICollection<Thana> Thanas = await _ThanaRepository.FilterAsync(x => x.DistrictId == request.DistrictId);
            List<SelectedModel> selectModels = Thanas.Select(x => new SelectedModel
            {
                Text = x.ThanaName,
                Value = x.ThanaId
            }).ToList();
            return selectModels;
        }
    }
}

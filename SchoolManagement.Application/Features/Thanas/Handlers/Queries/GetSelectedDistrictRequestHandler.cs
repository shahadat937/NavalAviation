using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Thanas.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Thanas.Handlers.Queries
{
    public class GetSelectedThanaRequestHandler : IRequestHandler<GetSelectedThanaRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Thana> _ThanaRepository;


        public GetSelectedThanaRequestHandler(ISchoolManagementRepository<Thana> ThanaRepository)
        {
            _ThanaRepository = ThanaRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedThanaRequest request, CancellationToken cancellationToken)
        {
            ICollection<Thana> codeValues = await _ThanaRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ThanaName,
                Value = x.ThanaId
            }).ToList();
            return selectModels;
        }
    }
}

using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Denos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Denos.Handlers.Queries
{
    public class GetSelectedDenoRequestHandler : IRequestHandler<GetSelectedDenoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Deno> _DenoRepository;


        public GetSelectedDenoRequestHandler(ISchoolManagementRepository<Deno> DenoRepository)
        {
            _DenoRepository = DenoRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDenoRequest request, CancellationToken cancellationToken)
        {
            ICollection<Deno> codeValues = await _DenoRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DenoId
            }).ToList();
            return selectModels;
        }
    }
}

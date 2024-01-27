using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FiscalYears.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.FiscalYears.Handlers.Queries
{
    public class GetSelectedFiscalYearRequestHandler : IRequestHandler<GetSelectedFiscalYearRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FiscalYear> _FiscalYearRepository;


        public GetSelectedFiscalYearRequestHandler(ISchoolManagementRepository<FiscalYear> FiscalYearRepository)
        {
            _FiscalYearRepository = FiscalYearRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFiscalYearRequest request, CancellationToken cancellationToken)
        {
            ICollection<FiscalYear> codeValues = await _FiscalYearRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.FiscalYearName,
                Value = x.FiscalYearId
            }).ToList();
            return selectModels;
        }
    }
}

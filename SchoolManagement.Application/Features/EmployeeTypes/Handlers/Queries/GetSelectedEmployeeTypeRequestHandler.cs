using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.EmployeeTypes.Handlers.Queries
{
    public class GetSelectedEmployeeTypeRequestHandler : IRequestHandler<GetSelectedEmployeeTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<EmployeeType> _EmployeeTypeRepository;


        public GetSelectedEmployeeTypeRequestHandler(ISchoolManagementRepository<EmployeeType> EmployeeTypeRepository)
        {
            _EmployeeTypeRepository = EmployeeTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedEmployeeTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<EmployeeType> codeValues = await _EmployeeTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.EmployeeTypeId
            }).ToList();
            return selectModels;
        }
    }
}

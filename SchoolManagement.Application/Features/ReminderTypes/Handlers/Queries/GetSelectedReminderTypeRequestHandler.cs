using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ReminderTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ReminderTypes.Handlers.Queries
{
    public class GetSelectedReminderTypeRequestHandler : IRequestHandler<GetSelectedReminderTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ReminderType> _ReminderTypeRepository;


        public GetSelectedReminderTypeRequestHandler(ISchoolManagementRepository<ReminderType> ReminderTypeRepository)
        {
            _ReminderTypeRepository = ReminderTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedReminderTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ReminderType> codeValues = await _ReminderTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ReminderTypeId
            }).ToList();
            return selectModels;
        }
    }
}

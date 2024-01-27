using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Handlers.Queries
{
    public class GetSelectedMeaBlankFormatRequestHandler : IRequestHandler<GetSelectedMeaBlankFormatRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MeaBlankFormat> _MeaBlankFormatRepository;


        public GetSelectedMeaBlankFormatRequestHandler(ISchoolManagementRepository<MeaBlankFormat> MeaBlankFormatRepository)
        {
            _MeaBlankFormatRepository = MeaBlankFormatRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMeaBlankFormatRequest request, CancellationToken cancellationToken)
        {
            ICollection<MeaBlankFormat> codeValues = await _MeaBlankFormatRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.MeaBlankFormatId
            }).ToList();
            return selectModels;
        }
    }
}

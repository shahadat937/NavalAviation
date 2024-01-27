using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    //public class GetItemNameFromItemStoreRequestHandler : IRequestHandler<GetSubjectNameFromClassRoutineRequest, List<SelectedModel>>
    //{
    //    private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;

           
    //    public GetItemNameFromItemStoreRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository)
    //    {
    //        _ItemStorRepository = ItemStorRepository;    
    //    }

        //public async Task<List<SelectedModel>> Handle(GetSubjectNameFromClassRoutineRequest request, CancellationToken cancellationToken)
        //{
        //    IQueryable<ItemStor> itemStors = _ItemStorRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && (!x.Date.HasValue || x.Date.Value.Date == request.Date && x.ClassPeriodId == request.ClassPeriodId), "BnaSubjectName"); 
        //    List<SelectedModel> selectModels = itemStors.Select(x => new SelectedModel 
        //    {
        //        Text = x.BnaSubjectName.SubjectName,
        //        Value = x.BnaSubjectNameId 
        //    }).ToList();
        //    return selectModels;
        //}
    //}
}

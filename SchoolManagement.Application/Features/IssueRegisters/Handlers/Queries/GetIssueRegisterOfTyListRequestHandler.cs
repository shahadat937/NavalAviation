using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IssueRegister;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Queries
{
    public class GetIssueRegisterOfTyListRequestHandler :  IRequestHandler<GetIssueRegisterOfTyListRequest, List<IssueRegisterDto>>
    {
        private readonly ISchoolManagementRepository<IssueRegister> _IssueRegisterRepository;
        private readonly IMapper _mapper;


        public GetIssueRegisterOfTyListRequestHandler(ISchoolManagementRepository<IssueRegister> IssueRegisterRepository, IMapper mapper)
        {
            _IssueRegisterRepository = IssueRegisterRepository;
            _mapper = mapper;
        }

        

        public async Task<List<IssueRegisterDto>> Handle(GetIssueRegisterOfTyListRequest request, CancellationToken cancellationToken)
        {
            IQueryable<IssueRegister> IssueRegisters = _IssueRegisterRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId && x.IssueStatusId == request.IssueStatusId && x.ReturnQty != 0, "ItemDetail", "TrainingCrew");
            
            var IssueRegisterDtos = _mapper.Map<List<IssueRegisterDto>>(IssueRegisters);

            return IssueRegisterDtos;
        }
    }
}

using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using MediatR;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using AutoMapper;
using SchoolManagement.Application.DTOs.ItemStor;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.Features.MaintainenceStates.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintainenceStates.Handlers.Queries
{ 
    public class GetMaintenenceStateLisBySearchTextRequestHandler : IRequestHandler<GetMaintenenceStateLisBySearchTextRequest, object>
    {

        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;

        private readonly IMapper _mapper;

        public GetMaintenenceStateLisBySearchTextRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository, IMapper mapper)
        {
            _ItemStorRepository = ItemStorRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetMaintenenceStateLisBySearchTextRequest request, CancellationToken cancellationToken)
        {
           var dataTable = new DataTable();
            var spQuery = String.Format("exec [spGetMaintenenceStateListForSearch] {0},'{1}'",request.DepartmentNameId, request.SearchText);

            try
            {
              dataTable = _ItemStorRepository.ExecWithSqlQuery(spQuery);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
            }

            return dataTable;

        }
    }
}

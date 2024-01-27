using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using System.Data;
using static System.Formats.Asn1.AsnWriter;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetBarcodeResultSpRequestHandler : IRequestHandler<GetBarcodeResultSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ItemStor> _storeRepository;

        private readonly IMapper _mapper;

        public GetBarcodeResultSpRequestHandler(ISchoolManagementRepository<ItemStor> storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBarcodeResultSpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();

            var spQuery = String.Format("exec [spGetScannedResult] {0}", request.ItemDetailId);

            try
            {
              DataTable dataTable = _storeRepository.ExecWithSqlQuery(spQuery);
              return dataTable;
            }
            catch (Exception ex)
            {
              //throw new System.Exception();
              return null;
            }

            

        }
    }
}

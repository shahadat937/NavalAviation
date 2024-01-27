using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandTypes.Handlers.Commands
{
    public class DeleteDemandTypeCommandHandler : IRequestHandler<DeleteDemandTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDemandTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDemandTypeCommand request, CancellationToken cancellationToken)
        {
            var DemandType = await _unitOfWork.Repository<DemandType>().Get(request.DemandTypeId);

            if (DemandType == null)
                throw new NotFoundException(nameof(DemandType), request.DemandTypeId);

            await _unitOfWork.Repository<DemandType>().Delete(DemandType);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}

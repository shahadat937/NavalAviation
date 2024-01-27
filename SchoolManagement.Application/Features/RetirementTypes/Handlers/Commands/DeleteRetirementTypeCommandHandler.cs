using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RetirementTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RetirementTypes.Handlers.Commands
{
    public class DeleteRetirementTypeCommandHandler : IRequestHandler<DeleteRetirementTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRetirementTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRetirementTypeCommand request, CancellationToken cancellationToken)
        {
            var RetirementType = await _unitOfWork.Repository<RetirementType>().Get(request.RetirementTypeId);

            if (RetirementType == null)
                throw new NotFoundException(nameof(RetirementType), request.RetirementTypeId);

            await _unitOfWork.Repository<RetirementType>().Delete(RetirementType);
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

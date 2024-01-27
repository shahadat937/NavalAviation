using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Handlers.Commands
{
    public class DeleteOverhaulingTypeCommandHandler : IRequestHandler<DeleteOverhaulingTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOverhaulingTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOverhaulingTypeCommand request, CancellationToken cancellationToken)
        {
            var OverhaulingType = await _unitOfWork.Repository<OverhaulingType>().Get(request.OverhaulingTypeId);

            if (OverhaulingType == null)
                throw new NotFoundException(nameof(OverhaulingType), request.OverhaulingTypeId);

            await _unitOfWork.Repository<OverhaulingType>().Delete(OverhaulingType);
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

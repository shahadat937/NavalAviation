using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Handlers.Commands
{
    public class DeleteDegitalArchieveDocTypeCommandHandler : IRequestHandler<DeleteDegitalArchieveDocTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDegitalArchieveDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDegitalArchieveDocTypeCommand request, CancellationToken cancellationToken)
        {
            var DegitalArchieveDocType = await _unitOfWork.Repository<DegitalArchieveDocType>().Get(request.DegitalArchieveDocTypeId);

            if (DegitalArchieveDocType == null)
                throw new NotFoundException(nameof(DegitalArchieveDocType), request.DegitalArchieveDocTypeId);

            await _unitOfWork.Repository<DegitalArchieveDocType>().Delete(DegitalArchieveDocType);
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

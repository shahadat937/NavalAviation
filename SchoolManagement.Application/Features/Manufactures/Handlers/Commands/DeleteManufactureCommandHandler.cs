using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Manufactures.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Manufactures.Handlers.Commands
{
    public class DeleteManufactureCommandHandler : IRequestHandler<DeleteManufactureCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteManufactureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteManufactureCommand request, CancellationToken cancellationToken)
        {
            var Manufacture = await _unitOfWork.Repository<Manufacture>().Get(request.ManufactureId);

            if (Manufacture == null)
                throw new NotFoundException(nameof(Manufacture), request.ManufactureId);

            await _unitOfWork.Repository<Manufacture>().Delete(Manufacture);
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

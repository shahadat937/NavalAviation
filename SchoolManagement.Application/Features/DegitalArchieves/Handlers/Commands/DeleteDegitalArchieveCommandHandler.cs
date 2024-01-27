using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DegitalArchieves.Handlers.Commands
{
    public class DeleteDegitalArchieveCommandHandler : IRequestHandler<DeleteDegitalArchieveCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDegitalArchieveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDegitalArchieveCommand request, CancellationToken cancellationToken)
        {
            var DegitalArchieve = await _unitOfWork.Repository<DegitalArchieve>().Get(request.DegitalArchieveId);

            if (DegitalArchieve == null)
                throw new NotFoundException(nameof(DegitalArchieve), request.DegitalArchieveId);

            await _unitOfWork.Repository<DegitalArchieve>().Delete(DegitalArchieve);
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

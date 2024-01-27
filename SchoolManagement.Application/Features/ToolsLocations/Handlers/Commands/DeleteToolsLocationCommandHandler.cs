using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsLocations.Handlers.Commands
{
    public class DeleteToolsLocationCommandHandler : IRequestHandler<DeleteToolsLocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteToolsLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteToolsLocationCommand request, CancellationToken cancellationToken)
        {
            var ToolsLocation = await _unitOfWork.Repository<ToolsLocation>().Get(request.ToolsLocationId);

            if (ToolsLocation == null)
                throw new NotFoundException(nameof(ToolsLocation), request.ToolsLocationId);

            await _unitOfWork.Repository<ToolsLocation>().Delete(ToolsLocation);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}

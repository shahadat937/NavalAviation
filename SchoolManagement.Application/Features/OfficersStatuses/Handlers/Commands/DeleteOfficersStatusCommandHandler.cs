using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OfficersStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OfficersStatuses.Handlers.Commands
{
    public class DeleteOfficersStatusCommandHandler : IRequestHandler<DeleteOfficersStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOfficersStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOfficersStatusCommand request, CancellationToken cancellationToken)
        {
            var OfficersStatus = await _unitOfWork.Repository<OfficersStatus>().Get(request.OfficersStatusId);

            if (OfficersStatus == null)
                throw new NotFoundException(nameof(OfficersStatus), request.OfficersStatusId);

            await _unitOfWork.Repository<OfficersStatus>().Delete(OfficersStatus);
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

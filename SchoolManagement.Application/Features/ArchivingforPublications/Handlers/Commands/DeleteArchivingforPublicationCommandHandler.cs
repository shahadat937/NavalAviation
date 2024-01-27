using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Handlers.Commands
{
    public class DeleteArchivingforPublicationCommandHandler : IRequestHandler<DeleteArchivingforPublicationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteArchivingforPublicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteArchivingforPublicationCommand request, CancellationToken cancellationToken)
        {
            var ArchivingforPublication = await _unitOfWork.Repository<ArchivingforPublication>().Get(request.ArchivingforPublicationId);

            if (ArchivingforPublication == null)
                throw new NotFoundException(nameof(ArchivingforPublication), request.ArchivingforPublicationId);

            await _unitOfWork.Repository<ArchivingforPublication>().Delete(ArchivingforPublication);
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

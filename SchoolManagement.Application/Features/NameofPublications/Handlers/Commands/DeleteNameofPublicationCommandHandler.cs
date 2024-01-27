using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NameofPublications.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NameofPublications.Handlers.Commands
{
    public class DeleteNameofPublicationCommandHandler : IRequestHandler<DeleteNameofPublicationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNameofPublicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNameofPublicationCommand request, CancellationToken cancellationToken)
        {
            var NameofPublication = await _unitOfWork.Repository<NameofPublication>().Get(request.NameofPublicationId);

            if (NameofPublication == null)
                throw new NotFoundException(nameof(NameofPublication), request.NameofPublicationId);

            await _unitOfWork.Repository<NameofPublication>().Delete(NameofPublication);
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

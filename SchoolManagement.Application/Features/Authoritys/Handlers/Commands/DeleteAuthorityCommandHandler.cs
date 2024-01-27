using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Authoritys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Authoritys.Handlers.Commands
{
    public class DeleteAuthorityCommandHandler : IRequestHandler<DeleteAuthorityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAuthorityCommand request, CancellationToken cancellationToken)
        {
            var Authority = await _unitOfWork.Repository<Authority>().Get(request.AuthorityId);

            if (Authority == null)
                throw new NotFoundException(nameof(Authority), request.AuthorityId);

            await _unitOfWork.Repository<Authority>().Delete(Authority);
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

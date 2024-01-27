using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PrincipalNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PrincipalNames.Handlers.Commands
{
    public class DeletePrincipalNameCommandHandler : IRequestHandler<DeletePrincipalNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePrincipalNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePrincipalNameCommand request, CancellationToken cancellationToken)
        {
            var PrincipalName = await _unitOfWork.Repository<PrincipalName>().Get(request.PrincipalNameId);

            if (PrincipalName == null)
                throw new NotFoundException(nameof(PrincipalName), request.PrincipalNameId);

            await _unitOfWork.Repository<PrincipalName>().Delete(PrincipalName);
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

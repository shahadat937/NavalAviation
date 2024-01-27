using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseItemNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseItemNames.Handlers.Commands
{
    public class DeleteGseItemNameCommandHandler : IRequestHandler<DeleteGseItemNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGseItemNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGseItemNameCommand request, CancellationToken cancellationToken)
        {
            var GseItemName = await _unitOfWork.Repository<GseItemName>().Get(request.GseItemNameId);

            if (GseItemName == null)
                throw new NotFoundException(nameof(GseItemName), request.GseItemNameId);

            await _unitOfWork.Repository<GseItemName>().Delete(GseItemName);
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

using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemInspections.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemInspections.Handlers.Commands
{
    public class DeleteItemInspectionCommandHandler : IRequestHandler<DeleteItemInspectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteItemInspectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteItemInspectionCommand request, CancellationToken cancellationToken)
        {
            var ItemInspection = await _unitOfWork.Repository<ItemInspection>().Get(request.ItemInspectionId);

            if (ItemInspection == null)
                throw new NotFoundException(nameof(ItemInspection), request.ItemInspectionId);

            await _unitOfWork.Repository<ItemInspection>().Delete(ItemInspection);
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

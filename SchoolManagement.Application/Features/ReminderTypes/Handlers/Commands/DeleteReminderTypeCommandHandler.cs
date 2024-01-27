using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReminderTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ReminderTypes.Handlers.Commands
{
    public class DeleteReminderTypeCommandHandler : IRequestHandler<DeleteReminderTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReminderTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReminderTypeCommand request, CancellationToken cancellationToken)
        {
            var ReminderType = await _unitOfWork.Repository<ReminderType>().Get(request.ReminderTypeId);

            if (ReminderType == null)
                throw new NotFoundException(nameof(ReminderType), request.ReminderTypeId);

            await _unitOfWork.Repository<ReminderType>().Delete(ReminderType);
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

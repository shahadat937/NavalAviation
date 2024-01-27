using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Handlers.Commands
{
    public class DeleteGseScheduleWorkTypeCommandHandler : IRequestHandler<DeleteGseScheduleWorkTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGseScheduleWorkTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGseScheduleWorkTypeCommand request, CancellationToken cancellationToken)
        {
            var GseScheduleWorkType = await _unitOfWork.Repository<GseScheduleWorkType>().Get(request.GseScheduleWorkTypeId);

            if (GseScheduleWorkType == null)
                throw new NotFoundException(nameof(GseScheduleWorkType), request.GseScheduleWorkTypeId);

            await _unitOfWork.Repository<GseScheduleWorkType>().Delete(GseScheduleWorkType);
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

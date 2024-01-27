using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Commands
{
    public class DeleteTrainingCrewCommandHandler : IRequestHandler<DeleteTrainingCrewCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTrainingCrewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTrainingCrewCommand request, CancellationToken cancellationToken)
        {
            var TrainingCrew = await _unitOfWork.Repository<TrainingCrew>().Get(request.TrainingCrewId);

            if (TrainingCrew == null)
                throw new NotFoundException(nameof(TrainingCrew), request.TrainingCrewId);

            await _unitOfWork.Repository<TrainingCrew>().Delete(TrainingCrew);
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

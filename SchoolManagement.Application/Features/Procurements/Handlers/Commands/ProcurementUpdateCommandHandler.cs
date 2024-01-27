using System;
using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Procurement.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Procurements.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using Microsoft.VisualBasic;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Commands
{
    public class ProcurementUpdateCommandHandler : IRequestHandler<ProcurementUpdateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
     
        public ProcurementUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ProcurementUpdateCommand request, CancellationToken cancellationToken)
        {
            var procurements = await _unitOfWork.Repository<Procurement>().Get(request.ProcurementDto.ProcurementId);

            if (procurements is null)
              throw new NotFoundException(nameof(procurements), request.ProcurementDto.ProcurementId);


            procurements.LatestProgress = request.ProcurementDto.LatestProgress;
            procurements.Reason = request.ProcurementDto.Reason;

            await _unitOfWork.Repository<Procurement>().Update(procurements);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}

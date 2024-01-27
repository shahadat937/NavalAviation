using System;
using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.MeaSquadronState.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using Microsoft.VisualBasic;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Handlers.Commands
{
    public class RemarksUpdateMeaSquadronStateCommandHandler : IRequestHandler<RemarksUpdateMeaSquadronStateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
     
        public RemarksUpdateMeaSquadronStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemarksUpdateMeaSquadronStateCommand request, CancellationToken cancellationToken)
        {
            var MeaSquadronState = await _unitOfWork.Repository<MeaSquadronState>().Get(request.RemarksUpdateMeaSquadronStateDto.MeaSquadronStateId);

            if (MeaSquadronState is null)
                throw new NotFoundException(nameof(MeaSquadronState), request.RemarksUpdateMeaSquadronStateDto.MeaSquadronStateId);
             
             _mapper.Map(request.RemarksUpdateMeaSquadronStateDto, MeaSquadronState);
            MeaSquadronState.Remarks = request.RemarksUpdateMeaSquadronStateDto.Remarks;
            //MeaSquadronState.DocUpload = request.RemarksUpdateMeaSquadronStateDto.DocUpload;

            await _unitOfWork.Repository<MeaSquadronState>().Update(MeaSquadronState);
            await _unitOfWork.Save();

             



              return Unit.Value;
        }
    }
}

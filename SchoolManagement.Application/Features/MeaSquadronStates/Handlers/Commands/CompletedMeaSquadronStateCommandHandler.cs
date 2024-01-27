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
    public class CompletedMeaSquadronStateCommandHandler : IRequestHandler<CompletedMeaSquadronStateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
     
        public CompletedMeaSquadronStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CompletedMeaSquadronStateCommand request, CancellationToken cancellationToken)
        {
            var MeaSquadronState = await _unitOfWork.Repository<MeaSquadronState>().Get(request.CompletedMeaSquadronStateDto.MeaSquadronStateId);

            if (MeaSquadronState is null)
                throw new NotFoundException(nameof(MeaSquadronState), request.CompletedMeaSquadronStateDto.MeaSquadronStateId);
            
            _mapper.Map(request.CompletedMeaSquadronStateDto, MeaSquadronState);
            MeaSquadronState.MeaWorkShopId = request.CompletedMeaSquadronStateDto.MeaWorkShopId;
            MeaSquadronState.ControlNo = request.CompletedMeaSquadronStateDto.ControlNo;


            await _unitOfWork.Repository<MeaSquadronState>().Update(MeaSquadronState);
            await _unitOfWork.Save();

             



              return Unit.Value;
        }
    }
}

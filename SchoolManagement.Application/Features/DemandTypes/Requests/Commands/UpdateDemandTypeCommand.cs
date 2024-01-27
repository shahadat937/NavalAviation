using MediatR;
using SchoolManagement.Application.DTOs.DemandType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DemandTypes.Requests.Commands
{
    public class UpdateDemandTypeCommand : IRequest<Unit>
    {
        public DemandTypeDto DemandTypeDto { get; set; }
    }
}

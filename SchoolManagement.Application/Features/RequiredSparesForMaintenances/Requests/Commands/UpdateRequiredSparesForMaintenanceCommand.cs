using MediatR;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands
{
    public class UpdateRequiredSparesForMaintenanceCommand : IRequest<Unit>
    {
        public RequiredSparesForMaintenanceDto RequiredSparesForMaintenanceDto { get; set; }
    }
}

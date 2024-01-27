using MediatR;
using SchoolManagement.Application.DTOs.ToolsLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ToolsLocations.Requests.Commands
{
    public class UpdateToolsLocationCommand : IRequest<Unit>
    {
        public ToolsLocationDto ToolsLocationDto { get; set; }
    }
}
 
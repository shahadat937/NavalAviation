using MediatR;
using SchoolManagement.Application.DTOs.Attendence;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Attendences.Requests.Commands
{
    public class UpdateAttendenceCommand : IRequest<Unit>
    {
        public AttendenceDto AttendenceDto { get; set; }
    }
}

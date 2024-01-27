using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Commands
{
    public class DeleteEquipmentNameCommand : IRequest
    {
        public int EquipmentNameId { get; set; }
    }
} 

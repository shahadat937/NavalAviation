using MediatR;
using SchoolManagement.Application.DTOs.MeaWorkShop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MeaWorkShops.Requests.Commands
{
    public class UpdateMeaWorkShopCommand : IRequest<Unit>
    {
        public MeaWorkShopDto MeaWorkShopDto { get; set; }
    }
}

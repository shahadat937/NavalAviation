using SchoolManagement.Application;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Queries;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Dashboard)]
[ApiController]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-pendingDemands")]
    public async Task<ActionResult> GetPendingDemand(int departmentId)
    {
        var PendingDemand = await _mediator.Send(new GetPendingDemandSpRequest
        {
            DepartmentId = departmentId
        });
        return Ok(PendingDemand);
    }

    [HttpGet]
    [Route("get-pendingProcurements")]
    public async Task<ActionResult> GetPendingProcurements(int departmentId)
    {
        var pendingProcurements = await _mediator.Send(new GetPendingProcurementSpRequest
        {
            DepartmentId = departmentId
        });
        return Ok(pendingProcurements);
    }

    [HttpGet]
    [Route("get-pendingAcceptances")]
    public async Task<ActionResult> GetPendingAcceptances(int departmentId)
    {
        var acceptanceProcurements = await _mediator.Send(new GetPendingAcceptanceSpRequest
        {
            DepartmentId = departmentId
        });
        return Ok(acceptanceProcurements);
    }


    [HttpGet]
    [Route("get-availableQty")]
    public async Task<ActionResult> GetAvailableQty(int departmentId)
    {
        var availableQty = await _mediator.Send(new GetAvailableQtySpRequest
        {
            DepartmentId = departmentId
        });
        return Ok(availableQty);
    }

    [HttpGet]
    [Route("get-flyingTimeByAricraft")]
    public async Task<ActionResult> GetFlyingTimeByAricraft(int departmentId)
    {
        var FlyingTimeByAricraft = await _mediator.Send(new GetFlyingTimeByAricraftSpRequest
        {
            DepartmentId = departmentId
        });
        return Ok(FlyingTimeByAricraft);
    }

    [HttpGet]
    [Route("get-aricraftFlying")]
    public async Task<ActionResult> GetFlyingTimeByAricraft(DateTime currentDate,int departmentId)
    {
        var FlyingTimeByAricraft = await _mediator.Send(new GetAirCraftFlyingSpRequest
        {
            Current = currentDate,
            DepartmentId = departmentId
        });
        return Ok(FlyingTimeByAricraft);
    }

    [HttpGet]
    [Route("get-trainingCrew")]
    public async Task<ActionResult> GetTrainingCrew(int departmentId)
    {
        var TrainingCrew = await _mediator.Send(new GetTrainingCrewSpRequest
        {
            DepartmentId = departmentId
        });
        return Ok(TrainingCrew);
    }

    [HttpGet]
    [Route("get-remainProcurementQty")]
    public async Task<ActionResult> GetRemainProcurementQty(int departmentId)
    {
        var RemainProcurementQty = await _mediator.Send(new GetRemainProcurementQtySpRequest
        {
            DepartmentId = departmentId
        });
        return Ok(RemainProcurementQty);
    }
    [HttpGet]
    [Route("get-SpGetCompleteStatus")]
    public async Task<ActionResult> GetSpGetCompleteStatus(int departmentId)
    {
        var FlyingTimeByAricraft = await _mediator.Send(new GetSpGetCompleteStatusRequest
        {
            DepartmentId = departmentId
        });
        return Ok(FlyingTimeByAricraft);
    }
    [HttpGet]
    [Route("get-ountAricraftStatus")]
    public async Task<ActionResult> GetcountAircrafStatus(DateTime currentDate, int departmentId)
    {
        var FlyingTimeByAricraft = await _mediator.Send(new GetspCountAricraftStatusRequest
        {
            Current = currentDate,
            DepartmentId = departmentId
        });
        return Ok(FlyingTimeByAricraft);
    }

    [HttpGet]
    [Route("get-spFlyingSchedule")]
    public async Task<ActionResult> GetSpFlyingSchedule(DateTime dateFrom, DateTime dateTo, int departmentId)
    {
        var FlyingTimeByAricraft = await _mediator.Send(new GetSpFlyingScheduleRequest
        {
            DateFrom = dateFrom,
            DateTo = dateTo,
            DepartmentId = departmentId
        });
        return Ok(FlyingTimeByAricraft);
    }

    [HttpGet]
    [Route("get-opearionalAircraftNameCount")] 
    public async Task<ActionResult> GetOpearionalAircraftNameCount(int departmentId)
    {
        var operationalAircraftNameCount = await _mediator.Send(new GetOpearionalAircraftNameCountRequest
        {
          DepartmentId = departmentId
        });
        return Ok(operationalAircraftNameCount);
    }

    [HttpGet]
    [Route("get-nonOpearionalAircraftNameCount")]
    public async Task<ActionResult> GetNonOpearionalAircraftNameCount(int departmentId)
    {
        var nonOperationalAircraftNameCount = await _mediator.Send(new GetNonOpearionalAircraftNameCountRequest
        {
            DepartmentId =departmentId
        });
        return Ok(nonOperationalAircraftNameCount);
    }

    [HttpGet]
    [Route("get-todayNoticeBoardData")]
    public async Task<ActionResult> GetTodayNoticeBoardData(int departmentId)
    {
        var noticeBoards = await _mediator.Send(new GetTodayNoticeBoardSpRequest
        {
          DepartmentId = departmentId
        });
        return Ok(noticeBoards); 
    }

    [HttpGet]
    [Route("get-aircraftinFlightData")]
    public async Task<ActionResult> GetAircraftInFlightData(int departmentId)
    {
    var airCraftFlyings = await _mediator.Send(new GetAirCraftFlyingListForDashboardRequest
    {
      DepartmentId = departmentId
    });
      return Ok(airCraftFlyings); 
    }
    [HttpGet]
    [Route("get-spAcUnderMaintenance")]
    public async Task<ActionResult> GetSpAcUnderMaintenance(DateTime currentDate, int departmentId)
    {
    var underMaintenance = await _mediator.Send(new GetSpAcUnderMaintenanceRequest
    {
        Current = currentDate,
        DepartmentId = departmentId
      });
      return Ok(underMaintenance);
    }

    [HttpGet]
    [Route("get-personalState")]
    public async Task<ActionResult> GetPersonalState(int departmentId)
    {
      var personalStates = await _mediator.Send(new GetSpPersonalStateRequest
      {
        DepartmentId = departmentId
      });
      return Ok(personalStates);
    }

    [HttpGet]
    [Route("get-personalStateTotalCount")]
    public async Task<ActionResult> GetPersonalStateTotalCount()
    {
      var personalStates = await _mediator.Send(new GetSpPersonalStateTotalCountRequest
      {
      });
      return Ok(personalStates);
    }
   
      [HttpGet]
      [Route("get-personalStateTotalCountByDepartmentNameId")]
      public async Task<ActionResult> GetPersonalStateTotalCountByDepartmentNameId(int departmentNameId)
      {
      var personalStates = await _mediator.Send(new GetSpPersonalStateTotalCountRequestByDepartmentId
      {
         DepartmentNameId = departmentNameId
      });
        return Ok(personalStates);
      }

  [HttpGet]
  [Route("get-personalStateTotalByStatus")]
  public async Task<ActionResult> GetPersonalStatesByStatus(int departmentNameId, int officersStatusId, int presentBilletId, int employeeTypeId)
  {
    var personalStates = await _mediator.Send(new GetPersonalStatesByStatusSpRequest
    {
      DepartmentNameId = departmentNameId,
      OfficersStatusId = officersStatusId,
      PresentBilletId = presentBilletId,
      EmployeeTypeId = employeeTypeId
    });
    return Ok(personalStates);
  }

  [HttpGet]
    [Route("get-spAricraftStatusCount")]
    public async Task<ActionResult> GetcountAircrafStatus(int departmentId)
    {
      var aricraftcount = await _mediator.Send(new GetSpAcStatusCountRequest
      {
        DepartmentId = departmentId
      });
      return Ok(aricraftcount);
    }
  [HttpGet]
  [Route("get-spAricraftStatus")]
  public async Task<ActionResult> GetAircrafStatus(DateTime currentDate, int departmentId)
  {
    var aricraftstatus = await _mediator.Send(new GetSpAcStatusRequest
    {
      Current = currentDate,
      DepartmentId = departmentId
    });
    return Ok(aricraftstatus);
  }
  [HttpGet]
  [Route("get-aCStatusTotalCountForOperationalOrUnderMaint")]
  public async Task<ActionResult> GetACStatusTotalCountForOperationalOrUnderMaint()
  {
    var acStatus = await _mediator.Send(new GetSpACStatusTotalCountForOperationalOrUnderMaintRequest
    {
    });
    return Ok(acStatus);
  }

}


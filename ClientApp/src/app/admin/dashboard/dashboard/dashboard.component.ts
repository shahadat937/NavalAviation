import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { Router } from "@angular/router";
import { ConfirmService } from "src/app/core/service/confirm.service";
import { MasterData } from "src/assets/data/master-data";
import { MatSnackBar } from "@angular/material/snack-bar";
import { DashboardService } from "../service/Dashboard.service";
import { ProcurementService } from "../../../spares-management/service/Procurement.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { DatePipe } from "@angular/common";
import { AuthService } from "src/app/core/service/auth.service";
import { Role } from "src/app/core/models/role";

// aircraftnameoperational-list
@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.scss"],
})
export class DashboardComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  groupArrays: { schoolName: string; courses: any }[];
  operationalAircraftNameList: any[];
  selectedDepartmentName: SelectedModel[];
  departmentName: any;
  totalAircraftCount: any;
  operationalAllCount: any;
  nonOperationalAllCount: any;
  aircraftStatusList: any;
  aircraftStatusCount: any;
  AricraftUnderMaintenanceList: any;
  CountAricraftUnderMaintenance: any;
  PersonalStateList: any;
  CountPersonalState: any;
  TotalLogisticCount: any;

  groupArrayFlightStatus: { departmentName: string; courses: any }[];
  pendingAcceptancesCount: any;
  TotalPersonalCount:any;
  totalCount:any;
  MaintanenceScheduleListFromData: any;
  underMaint:any;
  CountMaintanenceScheduleListFromData: any;
  pendingProcurementCount: any;
  pendingDemandCount: any;
  nonOperationalAircraftNameCount: any;
  operationalAircraftNameCount: any;
  AricraftFlyingScheduleList: any;
  CountAricraftFlyingSchedule: any;
  todayNoticeBoardData: any[];
  groupArraysDept: { departmentName: string; courses: any }[];
  aircraftFlyingData: any[];

  role: any;
  traineeId: any;
  branchId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "schoolName",
    "name",
    "manufacturer",
    "manufacturerMobile",
    "maintenenceState",
  ];

  constructor(
    private snackBar: MatSnackBar,
    private datepipe: DatePipe,
    private fb: FormBuilder,
    private authService: AuthService,
    private ProcurementService: ProcurementService,
    private dashboardService: DashboardService,
    private router: Router,
    private confirmService: ConfirmService
  ) {}

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (
      this.role == this.userRole.HR ||
      this.role == this.userRole.CO ||
      this.role == this.userRole.FLGWG ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAircraftStatusCount(0);
      this.getAircraftStatus(0);
      this.getPersonalState(0);
      this.getUnderMaintanenceCount(0);
      this.getAricraftFlyingSchedule(0);
      this.getAircraftFlyingData(0);
      this.getTodayNoticeBoardData(0);
      this.getPersonalStateTotalCountByDepartmentId(0);
      this.getLogisticIssues(0);
    } else {
      this.getAircraftStatusCount(this.branchId);
      this.getAircraftStatus(this.branchId);
      this.getPersonalState(this.branchId);
      this.getUnderMaintanenceCount(this.branchId);
      this.getAricraftFlyingSchedule(this.branchId);
      this.getAircraftFlyingData(this.branchId);
      this.getTodayNoticeBoardData(this.branchId);
      this.getPersonalStateTotalCountByDepartmentId(this.branchId);
      this.getLogisticIssues(this.branchId);
    }
    this.getOperatinalAircraftNameCount();
    // this.getAricraftFlyingSchedule();
    this.getOperatinalAircraftNameCount();
    this.getNonOperatinalAircraftNameCount();
    // this.getTodayNoticeBoardData();
    // this.getAircraftFlyingData();
   // this.getPersonalStateTotalCount();
    this.getOperatinalsAircraftNameCount();
    this.getAricraftUnderMaintenance();
    // this.getPersonalState();
  }
  getLogisticIssues(departmentId) {
    this.ProcurementService.getProcurementListByDepartmentNameId(this.paging.pageIndex,100000,this.searchText,this.masterData.sparescategory.spares,departmentId).subscribe((response) => {
      this.TotalLogisticCount = response.items.length;
    });
}
  getPersonalState(departmentId) {
    this.dashboardService
      .getPersonalState(departmentId)
      .subscribe((response) => {
        this.PersonalStateList = response;
        this.CountPersonalState = response.length;
        console.log("this.PersonalStateList");
        console.log(this.CountPersonalState);
      });
  }
  getPendingAcceptances() {
    this.dashboardService.getPendingAcceptances(0).subscribe((response) => {
      this.pendingAcceptancesCount = response.length;
    });
  }
  getPersonalStateTotalCount() {
    this.dashboardService.getPersonalStateTotalCount().subscribe((response) => {
      this.TotalPersonalCount = response;
      this.totalCount = response[0].total;
    });
  }

  getPersonalStateTotalCountByDepartmentId(departmentId) {
    this.dashboardService.getPersonalStateTotalCountByDepartmentNameId(departmentId).subscribe((response) => {
      this.TotalPersonalCount = response;
      this.totalCount = response[0].total;
      // this.presentCount = response[0].present;
      // this.awayCount = response[0].away;
      // this.leaveCount = response[0].leave;
    });
  }

  getUnderMaintanenceCount(departmentId){
    // this.dashboardService.maintenanceScheduleListByDepartmentAndAirCraftName(0, departmentId).subscribe(res => {
    //   this.MaintanenceScheduleListFromData = res;   
    //   this.CountMaintanenceScheduleListFromData = res.length;
    //   console.log(this.MaintanenceScheduleListFromData);          
    // });
    this.dashboardService.getAircraftStatusCount(departmentId).subscribe(res => {
      this.MaintanenceScheduleListFromData = res;   
      this.CountMaintanenceScheduleListFromData = res.length;
      console.log(res);  
      this.underMaint =  res[0].underMaint;
      console.log("underMaint");
      console.log(this.underMaint);  
      console.log("underMaint");         
    });
  }

  getPendingProcurements() {
    this.dashboardService.getPendingProcurements(0).subscribe((response) => {
      this.pendingProcurementCount = response.length;
    });
  }
  getPendingDemand() {
    this.dashboardService.getPendingDemands(0).subscribe((response) => {
      this.pendingDemandCount = response.length;
    });
  }
  getNonOperatinalAircraftNameCount() {
    this.dashboardService
      .getNonOperatinalAircraftNameCount(0)
      .subscribe((response) => {
        this.nonOperationalAircraftNameCount = response.length;
      });
  }

  getOperatinalsAircraftNameCount() {
    this.dashboardService
      .getOperatinalAircraftNameCount(0)
      .subscribe((response) => {
        this.operationalAircraftNameCount = response.length;
      });
  }
  getAricraftFlyingSchedule(departmentId) {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAricraftFlyingSchedule(currentDateTime,currentDateTime, departmentId)
      .subscribe((response) => {
        this.AricraftFlyingScheduleList = response;
        this.CountAricraftFlyingSchedule = response.length;
        console.log(this.AricraftFlyingScheduleList);
        console.log("count aircraft flying");
        console.log(this.CountAricraftFlyingSchedule);
      });
  }
  getTodayNoticeBoardData(departmentId) {
    this.dashboardService.getTodayNoticeBoardData(departmentId).subscribe((response) => {
      this.todayNoticeBoardData = response;
      console.log("this.todayNoticeBoardData");
      console.log(this.todayNoticeBoardData);

      const groups = this.todayNoticeBoardData.reduce((groups, courses) => {
        const schoolName = courses.departmentName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArraysDept = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          courses: groups[departmentName],
        };
      });
    });
  }
  getAricraftUnderMaintenance() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAricraftUnderMaintenance(currentDateTime, 0)
      .subscribe((response) => {
        this.AricraftUnderMaintenanceList = response;
        this.CountAricraftUnderMaintenance = response.length;
        // console.log(this.AricraftUnderMaintenanceList)
        // console.log("count aircraft Maintenance");
        // console.log(this.CountAricraftUnderMaintenance)
      });
  }
  getAircraftStatusCount(departmentId) {
    this.dashboardService
      .getAircraftStatusCount(departmentId)
      .subscribe((response) => {
        this.aircraftStatusCount = response.length;
        // console.log("this.aircraftStatusCount")
        // console.log(this.aircraftStatusCount)
      });
  }
  getAircraftStatus(departmentId) {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAircraftStatus(currentDateTime, departmentId)
      .subscribe((response) => {
        this.aircraftStatusList = response;
        this.aircraftStatusCount = response.length;
        // console.log("this.aircraftStatusCount")
        // console.log(this.aircraftStatusList)
        // console.log(this.aircraftStatusCount)
      });
  }
  getAircraftFlyingData(departmentId) {
    this.dashboardService.getAircraftFlyingData(departmentId).subscribe((response) => {
     // this.aircraftFlyingData = response;
      this.aircraftFlyingData = response.filter(x=>x.runningPercentage>=0 && x.runningPercentage <100 && x.restPercentage>=0);
      const groups = this.aircraftFlyingData.reduce((groups, courses) => {
        const schoolName = courses.departmentName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrayFlightStatus = Object.keys(groups).map(
        (departmentName) => {
          return {
            departmentName,
            courses: groups[departmentName],
          };
        }
      );
    });
  }

  getGroupTable() {
    const groups = this.operationalAircraftNameList.reduce(
      (groups, courses) => {
        const schoolName = courses.schoolName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      },
      {}
    );

    // Edit: to add it in the array format instead
    this.groupArrays = Object.keys(groups).map((schoolName) => {
      return {
        schoolName,
        courses: groups[schoolName],
      };
    });
    this.departmentName = this.groupArrays[0].schoolName;
    // console.log("999999");
    // console.log(this.groupArrays[0].schoolName);
  }

  GetDepartmentNameById(baseNameId) {
    this.dashboardService.getSelectedSchoolName(baseNameId).subscribe((res) => {
      this.selectedDepartmentName = res;
      console.log(res);
    });
  }
  getOperatinalAircraftNameCount() {
    this.dashboardService
      .getOperatinalAircraftNameCount(0)
      .subscribe((response) => {
        this.operationalAircraftNameList = response;
        this.totalAircraftCount = response.length;

        this.operationalAllCount = this.operationalAircraftNameList.filter(
          (x) => x.maintenenceState == 0
        ).length;
        this.nonOperationalAllCount = this.operationalAircraftNameList.filter(
          (x) => x.maintenenceState == 1
        ).length;
        // console.log("Department Name list");
        // console.log(this.operationalAircraftNameList);

        this.getGroupTable();
        //console.log("5555555");
      });
  }
}

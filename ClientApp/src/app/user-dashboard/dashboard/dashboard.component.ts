import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UserDashboardService } from "../services/UserDashboard.service";
import { DashboardService } from "../../admin/dashboard/service/Dashboard.service";
import { ProcurementService } from "../../spares-management/service/Procurement.service";
import { ActivatedRoute, Router } from "@angular/router";
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexYAxis,
  ApexStroke,
  ApexLegend,
  ApexMarkers,
  ApexGrid,
  ApexFill,
  ApexTitleSubtitle,
  ApexNonAxisChartSeries,
  ApexResponsive,
} from "ng-apexcharts";
import { MasterData } from "src/assets/data/master-data";
import { environment } from "src/environments/environment";
import { DatePipe } from "@angular/common";
import { AuthService } from "src/app/core/service/auth.service";

export type avgLecChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  stroke: ApexStroke;
  dataLabels: ApexDataLabels;
  markers: ApexMarkers;
  colors: string[];
  yaxis: ApexYAxis;
  grid: ApexGrid;
  tooltip: ApexTooltip;
  legend: ApexLegend;
  fill: ApexFill;
  title: ApexTitleSubtitle;
};

export type pieChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  legend: ApexLegend;
  dataLabels: ApexDataLabels;
  responsive: ApexResponsive[];
  labels: any;
};

@Component({
  selector: "app-user-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.sass"],
})
export class DashboardComponent implements OnInit {
  @ViewChild("chart") chart: ChartComponent;
  public avgLecChartOptions: Partial<avgLecChartOptions>;
  public pieChartOptions: Partial<pieChartOptions>;
  masterData = MasterData;
  GetInstructorForm: FormGroup;
  traineeId: any;
  isShown: boolean = false;
  subjectLength: any;
  pno: any;
  name: any;
  position: any;
  name1: any;
  joiningDate: any;
  schoolName: any;
  schoolId: any;
  bulletinList: any;
  role: any;
  NoticeForInstructor: any;

  AricraftFlyingScheduleList: any;
  CountAricraftFlyingSchedule: any;
  aircraftStatustotalCount: any;
  aircraftStatusList: any;
  aircraftStatusCount: any;
  AricraftUnderMaintenanceList: any;
  CountAricraftUnderMaintenance: any;
  underMaint:any;
  nonOperationalAircraftNameCount: any;
  PersonalStateList: any;
  CountPersonalState: any;
  TotalLogisticCount: any;
  totalCount:any;

  aircraftFlyingData: any[];
  todayNoticeBoardData: any[];
  TotalPersonalCount:any;

  groupArrayFlightStatus: { departmentName: string; courses: any }[];
  groupArraysDept: { departmentName: string; courses: any }[];

  //fileUrl:any = environment.fileUrl;

  courseList: any;

  routineList: any;
  upcomingCoursesList: any;

  materialList: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText="";

  displayedUpcommingColumns: string[] = [
    "ser",
    "course",
    "durationForm",
    "subjectName",
  ];
  displayedCourseColumns: string[] = [
    "ser",
    "schoolName",
    "course",
    "subjectName",
  ];
  displayedRoutineColumns: string[] = [
    "ser",
    "date",
    "schoolName",
    "duration",
    "course",
    "subject",
    "location",
  ];
  displayedReadingMaterialColumns: string[] = [
    "ser",
    "readingMaterialTitle",
    "documentName",
    "documentLink",
  ];

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private datepipe: DatePipe,
    private route: ActivatedRoute,
    private dashboardService: DashboardService,
    private ProcurementService: ProcurementService,
    private userDashboardService: UserDashboardService
  ) {}
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    const branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, branchId);
    this.getAricraftFlyingSchedule(branchId);
    this.getAircraftStatusCount(branchId);
    this.getAircraftStatus(branchId);
    this.getAricraftUnderMaintenance(branchId);
    this.getNonOperatinalAircraftNameCount(branchId);
   // this.getPersonalState(branchId);
    this.getAircraftFlyingData(branchId);
    this.getTodayNoticeBoardData(branchId);
    this.getPersonalStateTotalCountByDepartmentId(branchId)
    this.getLogisticIssues(branchId)
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

  getLogisticIssues(departmentId) {
    this.ProcurementService.getProcurementListByDepartmentNameId(this.paging.pageIndex,100000,this.searchText,this.masterData.sparescategory.spares,departmentId).subscribe((response) => {
      this.TotalLogisticCount = response.items.length;
    });
  }
  getPersonalStateTotalCountByDepartmentId(departmentId) {
    this.dashboardService.getPersonalStateTotalCountByDepartmentNameId(departmentId).subscribe((response) => {
      this.PersonalStateList = response;
      this.CountPersonalState = response[0].total;
      console.log("this.PersonalStateList");
      console.log(this.CountPersonalState);
      // this.presentCount = response[0].present;
      // this.awayCount = response[0].away;
      // this.leaveCount = response[0].leave;
    });
  }

  getAircraftFlyingData(departmentId) {
    this.dashboardService.getAircraftFlyingData(departmentId).subscribe((response) => {

      this.aircraftFlyingData = response.filter(x=>x.runningPercentage>=0 && x.runningPercentage <100 && x.restPercentage>=0);
      console.log("flying flight");
      console.log(response);

      console.log(this.aircraftFlyingData);
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

  getAricraftFlyingSchedule(branchId) {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAricraftFlyingSchedule(currentDateTime,currentDateTime, branchId)
      .subscribe((response) => {
        this.AricraftFlyingScheduleList = response;
        this.CountAricraftFlyingSchedule = response.length;
      });
  }

  getAircraftStatusCount(branchId) {
    this.dashboardService
      .getAircraftStatusCount(branchId)
      .subscribe((response) => {
        this.aircraftStatustotalCount = response.length;
        // console.log("this.aircraftStatusCount")
        // console.log(this.aircraftStatusCount)
      });
  }

  getAircraftStatus(branchId) {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAircraftStatus(currentDateTime, branchId)
      .subscribe((response) => {
        this.aircraftStatusList = response;
        this.aircraftStatusCount = response.length;
        // console.log("this.aircraftStatusCount")
        // console.log(this.aircraftStatusList)
        // console.log(this.aircraftStatusCount)
      });
  }

  // getAricraftUnderMaintenance(branchId) {
  //   let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
  //   this.dashboardService
  //     .getAricraftUnderMaintenance(currentDateTime, branchId)
  //     .subscribe((response) => {
  //       this.AricraftUnderMaintenanceList = response;
  //       this.CountAricraftUnderMaintenance = response.length;
  //       //console.log(this.AricraftUnderMaintenanceList)
  //       //console.log("count aircraft Maintenance");
  //       //console.log(this.CountAricraftUnderMaintenance)
  //       console.log(response);
  //       // this.underMaint =  response[0].underMaint;
  //       // console.log("underMaint");
  //       // console.log(this.underMaint);  
  //       // console.log("underMaint");  
  //       console.log("Under Maint");
  //     });
  // }
  getAricraftUnderMaintenance(departmentId){
    // this.dashboardService.maintenanceScheduleListByDepartmentAndAirCraftName(0, departmentId).subscribe(res => {
    //   this.MaintanenceScheduleListFromData = res;   
    //   this.CountMaintanenceScheduleListFromData = res.length;
    //   console.log(this.MaintanenceScheduleListFromData);          
    // });
    this.dashboardService.getAircraftStatusCount(departmentId).subscribe(res => {
      this.AricraftUnderMaintenanceList = res;   
      this.CountAricraftUnderMaintenance = res.length;
      console.log(res);  
      this.underMaint =  res[0].underMaint;
      console.log("underMaint");
      console.log(this.underMaint);  
      console.log("underMaint");         
    });
  }

  getNonOperatinalAircraftNameCount(branchId) {
    this.dashboardService
      .getNonOperatinalAircraftNameCount(branchId)
      .subscribe((response) => {
        this.nonOperationalAircraftNameCount = response.length;
      });
  }
}

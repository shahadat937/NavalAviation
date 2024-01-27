import { Component, OnInit, ViewChild } from "@angular/core";
import { DashboardService } from "../service/Dashboard.service";
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexYAxis,
  ApexPlotOptions,
  ApexStroke,
  ApexLegend,
  ApexFill,
} from "ng-apexcharts";
import { MasterData } from "src/assets/data/master-data";
import { DatePipe } from "@angular/common";

import { ProcurementService } from "../../../spares-management/service/Procurement.service";

export type areaChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis;
  stroke: ApexStroke;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
  legend: ApexLegend;
  colors: string[];
};

export type barChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  fill: ApexFill;
  colors: string[];
};

@Component({
  selector: "app-main",
  templateUrl: "./main.component.html",
  styleUrls: ["./main.component.scss"],
})
export class MainComponent implements OnInit {
  @ViewChild("chart") chart: ChartComponent;
  public areaChartOptions: Partial<areaChartOptions>;
  public barChartOptions: Partial<barChartOptions>;
  masterData = MasterData;
  //variables

  pendingDemandCount: any;
  trainingCrewCount: any;
  pendingProcurementCount: any;
  pendingAcceptancesCount: any;
  availableQtyList: any;
  CountavailableQty: any;
  FlyingTimeByAricraftList: any;
  CountFlyingTimeByAricraft: any;
  aircraftStatustotalCount: any;
  AricraftFlyingList: any;
  AricraftFlyingScheduleList: any;
  CountAricraftFlying: any;
  CountAricraftFlyingSchedule: any;
  AricraftUnderMaintenanceList: any;
  CountAricraftUnderMaintenance: any;
  PersonalStateList: any;
  MaintanenceScheduleListFromData: any;
  underMaint:any;
  CountMaintanenceScheduleListFromData: any;
  aricraftStatusCountTotal:any;
  aircraftStatusList: any;
  CountPersonalState: any;
  RemainProcurementQtyList: any;
  operationalAircraftNameCount: any;
  nonOperationalAircraftNameCount: any;
  aircraftStatusCount: any;
  TotalPersonalCount:any;
  TotalLogisticCount:any;
  totalCount:any;
  CountRemainProcurement: any;
  aircraftFlyingData: any[];
  todayNoticeBoardData: any[];
  deptName: string = "All";
  RemainProcurement: string = "All";
  FlyingTimeByDeptName: string = "All";
  FlyingByDeptName: string = "All";
  StatusByDeptName: string = "All";
  StatusList: any;
  searchText: any = '';
  CountStatus: any;
  underMaincount: any;
  operationalcount: any;
  isShown: boolean = false;
  groupArrays: { departmentName: string; courses: any }[];
  groupArraysUnderMaintenance: { departmentName: string; datas: any }[];
  groupArrayFlightStatus: { departmentName: string; courses: any }[];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };

  procurementColumns: string[] = [
    "sl",
    "tenderNumber",
    "dateOfDelivery",
    "dateOfTenderFloat",
    "cstTec",
    "qty",
    "sftQty",
  ];
  displayedAvailableColumns: string[] = [
    "ser",
    "sparesCategory",
    "deptName",
    "partNo",
    "nameOfItem",
    "minimumStock",
    "availableQty",
  ];
  displayedFlyingColumns: string[] = [
    "ser",
    "airCraftName",
    "date",
    "crew",
    "callSign",
    "mon",
    "startUp",
    "dur",
    "endurance",
    "fuel",
    "opaOff",
    "remarks",
  ];
  displayNoticeBoardList: string[] = [
    "departmentName",
    "date",
    "event",
    "orderBy",
  ];
  displayedAircraftInFlightColumns: string[] = [
    "departmentName",
    "airCraftName",
    "startUp",
    "runningHour",
    "restHour",
  ];
  //displayedAircraftInfoColumns: string[] = [ 'ser', 'deptName','airCraftName', 'flyTime'];

  constructor(
    private datepipe: DatePipe,
    private ProcurementService: ProcurementService,
    private dashboardService: DashboardService
  ) {}

  ngOnInit() {
    this.chart1();
    this.chart2();
    this.getPendingDemand();
    //this.getRemainProcurementQty();
    this.getPendingProcurements();
    this.getPendingAcceptances();
    this.getTrainingCrew();
    this.getAvailableQty();
    this.getPersonalStateTotalCount();
    //this.getFlyingTimeByAricraft();
    //this.getAricraftFlying();
    //this.getPersonalStateTotalCountByDepartmentNameId(9);

    this.getAricraftFlyingSchedule();
    this.getAricraftUnderMaintenance();
    this.getOperatinalAircraftNameCount();
    this.getNonOperatinalAircraftNameCount();
    this.getTodayNoticeBoardData(0);
    this.getAircraftFlyingData(0);
    this.getLogisticIssues(0);
    this.getPersonalState();
    this.getAircraftStatusCount();
    this.getAircraftStatus();
    this.getUnderMaintanenceCount(0);
  }
  getLogisticIssues(departmentId) {
      this.ProcurementService.getProcurementListByDepartmentNameId(this.paging.pageIndex,100000,this.searchText,this.masterData.sparescategory.spares,departmentId).subscribe((response) => {
        this.TotalLogisticCount = response.items.length;
      });
  }
  getAircraftFlyingData(departmentId) {
    this.dashboardService.getAircraftFlyingData(departmentId).subscribe((response) => {
    //  this.aircraftFlyingData = response;

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
  getPersonalStateTotalCount() {
    this.dashboardService.getPersonalStateTotalCount().subscribe((response) => {
      this.TotalPersonalCount = response;
      console.log("totalcount");
      this.totalCount = response[0].total;
    });
  }
  // getPersonalStateTotalCountByDepartmentNameId(departmentId) {
  //   this.dashboardService.getPersonalStateTotalCountByDepartmentNameId(departmentId).subscribe((response) => {
  //     this.TotalPersonalCount = response;
  //     console.log("response");
  //     console.log(response);
  //     this.totalCount = response[0].total;
  //   });
  // }

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
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          courses: groups[departmentName],
        };
      });
    });
  }

  getNonOperatinalAircraftNameCount() {
    this.dashboardService
      .getNonOperatinalAircraftNameCount(0)
      .subscribe((response) => {
        this.nonOperationalAircraftNameCount = response.length;
      });
  }

  getOperatinalAircraftNameCount() {
    this.dashboardService
      .getOperatinalAircraftNameCount(0)
      .subscribe((response) => {
        this.operationalAircraftNameCount = response.length;
      });
  }

  getPendingDemand() {
    this.dashboardService.getPendingDemands(0).subscribe((response) => {
      this.pendingDemandCount = response.length;
    });
  }

  getPendingProcurements() {
    this.dashboardService.getPendingProcurements(0).subscribe((response) => {
      this.pendingProcurementCount = response.length;
    });
  }

  getPendingAcceptances() {
    this.dashboardService.getPendingAcceptances(0).subscribe((response) => {
      this.pendingAcceptancesCount = response.length;
    });
  }
  // getRemainProcurementQty(){
  //   this.dashboardService.getRemainProcurementQty(0).subscribe(response => {
  //     this.RemainProcurementQtyList=response;
  //     this.CountRemainProcurement=response.length;
  //     console.log(this.RemainProcurementQtyList)
  //   })
  // }
  // RemainProcurementQty(id, name){
  //   this.RemainProcurement = name;
  //   this.dashboardService.getRemainProcurementQty(id).subscribe(response => {
  //     this.RemainProcurementQtyList = response;
  //     this.CountRemainProcurement = response.length;
  //   })
  // }

  getAvailableQty() {
    this.dashboardService.getAvailableQty(0).subscribe((response) => {
      this.availableQtyList = response;
      this.CountavailableQty = response.length;
    });
  }

  inActiveItem(id, name) {
    this.deptName = name;
    this.dashboardService.getAvailableQty(id).subscribe((response) => {
      this.availableQtyList = response;
      this.CountavailableQty = response.length;
    });
  }
  getDemandSpGetCompleteStatus() {
    this.dashboardService
      .getDemandSpGetCompleteStatus(0)
      .subscribe((response) => {
        this.StatusList = response;
        this.CountStatus = response.length;
        //console.log(this.StatusList)
      });
  }
  StatusByDept(id, name) {
    this.StatusByDeptName = name;
    //let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.dashboardService
      .getDemandSpGetCompleteStatus(id)
      .subscribe((response) => {
        this.StatusList = response;
        this.CountStatus = response.length;
      });
  }
  getAricraftFlyingSchedule() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAricraftFlyingSchedule(currentDateTime,currentDateTime, 0)
      .subscribe((response) => {
        this.AricraftFlyingScheduleList = response;
        this.CountAricraftFlyingSchedule = response.length;
        //console.log(this.AricraftFlyingScheduleList)
        //console.log(this.CountAricraftFlyingSchedule)
      });
  }
  getAricraftUnderMaintenance() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAricraftUnderMaintenance(currentDateTime, 0)
      .subscribe((response) => {
        this.AricraftUnderMaintenanceList = response;
        this.CountAricraftUnderMaintenance = response.length;
        //console.log(this.AricraftUnderMaintenanceList)
        //console.log("count aircraft Maintenance");
        //console.log(this.CountAricraftUnderMaintenance)
      });
  }
  getAircraftStatusCount() {
    this.dashboardService.getAircraftStatusCount(0).subscribe((response) => {
      this.aircraftStatustotalCount = response.length;
      // console.log("this.aircraftStatusCount")
      // console.log(this.aircraftStatusCount)
    });
  }
  getAircraftStatus() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAircraftStatus(currentDateTime, 0)
      .subscribe((response) => {
        this.aircraftStatusList = response;
        this.aircraftStatusCount = response.length;
        console.log("this.aircraftStatusCount");
        console.log(this.aircraftStatusList);
        console.log(this.aircraftStatusCount);
      });
  }
  getPersonalState() {
    this.dashboardService.getPersonalState(0).subscribe((response) => {
      this.PersonalStateList = response;
      this.CountPersonalState = response.length;
      //console.log("this.PersonalStateList")
      //console.log(this.CountPersonalState)
    });
  }

  // getUnderMaintanenceCount(){
  //   this.dashboardService.maintenanceScheduleListByDepartmentAndAirCraftName(0, 0).subscribe(res => {
  //     this.MaintanenceScheduleListFromData = res;   
  //     this.CountMaintanenceScheduleListFromData = res.length;
  //     console.log(this.MaintanenceScheduleListFromData);          
  //   });
  //   // this.dashboardService.getAircraftStatusCount(branchId).subscribe((response) => {
  //   //   this.aricraftStatusCountTotal = response;
  //   //   this.totalCount=this.aricraftStatusCountTotal[0].total;
  //   //   this.operationalcount = this.aricraftStatusCountTotal[0].operational;
  //   //   this.underMaincount = this.aricraftStatusCountTotal[0].underMaint;
  //   //   console.log("this.aricraftStatusCountTotal-5555");
  //   //   console.log(this.aricraftStatusCountTotal);
  //   // });
  // }
  getUnderMaintanenceCount(branchId){
    this.dashboardService.getAircraftStatusCount(branchId).subscribe(res => {
      this.MaintanenceScheduleListFromData = res;   
      this.CountMaintanenceScheduleListFromData = res.length;
      this.underMaint =  res[0].underMaint;
      console.log("underMaint");
      console.log(this.underMaint);  
      console.log("underMaint"); 

    });
   
  }

  // getFlyingTimeByAricraft(){
  //   this.dashboardService.getFlyingTimeByAricraft(0).subscribe(response => {
  //     this.FlyingTimeByAricraftList=response;
  //     this.CountFlyingTimeByAricraft = response.length;
  //     console.log(this.FlyingTimeByAricraftList)
  //   })
  // }

  // FlyingTimeByDept(id, name){
  //   this.FlyingTimeByDeptName = name;
  //   this.dashboardService.getFlyingTimeByAricraft(id).subscribe(response => {
  //     this.FlyingTimeByAricraftList = response;
  //     this.CountFlyingTimeByAricraft = response.length;
  //   })
  // }

  // getAricraftFlying(){
  //   let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
  //   this.dashboardService.getAricraftFlying(currentDateTime,0).subscribe(response => {
  //     this.AricraftFlyingList=response;
  //     this.CountAricraftFlying = response.length;
  //     console.log(this.AricraftFlyingList)
  //   })
  // }

  // FlyingByDept(id, name){
  //   this.FlyingByDeptName = name;
  //   let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
  //   this.dashboardService.getAricraftFlying(currentDateTime,id).subscribe(response => {
  //     this.AricraftFlyingList=response;
  //     this.CountAricraftFlying = response.length;
  //   })
  // }

  getTrainingCrew() {
    this.dashboardService.getTrainingCrew(0).subscribe((response) => {
      this.trainingCrewCount = response.length;
      //console.log(this.trainingCrewCount)
    });
  }

  private chart1() {
    this.areaChartOptions = {
      series: [
        {
          name: "new students",
          data: [31, 40, 28, 51, 42, 85, 77],
        },
        {
          name: "old students",
          data: [11, 32, 45, 32, 34, 52, 41],
        },
      ],
      chart: {
        height: 350,
        type: "area",
        toolbar: {
          show: false,
        },
        foreColor: "#9aa0ac",
      },
      colors: ["#9F8DF1", "#E79A3B"],
      dataLabels: {
        enabled: false,
      },
      stroke: {
        curve: "smooth",
      },
      xaxis: {
        type: "datetime",
        categories: [
          "2018-09-19T00:00:00.000Z",
          "2018-09-19T01:30:00.000Z",
          "2018-09-19T02:30:00.000Z",
          "2018-09-19T03:30:00.000Z",
          "2018-09-19T04:30:00.000Z",
          "2018-09-19T05:30:00.000Z",
          "2018-09-19T06:30:00.000Z",
        ],
      },
      legend: {
        show: true,
        position: "top",
        horizontalAlign: "center",
        offsetX: 0,
        offsetY: 0,
      },

      tooltip: {
        x: {
          format: "dd/MM/yy HH:mm",
        },
      },
    };
  }

  private chart2() {
    this.barChartOptions = {
      series: [
        {
          name: "percent",
          data: [5, 8, 10, 14, 9, 7, 11, 5, 9, 16, 7, 5],
        },
      ],
      chart: {
        height: 320,
        type: "bar",
        toolbar: {
          show: false,
        },
        foreColor: "#9aa0ac",
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: "top", // top, center, bottom
          },
        },
      },
      dataLabels: {
        enabled: true,
        formatter: function (val) {
          return val + "%";
        },
        offsetY: -20,
        style: {
          fontSize: "12px",
          colors: ["#9aa0ac"],
        },
      },

      xaxis: {
        categories: [
          "Jan",
          "Feb",
          "Mar",
          "Apr",
          "May",
          "Jun",
          "Jul",
          "Aug",
          "Sep",
          "Oct",
          "Nov",
          "Dec",
        ],
        position: "bottom",
        labels: {
          offsetY: 0,
        },
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
        crosshairs: {
          fill: {
            type: "gradient",
            gradient: {
              colorFrom: "#D8E3F0",
              colorTo: "#BED1E6",
              stops: [0, 100],
              opacityFrom: 0.4,
              opacityTo: 0.5,
            },
          },
        },
        tooltip: {
          enabled: true,
          offsetY: -35,
        },
      },
      fill: {
        type: "gradient",
        colors: ["#4F86F8", "#4F86F8"],
        gradient: {
          shade: "light",
          type: "horizontal",
          shadeIntensity: 0.25,
          gradientToColors: undefined,
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 1,
          stops: [50, 0, 100, 100],
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
        labels: {
          show: false,
          formatter: function (val) {
            return val + "%";
          },
        },
      },
    };
  }
}

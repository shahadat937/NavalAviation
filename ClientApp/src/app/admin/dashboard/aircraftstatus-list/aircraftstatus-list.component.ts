import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { ConfirmService } from "src/app/core/service/confirm.service";
import { MasterData } from "src/assets/data/master-data";
import { MatSnackBar } from "@angular/material/snack-bar";
import { DashboardService } from "../service/Dashboard.service";
import { DatePipe } from "@angular/common";
import { Role } from "src/app/core/models/role";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { AuthService } from "src/app/core/service/auth.service";

@Component({
  selector: "app-aircraftstatus-list",
  templateUrl: "./aircraftstatus-list.component.html",
  styleUrls: ["./aircraftstatus-list.component.sass"],
})
export class AircraftStatusListComponent implements OnInit {
  masterData = MasterData;
  isLoading = false;
  AricraftStatusList: any;
  CountAricraftStatus: any;
  totalAircraftCount: any;
  aricraftStatusCount: any;
  underMaincount: any;
  operationalcount: any;
  aircraftStatusList: any;
  aricraftStatusCountTotal: any;

  role: any;
  traineeId: any;
  branchId: any;

  total: any;
  isShown: boolean = false;
  userRole = Role;
  AircraftStatusForm: FormGroup;
  selectedDepartmentName: SelectedModel[];
  departmentName: any;
  departmentNameValue: any;
  totalCount: any;
  operationalCount: any;
  underMainCount: any;
  btnText: string;
  showHideDiv = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  groupArrays: { schoolName: string; courses: any }[];

  displayedColumns: string[] = [
    "acName",
    "status",
    "excepRelease",
    "upcomingMaint",
    "plannedDate",
    "requiredDays",
    "remarks",
  ];

  constructor(
    private snackBar: MatSnackBar,
    private datepipe: DatePipe,
    private fb: FormBuilder,
    private authService: AuthService,
    private dashboardService: DashboardService,
    private router: Router,
    private confirmService: ConfirmService
  ) {}

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    //this.getAircraftStatusCount();
    if (
      this.role == this.userRole.HR ||
      this.role == this.userRole.CO ||
      this.role == this.userRole.FLGWG ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAircraftStatus(0);
    } else {
      this.getAircraftStatus(this.branchId);
    }
    this.intitializeForm();
    this.AircraftStatusForm.get('plannedDate').setValue(new Date);
    //this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.btnText = "Submit";
  }

  intitializeForm() {
    this.AircraftStatusForm = this.fb.group({
      //departmentNameId: [],
      plannedDate: [""],
    });
  }

  // getAircraftStatusCount(){
  //   this.dashboardService.getAircraftStatusCount().subscribe(response => {
  //     this.aricraftStatusCountTotal=response;
  //     //this.CountAricraftStatus = response.length;
  //      console.log("this.aricraftStatusCountTotal")
  //      console.log(this.aricraftStatusCountTotal)
  //   })

  // }
  getAircraftStatus(branchId) {
    console.log(branchId);
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService.getAircraftStatus(currentDateTime, branchId).subscribe((response) => {
        this.aircraftStatusList = response;
        console.log(this.aircraftStatusList)
        console.log("aircraft Status List")
        this.aricraftStatusCount = response.length;
        // console.log("this.aircraftStatusCount")
        // console.log(this.aircraftStatusList)
        // console.log(this.aricraftStatusCount)
      });
    this.dashboardService.getOperatinalAircraftNameCount(branchId).subscribe((response) => {
        this.totalAircraftCount = response.length;
      });
    this.dashboardService.getAircraftStatusCount(branchId).subscribe((response) => {
        this.aricraftStatusCountTotal = response;
        this.totalCount=this.aricraftStatusCountTotal[0].total;
        this.operationalcount = this.aricraftStatusCountTotal[0].operational;
        this.underMaincount = this.aricraftStatusCountTotal[0].underMaint;
        console.log("this.aricraftStatusCountTotal-5555");
        console.log(this.aricraftStatusCountTotal);
      });
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    if (
      this.role == this.userRole.HR ||
      this.role == this.userRole.CO ||
      this.role == this.userRole.FLGWG ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAircraftStatus(0);
    } else {
      this.getAircraftStatus(this.branchId);
    }
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    if (
      this.role == this.userRole.HR ||
      this.role == this.userRole.CO ||
      this.role == this.userRole.FLGWG ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAircraftStatus(0);
    } else {
      this.getAircraftStatus(this.branchId);
    }
  }
  getGroupTable() {
    const groups = this.aircraftStatusList.reduce((groups, courses) => {
      const schoolName = courses.schoolName;
      if (!groups[schoolName]) {
        groups[schoolName] = [];
      }
      groups[schoolName].push(courses);
      return groups;
    }, {});

    // Edit: to add it in the array format instead
    this.groupArrays = Object.keys(groups).map((schoolName) => {
      return {
        schoolName,
        courses: groups[schoolName],
      };
    });
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print-routine").innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }

                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Aircraft Under Maintenance</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    this.isShown = true;
    var date = this.AircraftStatusForm.value["plannedDate"];

    let newDate = new Date(date);
    let checkdate = this.datepipe.transform(newDate, "MM/dd/yyyy");

    if (
      this.role == this.userRole.HR ||
      this.role == this.userRole.CO ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAircraftData(checkdate, 0);
    } else {
      this.getAircraftData(checkdate, this.branchId);
      // this.getAircraftStatus(this.branchId);
    }
  }

  getAircraftData(checkdate, departmentId) {
    this.dashboardService
      .getAircraftStatus(checkdate, departmentId)
      .subscribe((response) => {
        this.aircraftStatusList = response;
        this.totalCount = response.length;
        console.log(this.aircraftStatusList);
        console.log("this.totalCount-99");
        console.log(this.totalCount);
        console.log(this.aircraftStatusList);
        //this.operationalCount=this.totalCount[0].operational;
        this.operationalCount = this.aircraftStatusList.filter(
          (x) => x.statusId == 1
        ).length;
        this.underMainCount = this.aircraftStatusList.filter(
          (x) => x.statusId == 2
        ).length;
      });
  }
}

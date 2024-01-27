import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
//import { AirCraftFlying } from '../../models/AirCraftFlying';
//import { AirCraftFlyingService } from '../../service/AirCraftFlying.service';
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
  selector: "app-personalstate-list",
  templateUrl: "./personalstate-list.component.html",
  styleUrls: ["./personalstate-list.component.sass"],
})
export class PersonalStateListComponent implements OnInit {
  masterData = MasterData;
  isLoading = false;
  PersonalStateList: any;
  TotalPersonalCount: any;
  CountPersonalState: any;

  role: any;
  traineeId: any;
  branchId: any;

  userRole = Role;
  PersonalStateForm: FormGroup;
  selectedDepartmentName: SelectedModel[];
  departmentNameValue: any;
  departmentName: any;
  showHideDiv = false;
  btnText: string;
  isShown: boolean = false;

  totalCount: any;
  presentCount: any;
  awayCount: any;
  leaveCount: any;
  outsideCount: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "airCraftName",
    "crew",
    "mon",
    "startUp",
    "endurance",
    "fuel",
    "opaOff",
    "endurance",
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

    if (this.role == this.userRole.HR || this.role == this.userRole.CO || this.role == this.userRole.FLGWG || this.role == this.userRole.SuperAdmin) 
      {
        this.getPersonalState(0);
        this.getPersonalStateTotalCountByDepartmentId(0);
      // this.getAircraftStatus(0);
      } 
    else {
      this.getPersonalState(this.branchId);
      this.getPersonalStateTotalCountByDepartmentId(this.branchId);
      this.getDepartmentNameId(this.branchId)
      console.log("88888888888888888");
      // this.getAircraftStatus(this.branchId);
    }
   // this.getPersonalStateTotalCount();
    // this.getPersonalState();
    //this.intitializeForm();
    //this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.btnText = "Submit";
  }

  // intitializeForm() {
  //   this.PersonalStateForm = this.fb.group({
  //     departmentNameId: [],
  //     date: [''],

  //   })
  // }
  // onDepartmentNameSelectionChange(dropdown){
  //   this.isShown=true;
  //   if(dropdown.isUserInput) {
  //     console.log(dropdown.source.value.text);
  //     this.departmentNameValue=dropdown.source.value.text
  //     this.departmentName=dropdown.source.value.value;

  //   }
  // }

  getPersonalState(id) {
    this.dashboardService.getPersonalState(id).subscribe((response) => {
      this.PersonalStateList = response;
      this.CountPersonalState = response.length;
    });
  }

  getDepartmentNameId(id) {
    this.dashboardService.getDepartmentNameById(id).subscribe((response) => {
      // this.PersonalStateList = response;
      // this.CountPersonalState = response.length;
      console.log("department d");
      console.log(response);
      this.departmentName=response.schoolName
    });
  }

  getPersonalStateTotalCount() {
    this.dashboardService.getPersonalStateTotalCount().subscribe((response) => {
      this.TotalPersonalCount = response;
      this.totalCount = response[0].total;
      this.presentCount = response[0].present;
      this.awayCount = response[0].away;
      this.leaveCount = response[0].leave;
    });
  }
  getPersonalStateTotalCountByDepartmentId(departmentId) {
    this.dashboardService.getPersonalStateTotalCountByDepartmentNameId(departmentId).subscribe((response) => {
      console.log(response);
      this.TotalPersonalCount = response;
      this.totalCount = response[0].total;
      this.presentCount = response[0].present;
      this.awayCount = response[0].away;
      this.leaveCount = response[0].leave;
      this.outsideCount = response[0].outside;
    });
  }

  // GetDepartmentNameById(baseNameId){
  //   this.dashboardService.getSelectedSchoolName(baseNameId).subscribe(res=>{
  //     this.selectedDepartmentName=res
  //     console.log(res)
  //   });
  // }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    this.getPersonalState(this.branchId);
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
          <h3>Personnel State</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    //var departmentNameId =this.AirCraftFlyingForm.value['departmentNameId'];
    //var date=this.AirCraftFlyingForm.value['date'];
    //let newDate = new Date(date);
    //let checkdate = this.datepipe.transform((newDate), 'MM/dd/yyyy');
    //console.log(departmentNameId)
    //console.log(checkdate)
    //this.dashboardService.getAricraftFlyingSchedule(checkdate,this.departmentName).subscribe(response => {
    //this.AricraftFlyingScheduleList=response;
    //console.log("after")
    //console.log(this.AricraftFlyingScheduleList)
    //})
  }
}

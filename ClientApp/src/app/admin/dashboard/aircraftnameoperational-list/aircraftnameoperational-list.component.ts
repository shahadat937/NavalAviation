import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { DatePipe } from '@angular/common';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
 
// aircraftnameoperational-list
@Component({
  selector: 'app-aircraftnameoperational',
  templateUrl: './aircraftnameoperational-list.component.html',
  styleUrls: ['./aircraftnameoperational-list.component.sass']
})
export class AircraftNameOperationalListComponent implements OnInit {

  masterData = MasterData;
  userRole = Role;
  isLoading = false;

  pendingDemandList:any;
  CountpendingDemand:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
    groupArrays:{ schoolName: string; courses: any; }[];

  demandName:string;
  operationalAircraftNameList:any[];
  AircraftStatusForm: FormGroup;
  selectedDepartmentName: SelectedModel[];
  aircraftNameOperational:SelectedModel[];
  btnText: string;
  departmentName:any;
  aircraftNameCount:any;
  operationalCount:any;
  nonOperationalCount:any;
  totalAircraftCount:any;
  isShown: boolean = false ;
  operationalAllCount:any;
  nonOperationalAllCount:any;
  departmentNameValue:any;
  showHideDiv = false;


  groupArrayFlightStatus:{ departmentName: string; courses: any; }[];
  pendingAcceptancesCount:any;
  pendingProcurementCount:any;
  pendingDemandCount:any;
  nonOperationalAircraftNameCount:any;
  operationalAircraftNameCount:any;
  AricraftFlyingScheduleList:any;
  CountAricraftFlyingSchedule:any;
  todayNoticeBoardData:any[];
  groupArraysDept:{ departmentName: string; courses: any; }[];
  aircraftFlyingData:any[];

  role: any;
  traineeId: any;
  branchId: any;

  displayedColumns: string[] = [ 'ser', 'schoolName', 'name', 'manufacturer','manufacturerMobile', 'maintenenceState'];
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private datepipe: DatePipe,private fb: FormBuilder, private dashboardService: DashboardService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

   this.intitializeForm();
   this.getOperatinalAircraftNameCount();
   this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
   this.btnText = 'Submit';
   this.getAricraftFlyingSchedule();
   this.getOperatinalAircraftNameCount();
   this.getNonOperatinalAircraftNameCount();
  //  this.getTodayNoticeBoardData();
   this.getOperatinalsAircraftNameCount();

   if ( this.role == this.userRole.CO || this.role == this.userRole.SuperAdmin) {
    this.getAircraftFlyingData(0);
    this.getTodayNoticeBoardData(0);
  }else{
    this.getAircraftFlyingData(this.branchId);
    this.getTodayNoticeBoardData(this.branchId);
  }
  } 
  intitializeForm() {
    this.AircraftStatusForm = this.fb.group({
      departmentNameId: [],
      date: [''],
    })
  }
  onDepartmentNameSelectionChange(dropdown){
    this.isShown=true;
    if(dropdown.isUserInput) {
      console.log(dropdown.source.value.text);
      this.departmentNameValue=dropdown.source.value.text
      this.departmentName=dropdown.source.value.value;
      // var departmentNameId =this.AirCraftFlyingForm.value['departmentNameId'];
      // console.log(dropdown.source.value, departmentNameId);
      // this.AirCraftFlyingService.getAirCraftFlyingListByDepartmentName(dropdown.source.value,departmentNameId).subscribe(res=>{
      //   this.airCraftFlyingList=res
      //   console.log( this.airCraftFlyingList);
      // });
    }
  }
  getPendingAcceptances(){
    this.dashboardService.getPendingAcceptances(0).subscribe(response => {   
      this.pendingAcceptancesCount=response.length;
    })
  }

  getPendingProcurements(){
    this.dashboardService.getPendingProcurements(0).subscribe(response => {   
      this.pendingProcurementCount=response.length;
    })
  }
  getPendingDemand(){
    this.dashboardService.getPendingDemands(0).subscribe(response => {   
      this.pendingDemandCount=response.length;
    })
  }
  getNonOperatinalAircraftNameCount(){
    this.dashboardService.getNonOperatinalAircraftNameCount(0).subscribe(response => {   
      this.nonOperationalAircraftNameCount=response.length;
    })
  }

  getOperatinalsAircraftNameCount(){
    this.dashboardService.getOperatinalAircraftNameCount(0).subscribe(response => {   
      this.operationalAircraftNameCount=response.length;
    })
  }
  getAricraftFlyingSchedule(){
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.dashboardService.getAricraftFlyingSchedule(currentDateTime,currentDateTime,0).subscribe(response => {   
      this.AricraftFlyingScheduleList=response;
      this.CountAricraftFlyingSchedule = response.length;
      console.log(this.AricraftFlyingScheduleList)
      console.log("count aircraft flying");
      console.log(this.CountAricraftFlyingSchedule)
    })
  }
  getTodayNoticeBoardData(departmentId){
    this.dashboardService.getTodayNoticeBoardData(departmentId).subscribe(response => {   
      this.todayNoticeBoardData=response;
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
          courses: groups[departmentName]
        };
      });
    })
  }
  getAircraftFlyingData(departmentId){
    this.dashboardService.getAircraftFlyingData(departmentId).subscribe(response => {   
      this.aircraftFlyingData=response;

      const groups = this.aircraftFlyingData.reduce((groups, courses) => {
        const schoolName = courses.departmentName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrayFlightStatus = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          courses: groups[departmentName]
        };
      });
    })
  }
  toggle(){
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle(){
    this.showHideDiv= false;
    this.print();
  }
  print(){ 
     
    let printContents, popupWin;
    printContents = document.getElementById('print-routine').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
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
          <h3>Aircraft Status</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`
    );
    popupWin.document.close();
}
  onSubmit(){
    this.isShown=true;
    //var departmentNameId =this.AircraftStatusForm.value['departmentNameId'];
    var date=this.AircraftStatusForm.value['date'];
    console.log("department Id");
   // console.log(departmentNameId);
    this.dashboardService.getOperatinalAircraftNameCount(this.departmentName).subscribe(response => {   
      this.operationalAircraftNameList=response;
      console.log("operational");
       console.log(this.operationalAircraftNameList)
     
      this.aircraftNameCount=response.length;
      this.operationalCount= this.operationalAircraftNameList.filter(x=>x.maintenenceState==0).length;
      this.nonOperationalCount= this.operationalAircraftNameList.filter(x=>x.maintenenceState==1).length;
      // this.departmentName=
      // console.log("operational");
      //  console.log(this.operationalAircraftNameList)
      this.getGroupTable();
    })
  }

        getGroupTable(){
    const groups = this.operationalAircraftNameList.reduce((groups, courses) => {
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
        courses: groups[schoolName]
      };
    });
    // this.departmentName=this.groupArrays[0].schoolName;
    // console.log("999999");
    // console.log(this.groupArrays[0].schoolName);
  }

  GetDepartmentNameById(baseNameId){    
    this.dashboardService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      console.log(res)
    }); 
  }
  getOperatinalAircraftNameCount(){
    this.dashboardService.getOperatinalAircraftNameCount(0).subscribe(response => {   
      this.operationalAircraftNameList=response;
      this.totalAircraftCount=response.length;

      this.operationalAllCount= this.operationalAircraftNameList.filter(x=>x.maintenenceState==0).length;
      this.nonOperationalAllCount= this.operationalAircraftNameList.filter(x=>x.maintenenceState==1).length;
      console.log("Department Name list");
      console.log(this.operationalAircraftNameList);

      this.getGroupTable();
      console.log("5555555");
    })
  }
}

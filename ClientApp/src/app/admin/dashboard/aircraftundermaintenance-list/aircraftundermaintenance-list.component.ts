import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/core/models/role';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { AuthService } from 'src/app/core/service/auth.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-aircraftundermaintenance-list',
  templateUrl: './aircraftundermaintenance-list.component.html',
  styleUrls: ['./aircraftundermaintenance-list.component.sass']
})
export class AircraftUnderMaintenanceListComponent implements OnInit {

  masterData = MasterData;
  fileUrl ='/content/';
  isLoading = false;
  AricraftUnderMaintenanceList:any;
  CountAricraftUnderMaintenance:any;
  totalAircraftCount:any;
  role: any;
  traineeId: any;
  branchId: any;
  isShown: boolean = false ;
  userRole = Role;
  AircraftUnderMaintenanceForm: FormGroup;
  selectedDepartmentName: SelectedModel[];
  departmentName:any;
  departmentNameValue:any;
  maintenanceCount:any;
  scheduledCount:any;
  unScheduledCount:any;
  btnText: string;
  showHideDiv = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";
  groupArrays: { departmentName: string; datas: any }[];

  displayedColumns: string[] = [ 'airCraftName','typeofMaintenance','descriptionofMaint', 'commencingDate',  'plannedCompletionDate', 'remarks'];
  

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private datepipe: DatePipe, private fb: FormBuilder, private dashboardService: DashboardService,  private router: Router, private confirmService: ConfirmService) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    // this.getAricraftUnderMaintenance();
    if (
      this.role == this.userRole.HR ||
      this.role == this.userRole.CO ||
      this.role == this.userRole.FLGWG ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAricraftUnderMaintenance(0);
    } else {
      this.getAricraftUnderMaintenance(this.branchId);
    }
    this.intitializeForm();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.btnText = 'Submit';
  }

  intitializeForm() {
    this.AircraftUnderMaintenanceForm = this.fb.group({
      departmentNameId: [],
      // commencingDate: [''],
      commencingDateFrom: [''],
      commencingDateTo: [''],
    })
  }

  getAricraftUnderMaintenance(departmentNameId){
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    // this.dashboardService.getAricraftUnderMaintenance(currentDateTime,0).subscribe(response => {   
    //   this.AricraftUnderMaintenanceList=response;
    //   this.CountAricraftUnderMaintenance = response.length;
    //    console.log(this.AricraftUnderMaintenanceList)
    // })
    this.dashboardService.getOperatinalAircraftNameCount(0).subscribe(response => {   
      this.totalAircraftCount=response.length;
    })
    this.dashboardService.maintenanceScheduleListByDepartmentAndAirCraftName(0, departmentNameId).subscribe(res => {
      this.AricraftUnderMaintenanceList = res;    
      this.CountAricraftUnderMaintenance = res.length;   
      console.log(res); 
      console.log("Under Maintenance"); 
      // this gives an object with dates as keys
      const groups = this.AricraftUnderMaintenanceList.reduce((groups, datas) => {
        const departmentName = datas.departmentName; 
        if (!groups[departmentName]) {
          groups[departmentName] = [];
        }
        groups[departmentName].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          datas: groups[departmentName],
          
        };
      });

      console.log(this.groupArrays); 
      console.log("Under Maintenance List");   
      console.log(this.groupArrays.length);  
      console.log("Under Maintenance Count");           
    });
  }
  GetDepartmentNameById(baseNameId){    
    this.dashboardService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      console.log(res)
    }); 
  }

  // pageChanged(event: PageEvent) {
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getAricraftUnderMaintenance(this.branchId);
  // }

  // applyFilter(searchText: any) {
  //   this.searchText = searchText;
  //   this.getAricraftUnderMaintenance(this.branchId);
  // }
  // getGroupTable(){
  //   const groups = this.AricraftUnderMaintenanceList.reduce((groups, courses) => {
  //     const schoolName = courses.schoolName;
  //     if (!groups[schoolName]) {
  //       groups[schoolName] = [];
  //     }
  //     groups[schoolName].push(courses);
  //     return groups;
  //   }, {});

  //   // Edit: to add it in the array format instead
  //   this.groupArrays = Object.keys(groups).map((schoolName) => {
  //     return {
  //       schoolName,
  //       courses: groups[schoolName]
  //     };
  //   });
   
   
  // }
  onDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.AircraftUnderMaintenanceForm.value['departmentNameId'];
    this.getAricraftUnderMaintenance(departmentNameId);
    // if(dropdown.isUserInput) {
    //   console.log(dropdown.source.value.text);
    //   this.departmentNameValue=dropdown.source.value.text
    //   this.departmentName=dropdown.source.value.value;
      
    // }
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
          <h3>Aircraft Under Maintenance</h3>
          
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
    var departmentNameId =this.AircraftUnderMaintenanceForm.value['departmentNameId'];
    var dateFrom=this.AircraftUnderMaintenanceForm.value['commencingDateFrom'];
    var dateTo=this.AircraftUnderMaintenanceForm.value['commencingDateTo'];
    
    let newDateFrom = new Date(dateFrom);
    let newDateTo = new Date(dateTo);
    let checkdateFrom = this.datepipe.transform((newDateFrom), 'MM/dd/yyyy');
    let checkdateto = this.datepipe.transform((newDateTo), 'MM/dd/yyyy');

    // this.getAricraftUnderMaintenance(departmentNameId)
    //console.log(departmentNameId)
    //console.log(checkdate)
    // this.dashboardService.getAricraftUnderMaintenance(checkdate,this.departmentName).subscribe(response => {   
    //   this.AricraftUnderMaintenanceList=response;
    //   this.maintenanceCount=response.length;
    //   this.scheduledCount= this.AricraftUnderMaintenanceList.filter(x=>x.maintenanceTypeId==1 || x.maintenanceTypeId==12 ).length;
    //   this.unScheduledCount= this.AricraftUnderMaintenanceList.filter(x=>x.maintenanceTypeId==2 || x.maintenanceTypeId==13).length;
    // })

    this.dashboardService.maintenanceScheduleListByDepartmentAndAirCraftNameFilter(0, departmentNameId,checkdateFrom,checkdateto).subscribe(res => {
      this.AricraftUnderMaintenanceList = res;    
      this.CountAricraftUnderMaintenance = res.length;   
      console.log(this.AricraftUnderMaintenanceList); 
      // this gives an object with dates as keys
      const groups = this.AricraftUnderMaintenanceList.reduce((groups, datas) => {
        const departmentName = datas.departmentName;
        if (!groups[departmentName]) {
          groups[departmentName] = [];
        }
        groups[departmentName].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          datas: groups[departmentName],
        };
      });

      console.log(this.groupArrays);           
    });
    
  }
  
}

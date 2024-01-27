import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators,FormControl,FormGroupDirective,NgForm} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { DatePipe } from '@angular/common';
import {TrainingCrewService} from '../service/TrainingCrew.service';
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";
// import { DashboardService } from "../service/Dashboard.service";
import { DashboardService } from 'src/app/admin/dashboard/service/Dashboard.service';

@Component({
  selector: 'app-attendance-list',
  templateUrl: './attendance-list.component.html',
  styleUrls: ['./attendance-list.component.sass']
})
export class AttendanceListComponent implements OnInit {
   masterData = MasterData;
   userRole = Role;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  AttendanceForm: FormGroup;
  validationErrors: string[] = [];
  traineeForm: FormGroup;
  traineeListForAttendance:any[];
  showHideDiv = false;
  isShown: boolean = false ;
  searchText: any = '';
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  //searchText="";
  displayedColumns: string[] = ['ser','traineePNo','attendanceStatus','bnaAttendanceRemarksId'];
  dataSource ;
  txtRemarks:boolean =false;
  spanAbsent:boolean =false;
  popup = false;
  role: any;
  traineeId: any;
  branchId: any;
  totalCount:any;
  presentCount:any;
  awayCount:any;
  leaveCount:any;
  departmentNameId: any = 0;
  officerStatusId: any = 0;
  date: any = '';
  TotalPersonalCount: any;
  selectedDepartmentName:SelectedModel[];
  selectOfficersStatuses:SelectedModel[];
  departmentName:any;
  attendanceList:any[];
  constructor(private snackBar: MatSnackBar,private dashboardService: DashboardService,private authService: AuthService,private TrainingCrewService:TrainingCrewService,private datepipe:DatePipe, private confirmService: ConfirmService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
   // this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
   this.role = this.authService.currentUserValue.role.trim();
   this.traineeId = this.authService.currentUserValue.traineeId.trim();
   this.branchId = this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('attendanceId'); 
    if (id) {
      this.pageTitle = 'Edit Attendance'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
    } else {
      this.pageTitle = 'Attendance';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin && this.role != this.userRole.CO && this.role != this.userRole.HR) {
      this.AttendanceForm.get("departmentNameId").setValue(this.branchId);
     // this.onDepartmentSelectionChange();
    //  console.log("4444444444444444444");
    //  console.log(this.branchId+"55");
    }
   this.getPersonalStateTotalCountByDepartmentId(this.branchId);
   this.getDepartmentNameId(this.branchId);
   this.getselectedOfficersStatuses();
   this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
   //this.getAttendanceList();
  }
  intitializeForm() {
    this.AttendanceForm = this.fb.group({
      attendanceDate:[], 
      departmentNameId:[],
      officerStatusId:[],
      searchtext:[],
    })
  }

  getselectedOfficersStatuses(){
    this.TrainingCrewService.getselectedOfficersStatuses().subscribe(res=>{
      this.selectOfficersStatuses=res
      console.log(this.selectOfficersStatuses);
    });
  }

  GetDepartmentNameById(baseNameId){    
    this.dashboardService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      console.log("eeeeeeeeeeeee");
      console.log(this.selectedDepartmentName);
      console.log(res)
    }); 
  }
  // getAttendanceList() {
  //   console.log(this.AttendanceForm.value);
  //   var findArr = this.AttendanceForm.value;
  //   let attendDate =this.datepipe.transform(findArr.attendanceDate, 'MM/dd/yyyy');
  //   console.log("444444444444");
  //   console.log(findArr)
  //   this.TrainingCrewService.traineeAttendanceList(attendDate == null ? 0 : attendDate,findArr.departmentNameId == null ? 0 : findArr.departmentNameId,findArr.officerStatusId == null ? 0 : findArr.officerStatusId,this.searchText).subscribe((res) => {
  //     this.attendanceList = res;
  //     console.log("data list");
  //     console.log(res);
  //   });
  // }
  // applyFilter(searchText: any) {
  //   this.searchText = searchText;
  //   this.getAttendanceList();
  // }
   getPersonalStateTotalCountByDepartmentId(departmentId) {
    this.dashboardService.getPersonalStateTotalCountByDepartmentNameId(departmentId).subscribe((response) => {
      this.TotalPersonalCount = response;
      // this.totalCount = response[0].total;
      // this.presentCount = response[0].present;
      // this.awayCount = response[0].away;
      // this.leaveCount = response[0].leave;
    });
  }
  getDepartmentNameId(id) {
    this.dashboardService.getDepartmentNameById(id).subscribe((response) => {
      console.log("department d");
      console.log(response);
      this.departmentName=response.schoolName
    });
  }
   loadTrainingCrewData(){ 

      console.log("course Section Id");
      console.log(this.branchId);

      this.isShown=true;

      this.TrainingCrewService.traineeAttendanceList(this.branchId,1,0,this.searchText).subscribe(res=>{
        this.traineeListForAttendance=res; 

        console.log("trainee crew list");
        console.log(this.traineeListForAttendance);
        for(let i=0;i < this.traineeListForAttendance.length;i++ ){
          this.traineeListForAttendance[i].attendanceStatus=true;
        }
        console.log("Trainee Nomination list");
       });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
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
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-action-si{
                      display: none;
                    }
        
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
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
          <h3>Sailor Biodata List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  onSubmit() {
     console.log(this.AttendanceForm.value);
     var findArr = this.AttendanceForm.value;
     let attendDate =this.datepipe.transform(findArr.attendanceDate, 'MM/dd/yyyy');
     console.log("444444444444");
     console.log(findArr)
     this.TrainingCrewService.traineeAttendanceList(attendDate == null ? 0 : attendDate,findArr.departmentNameId == null ? 0 : findArr.departmentNameId,findArr.officerStatusId == null ? 0 : findArr.officerStatusId,findArr.searchtext == null ? "" : findArr.searchtext).subscribe(res=>{
       this.attendanceList=res
       console.log("attendance list");
       console.log(this.attendanceList)
     }); 
  }
}

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
  selector: 'app-new-attendance',
  templateUrl: './new-attendance.component.html',
  styleUrls: ['./new-attendance.component.sass']
})
export class NewAttendanceComponent implements OnInit {
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
  TotalPersonalCount: any;
  departmentName:any;
  attendanceList:any;
  isAttendanceCompleted:any;
  constructor(private snackBar: MatSnackBar,private dashboardService: DashboardService,private authService: AuthService,private TrainingCrewService:TrainingCrewService,private datepipe:DatePipe, private confirmService: ConfirmService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
   // this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
   this.role = this.authService.currentUserValue.role.trim();
   this.traineeId = this.authService.currentUserValue.traineeId.trim();
   this.branchId = this.authService.currentUserValue.branchId.trim();

   let today = this.datepipe.transform(new Date(), "MM/dd/yyyy");

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
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    console.log(currentDateTime);
    this.AttendanceForm.get('attendanceDate').setValue(currentDateTime);
    
   if(this.role == this.userRole.HR){
    this.branchId = 0;
   }
   else{
   this.getDepartmentNameId(this.branchId);
   }

   this.loadTrainingCrewData();
   this.getPersonalStateTotalCountByDepartmentId(this.branchId);

   this.TrainingCrewService.traineeAttendanceList(today,this.branchId,0,this.searchText).subscribe(res=>{
    this.attendanceList=res;
    this.isAttendanceCompleted = res.length;
    console.log("attendance list");
    console.log(this.attendanceList)
    console.log(this.isAttendanceCompleted)
  }); 
  }
  intitializeForm() {
    this.AttendanceForm = this.fb.group({
      attendanceDate:[], 
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
    })
  }

  getControlLabel(index: number,type: string){
    return  (this.AttendanceForm.get('traineeListForm') as FormArray).at(index).get(type).value;
   }

   private createTraineeData() {
  
    return this.fb.group({   
      departmentNameId:[''],
      rank:[''],
      name:[''],
      pno:[''],
      attendanceStatus: [''],
      sailorRank:[''],
      trainingCrewId:[''],
      sailorRankId:[''],
      officersStatusId:[],
      officersStatus:['']
    });
  }
  clearList() {
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
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
                  
                    .table.table.ex-mrk-entry .cl-mrk-as{
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
          <h3>Attendance List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  getTraineeListonClick(){
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];
    for (let i = 0; i < this.traineeListForAttendance.length; i++) {
      control.push(this.createTraineeData()); 
    }
    this.AttendanceForm.patchValue({ traineeListForm: this.traineeListForAttendance });
   }

   getPersonalStateTotalCountByDepartmentId(departmentId) {
    this.dashboardService.getPersonalStateTotalCountByDepartmentNameId(departmentId).subscribe((response) => {
      this.TotalPersonalCount = response;
      this.totalCount = response[0].total;
      this.presentCount = response[0].present;
      this.awayCount = response[0].away;
      this.leaveCount = response[0].leave;
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
   loadTrainingCrewData(){ 

    // if(this.role == this.userRole.HR){
    //   var branchId = null;
    //  }
      console.log("course Section Id");
      console.log(this.branchId);

      this.isShown=true;
      this.clearList();

      this.TrainingCrewService.traineeAttendance(this.branchId,1).subscribe(res=>{
        this.traineeListForAttendance=res; 

        console.log("trainee crew list");
        console.log(this.traineeListForAttendance);
        for(let i=0;i < this.traineeListForAttendance.length;i++ ){
          if(this.traineeListForAttendance[i].officersStatusId == 1){
            this.traineeListForAttendance[i].attendanceStatus=true;
          }else{
            this.traineeListForAttendance[i].attendanceStatus=false;
          }
          
        }
        
        this.getTraineeListonClick();
        console.log("Trainee Nomination list");
       });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
   // const id = this.AttendanceForm.get('attendanceId').value;
     console.log(this.AttendanceForm.value);
    // var data = this.AttendanceForm.value.traineeListForm.filter((x) => x.attendanceStatus === false && x.bnaAttendanceRemarksId === null );
    // if(data.length >0){
    //   this.popup =true;
    //   console.log("Not Saved");
    // }    
    // else{
    //   console.log("Saved");
    //    this.loading = true;
      this.TrainingCrewService.saveAttendanceList(this.AttendanceForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Inserted Successfully ', '', {

          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      });
  }
}

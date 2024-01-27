import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
// import { Router } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { DashboardService } from '../service/Dashboard.service';

@Component({
  selector: 'app-personalstatebystatus-list',
  templateUrl: './personalstatebystatus-list.component.html',
  styleUrls: ['./personalstatebystatus-list.component.sass']
})

export class PersonalStateByStatusListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;
  PersonnelFilterForm: FormGroup;
  searchText="";
  userRole = Role;
  departmentNameId:any;
  officersStatusId:any;
  presentBilletId:any;
  traineeId:any;
  role:any;
  branchId:any;
  personalStateList:any[];
  selectedDepartmentName:any[];
  showHideDiv = false;
  // displayedColumns: string[] = [ 'ser', 'itemName', 'trade', 'lastDateofCalibrated','nextDueDate', 'presentState', 'remarks', 'actions'];
  //dataSource: MatTableDataSource<CallibrationState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private fb: FormBuilder, private dashboardService: DashboardService,private authService: AuthService, private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute) { }
  
  ngOnInit() {
    this.officersStatusId = this.route.snapshot.paramMap.get('officersStatusId'); 
    this.presentBilletId = this.route.snapshot.paramMap.get('presentBilletId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    this.intitializeForm();
    this.getSelectedEmployeeType();

    if(this.role == this.userRole.CO || this.role == this.userRole.SuperAdmin || this.role == this.userRole.HR){
      this.departmentNameId = 0;
      this.getpersonalStateTotalByStatus(this.departmentNameId,this.officersStatusId,this.presentBilletId,0)
   }else{
     this.departmentNameId = this.branchId;
     console.log("dept id");
     console.log(this.departmentNameId);
     this.getpersonalStateTotalByStatus(this.departmentNameId,this.officersStatusId,this.presentBilletId,0)
   }
    

  //  this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  //  this.GetSelectedSparesCategory();
  //  this.getBarcodePrintList(0,0);
   //this.getCalibrationStateList(this.departmentNameId);
  }
 
 
  intitializeForm() {
    this.PersonnelFilterForm = this.fb.group({
      employeeTypeId: []
    })
  }

  getpersonalStateTotalByStatus(departmentNameId,officersStatusId,presentBilletId,employeeTypeId){
    this.dashboardService.getpersonalStateTotalByStatus(departmentNameId,officersStatusId,presentBilletId,employeeTypeId).subscribe(response => {   
      this.personalStateList=response;
      console.log(this.personalStateList)
    })
  }

  getSelectedEmployeeType(){
    this.dashboardService.getSelectedEmployeeType().subscribe(response => {   
      this.selectedDepartmentName=response;
    })
  }

  onSubmit(){
    var employeeTypeId = this.PersonnelFilterForm.value['employeeTypeId'];

    this.getpersonalStateTotalByStatus(this.departmentNameId,this.officersStatusId,this.presentBilletId,employeeTypeId)
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
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-action{
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
          <h3>Personnel List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

}

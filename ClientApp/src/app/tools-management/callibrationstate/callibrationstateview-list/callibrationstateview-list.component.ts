import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
import { CallibrationState } from '../../models/CallibrationState';
import { CallibrationStateService } from '../../service/CallibrationState.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-callibrationstateview',
  templateUrl: './callibrationstateview-list.component.html',
  styleUrls: ['./callibrationstateview-list.component.sass']
})
export class CallibrationStateViewListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: CallibrationState[] = [];
  isLoading = false;
  MaintanenceScheduleForm: FormGroup;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  userRole = Role;
  departmentNameId:any;
  
  traineeId:any;
  role:any;
  branchId:any;
  calibrationStateList:any[]; 
   showHideDiv = false;

  // displayedColumns: string[] = [ 'ser', 'itemName', 'trade', 'lastDateofCalibrated','nextDueDate', 'presentState', 'remarks', 'actions'];
  //dataSource: MatTableDataSource<CallibrationState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private fb: FormBuilder,private authService: AuthService, private CallibrationStateService: CallibrationStateService, private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if(this.role == this.userRole.CO || this.role == this.userRole.SuperAdmin){
      this.departmentNameId = 0;
   }else{
     this.departmentNameId = this.branchId;
     console.log("dept id");
     console.log(this.departmentNameId);
   }
    
   this.intitializeForm();
   this.applyFilter("");
 // this.getCalibrationStateList(this.departmentNameId);
  }
 
  intitializeForm() {
    this.MaintanenceScheduleForm = this.fb.group({
      callibrationStateId: [0],
      nameOfItem: [''],
      MaintanenceScheduleList: this.fb.array([this.createIssueRegisterData()]),
    });
  }
  private createIssueRegisterData() {
    return this.fb.group({
      callibrationStateId:[0],
      calibrationDate: [''],
      nameOfItem:[''],
      lastCalibrationDate:[''],
      nextCalibrationDate:[''],
      nextDate:[''],
      itemDetailId:[''],
      itemStoreId:[''],
      tradeId:[''],
      departmentNameId:[''],
      completedDate:[''],
      partNo:[''],
      model:[''],
      brand:[''],
      itemSerNo:['']
    });
  }

  getControlLabel(index: number, type: string) {
    return (this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).get(type).value;
     
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  onCompletedButtonClick(event,data){
    console.log(data);
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
      if (result) {
    this.CallibrationStateService.submit(data.value).subscribe(response => {
      // this.router.navigateByUrl('/tools-management/callibrationstate-list');
      this.reloadCurrentRoute();
      this.snackBar.open('Information Inserted Successfully ', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-success'
      });
    })
  }
    })
  }
  getCalibrationStateList(departmentNameId) {    
    console.log(departmentNameId)
    this.isLoading = true;
    this.CallibrationStateService.getCalibrationStateForTools(departmentNameId).subscribe(res => {
      this.calibrationStateList = res; 
      console.log("calibration state");
     console.log(this.calibrationStateList);
     console.log("calibration state");
      this.clearList();
      this.getItemStoreListonClick();
      
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
          <h3>Inventory History List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  
  applyFilter(searchText){
    this.isLoading = true;
    this.CallibrationStateService.getCalibrationStateListForTools(this.departmentNameId,searchText).subscribe(response => {
      this.calibrationStateList = response; 
      console.log("after search");
      console.log(this.calibrationStateList);
      console.log("calibration state1");
      console.log(response)
      this.clearList();
      this.getItemStoreListonClick();
    })
  }
  clearList() {
    const control = <FormArray>this.MaintanenceScheduleForm.controls["MaintanenceScheduleList"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  getItemStoreListonClick() {
    const control = <FormArray>this.MaintanenceScheduleForm.controls["MaintanenceScheduleList"];
    for (let i = 0; i < this.calibrationStateList.length; i++) {
      control.push(this.createIssueRegisterData());
      console.log("Callibration Data1")
    }
    this.MaintanenceScheduleForm.patchValue({
      MaintanenceScheduleList: this.calibrationStateList,
     
    });
    console.log(this.calibrationStateList)
    console.log("Callibration Data")
  }

  deleteItem(row) {
    const id = row.callibrationStateId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.CallibrationStateService.delete(id).subscribe(() => {
        //  this.getCallibrationStates();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
  }
}

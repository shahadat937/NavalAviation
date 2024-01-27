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
  selector: 'app-callibrationstate',
  templateUrl: './callibrationstate-list.component.html',
  styleUrls: ['./callibrationstate-list.component.sass']
})
export class CallibrationStateListComponent implements OnInit {

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
   this.getCalibrationStateList(this.departmentNameId);
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
      this.clearList();
      this.getItemStoreListonClick();
      
    });
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
    }
    this.MaintanenceScheduleForm.patchValue({
      MaintanenceScheduleList: this.calibrationStateList,
    });
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

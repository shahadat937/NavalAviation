import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
import { MatTableDataSource } from '@angular/material/table';
import { MaintenanceSchedule } from '../../models/MaintenanceSchedule';
import { MaintenanceScheduleService } from '../../service/MaintenanceSchedule.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { environment } from 'src/environments/environment';
 

@Component({
  selector: 'app-maintenanceschedule-list',
  templateUrl: './maintenanceschedule-list.component.html',
  styleUrls: ['./maintenanceschedule-list.component.sass']
})
export class MaintenanceScheduleListComponent implements OnInit {

  MaintanenceScheduleForm: FormGroup;
  MaintanenceScheduleListFromData:any[];
  masterData = MasterData;
  fileUrl = '/content/';
  ELEMENT_DATA: MaintenanceSchedule[] = [];
  isLoading = false;
  userRole = Role;
  departmentNameId:any;
  showHideDiv = false;
  traineeId:any;
  role:any;
  branchId:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'departmentName','airCraftName', 'categoryType', 'category', 'subCategory', 'mpStatus',  'actions'];
  dataSource: MatTableDataSource<MaintenanceSchedule> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private fb: FormBuilder,private authService: AuthService, private MaintenanceScheduleService: MaintenanceScheduleService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if(this.role == this.userRole.CO || this.role == this.userRole.SuperAdmin){
      this.departmentNameId = 0;
      this.getMaintenanceScheduleList(this.departmentNameId);
   }else{
     this.departmentNameId = this.branchId;
     this.getMaintenanceScheduleList(this.departmentNameId);
   }
    
    this.intitializeForm();
    
  }

  intitializeForm() {
    this.MaintanenceScheduleForm = this.fb.group({
      issueRegisterId: [0],
      sparesCategoryId: [],
      departmentNameId: [],
      itemDetailId: [],
      partNo: [""],
      //issueStatusId: [],
      trainingCrewId: [],
      pno: [""],
      totalReceivedQty: [""],
      issueDate: [""],
      issuedTo: [""],
      reason: [""],
      remarks: [""],
      availableQtyBeforeIssue: [""],
      availableQtyAfterIssue: [""],
      receivedPerson: [""],
      isActive: [true],
      MaintanenceScheduleList: this.fb.array([this.createIssueRegisterData()]),
    });
    // //autocomplete for pno
    // this.IssueRegisterForm.get("pno").valueChanges.subscribe((value) => {
    //   this.getSelectedTraineeCrewByPno(value);
    // });
    // //autocomplete for PartNo
    // this.IssueRegisterForm.get("partNo").valueChanges.subscribe((value) => {
    //   this.getSelectedItemDetailByPartNo(value);
    // });
  }

  private createIssueRegisterData() {
    return this.fb.group({
      maintenanceScheduleId: [""],
      airCraftName: [""],
      subCategory: [""],
      startInspDate: [""],
      extensionDays: [""],
      maintenancePlanning: [""],
      category: [''],
      extensionGiven:[""],
      completedDate:[],
      endInspDate:[],
      progressBar: [""],
      completedStatus: [],
      jobCard: [""],
      doc: [""],
      verificationCompletStatus:[""],
      lastInspectiobFh:[''],
      lastInspectiobOh:['']
      // itemDetailId: [""],
      // itemStorId: [""],
      // departmentNameId: [""],
      // sparesCategoryId: [""],
      // isRefundable: [false],
      // isChecked: [false],
      // totalReceivedQty: [""],
      // availableQty: [""],
      // returnQty: [""],
      // itemReceivedDate: [],
      // warrantyEndDate: [],
      // lastMaintenanceDate:[],
      // lastCalibrationDate:[],
      // acctStore: [""],
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }


  inActiveItem(row){
    const id = row.value.maintenanceScheduleId; 
          this.confirmService.confirm('Confirm Approved message', 'Are You Sure Approved This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.MaintenanceScheduleService.approvedMaintenanceSchedule(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.reloadCurrentRoute();
            this.snackBar.open('Information Approved Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    
}
  getControlLabel(index: number, type: string) {
    return (this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).get(type).value;
  }
   
  getMaintenanceScheduleList(departmentNameId) {    
    console.log(departmentNameId)
    this.isLoading = true;
    this.MaintenanceScheduleService.maintenanceScheduleListByDepartmentAndAirCraftName(0, departmentNameId).subscribe(res => {
      this.MaintanenceScheduleListFromData = res; 
      console.log("maintenence schedule list");
      console.log(this.MaintanenceScheduleListFromData);
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
    for (let i = 0; i < this.MaintanenceScheduleListFromData.length; i++) {
      control.push(this.createIssueRegisterData());
    }

    this.MaintanenceScheduleForm.patchValue({
      MaintanenceScheduleList: this.MaintanenceScheduleListFromData,
    });
  }

  onFileChanged(event, index) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      (this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).patchValue({
        doc: file,
      });
      console.log((this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).value)
    }
  }

  onCompletedButtonClick(event, data, index, status){
    const id = data.value.id;  
    console.log(data.value);
    console.log(status);


    (this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).get('completedDate').setValue((new Date((this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).get('completedDate').value)).toUTCString());
    (this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).get('completedStatus').setValue(status);

    console.log((this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).value);

    const formData = new FormData();
    for (const key of Object.keys((this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).value)) {
      const value = (this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).value[key];
      formData.append(key, value);
    }

    this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
      if (result) {
        this.MaintenanceScheduleService.updateScheduleMaintenence(+id, formData).subscribe(response => {
          this.reloadCurrentRoute();
          this.snackBar.open('Information Updated Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        }, error => {
          //this.validationErrors = error;
        }
        )
      }
    })
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
                    .table.table.tbl-by-group.db-li-s-in.mnt-scdle-lst tr .action{
                      display: none;
                    }
                    .table.table.tbl-by-group.db-li-s-in.mnt-scdle-lst tr .cl-mrk-document{
                      display: none;
                    }
                    .table.table.tbl-by-group.db-li-s-in.mnt-scdle-lst tr .cl-mrk-progress{
                      display: none;
                    }
                    .table.table.tbl-by-group.db-li-s-in.mnt-scdle-lst tr .cl-mrk.custom-date{
                      display: none;
                    }
              
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
                    }
                    
                    .table.table.tbl-by-group.db-li-s-in tr .fa-file-pdf tbl-pdf {
                    display:none;
                  }
                  .table.table.tbl-by-group.db-li-s-in tr .btn-tbl-edit {
                    display:none;
                  }
                  .table.table.tbl-by-group.db-li-s-in tr .btn-tbl-delete {
                    display:none;
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
          <h3>Maintenance Plan List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  deleteItem(row) {
    console.log(row)
    const id = row.value.maintenanceScheduleId; 
    console.log(id)
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MaintenanceScheduleService.delete(id).subscribe(() => {
          this.getMaintenanceScheduleList(this.departmentNameId);
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

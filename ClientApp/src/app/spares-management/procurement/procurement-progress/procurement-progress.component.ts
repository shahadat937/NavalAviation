import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
import { MatTableDataSource } from '@angular/material/table';
// import { MaintenanceSchedule } from '../../models/MaintenanceSchedule';
// import { MaintenanceScheduleService } from '../../service/MaintenanceSchedule.service';
import { Procurement } from '../../models/Procurement';
import { ProcurementService } from '../../service/Procurement.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
 

@Component({
  selector: 'app-procurement-progress',
  templateUrl: './procurement-progress.component.html',
  styleUrls: ['./procurement-progress.component.sass']
})
export class ProcurementProgressComponent implements OnInit {

  ProcurementListForm: FormGroup;
  MaintanenceScheduleListFromData:any[];
  ProcurementListFromData:any[];
  masterData = MasterData;
  // ELEMENT_DATA: MaintenanceSchedule[] = [];
  isLoading = false;
  userRole = Role;
  departmentNameId:any;
  groupArrays: { departmentName: string; datas: any }[];
  traineeId:any;
  role:any;
  branchId:any;
  
  itemCount: any = 0;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  // displayedColumns: string[] = [ 'ser', 'departmentName','airCraftName', 'categoryType', 'category', 'subCategory', 'mpStatus',  'actions'];
  // dataSource: MatTableDataSource<MaintenanceSchedule> = new MatTableDataSource();
  
  displayedColumns: string[] = [ 'ser', 'itemDetail','itemName','tenderNumber', 'dateOfTenderFloat', 'dateOfDelivery', 'qty','actions'];
  dataSource: MatTableDataSource<Procurement> = new MatTableDataSource();

  constructor(private snackBar: MatSnackBar,private ProcurementService: ProcurementService,private fb: FormBuilder,private authService: AuthService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    this.intitializeForm();

    if(this.role == this.userRole.SuperAdmin || this.role == this.userRole.CO){
      this.getProcurementsList(0);  
    }else{
      this.getProcurementsList(this.branchId);  
    }
  }

  intitializeForm() {
    this.ProcurementListForm = this.fb.group({
      
      ProcurementList: this.fb.array([this.createIssueRegisterData()]),
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
      procurementId: [""],
      departmentName: [""],
      itemDetail: [""],
      itemName: [""],
      qty: [""],
      dateOfDelivery: [""],
      supplier:[""],
      reason:[""],
      latestProgress:[""],
      // completedDate:[],
      // endInspDate:[]
      
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }



  getControlLabel(index: number, type: string) {
    return (this.ProcurementListForm.get("ProcurementList") as FormArray).at(index).get(type).value;
  }
 
  // getMaintenanceScheduleList(departmentNameId) {    
  //   console.log(departmentNameId)
  //   this.isLoading = true;
  //   this.MaintenanceScheduleService.maintenanceScheduleListByDepartmentAndAirCraftName(0, departmentNameId).subscribe(res => {
  //     this.MaintanenceScheduleListFromData = res; 
      
  //     console.log(this.MaintanenceScheduleListFromData);
  //     this.clearList();
  //     this.getItemStoreListonClick();
      
  //   });
  // }


  getProcurementsList(departmentId) {
    this.isLoading = true;
    this.ProcurementService.getProcurementListByDepartmentNameId( this.paging.pageIndex, 100000, this.searchText, this.masterData.sparescategory.spares, departmentId).subscribe((response) => {
      this.dataSource.data = response.items;
      this.ProcurementListFromData= response.items;
      // this.itemCount = response.items.length;
      //console.log("dddddd");
      console.log(this.dataSource.data);
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;
      this.clearList();
      this.getItemStoreListonClick();
    });
    
  }

  clearList() {
    const control = <FormArray>this.ProcurementListForm.controls["ProcurementList"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  getItemStoreListonClick() {
    const control = <FormArray>this.ProcurementListForm.controls["ProcurementList"];
    for (let i = 0; i < this.ProcurementListFromData.length; i++) {
      control.push(this.createIssueRegisterData());
    }

    // for(let i=0;i<=this.selectedItemStoreList.length;i++){
    //   console.log(this.selectedItemStoreList['itemDetail'].value)
    // }
    // this.selectedItemStoreList=this.selectedItemStoreList.filter(x=>x.status ==true)
    this.ProcurementListForm.patchValue({
      ProcurementList: this.ProcurementListFromData,
    });
  }

  onCompletedButtonClick(event, data){
    const id = data.value.id;  
    console.log(data.value);
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
      if (result) {
        this.ProcurementService.updateProcurement(+id,data.value).subscribe(response => {
          this.reloadCurrentRoute();
        //  this.router.navigateByUrl('/spares-management/add-procurement');
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

  deleteItem(row) {
    console.log(row)
    const id = row.value.maintenanceScheduleId; 
    console.log(id)
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        // this.MaintenanceScheduleService.delete(id).subscribe(() => {
        //   // this.getMaintenanceScheduleList(this.departmentNameId);
        //   this.snackBar.open('Information Deleted Successfully ', '', {
        //     duration: 2000,
        //     verticalPosition: 'bottom',
        //     horizontalPosition: 'right',
        //     panelClass: 'snackbar-danger'
        //   });
        // })
      }
    })
  }
}

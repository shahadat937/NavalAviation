import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MeaSquadronState } from '../../models/MeaSquadronState';
import { MeaSquadronStateService } from '../../service/MeaSquadronState.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
 

@Component({
  selector: 'app-workprogress',
  templateUrl: './workprogress-list.component.html',
  styleUrls: ['./workprogress-list.component.sass']
})
export class MeaWorkProgressListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MeaSquadronState[] = [];
  isLoading = false;
  roleDisable: boolean = true;
  MeaSquadronStateForm: FormGroup;
  MeaSquadronStateListFromData:any[];
  userRole = Role;
  status:any;
  traineeId:any;
  role:any;
  branchId:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'itemName', 'trad', 'workOrderNo','dateofSubmition', 'workShop','status', 'actions'];
  dataSource: MatTableDataSource<MeaSquadronState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private fb: FormBuilder,private route: ActivatedRoute,private authService: AuthService, private MeaSquadronStateService: MeaSquadronStateService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
     //this.status=this.route.snapshot.paramMap.get('status');
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
    this.getMeaSquadronStates();

    // if(this.role == this.userRole.CO || this.role == this.userRole.MEA){
    //   this.roleDisable = false;
    // }
    this.intitializeForm();
  }
  intitializeForm() {
    this.MeaSquadronStateForm = this.fb.group({
      meaSquadronStateId: [0],
      departmentNameId:[],
      presentStateId:[],
      tradeId:[],
      itemDetailId:[],
      conditionOfItemId:[],
      meaWorkShopId:[],
      modelNo:[],
      registrationNo:[],
      deliveryDate:[],
      totalhouratDelivey:[],
      totalHouratOccation:[],
      qty:[],
      ataCode:[],
      dateofInstall:[],
      totalLandingCycles:[],
      totalAcHour:[],
      resonForRemoval:[],
      description:[],
      workOrderNo:[],
      dateofSubmition:[],
      dateOfDiscrepancy:[],
      serNo:[''],
      docUpload:[''],
      //document:[''],
      workOrderReceived:[''],
      workOrderDate:[''],
      workshopName: [''],
      remarks: [''],
      isActive: [true],
      meaSquadronStateList: this.fb.array([this.createmeaSquadronStateData()]),
    });
  }
  private createmeaSquadronStateData() {
    return this.fb.group({
      meaSquadronStateId: [""],
      itemName: [""],
      pattNo: [""],
      trad: [""],
      controlNo:[""],
      workOrderNo: [""],
      dateofSubmition: [""],
      workShop:[""],
      remarks:[""],
      docUpload:[''],
      //document:[''],
    });
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      this.MeaSquadronStateForm.patchValue({
        document: file,
      });
    }
  }
  getMeaSquadronStates() {
    this.isLoading = true;
    this.MeaSquadronStateService.getMeaSquadronStates(this.paging.pageIndex, this.paging.pageSize,this.searchText,0).subscribe(response => {
      this.MeaSquadronStateListFromData = response.items; 
      console.log("this..data")
      console.log(this.MeaSquadronStateListFromData)
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      this.clearList();
      this.getItemStoreListonClick();
    })
  }
  getControlLabel(index: number, type: string) {
    return (this.MeaSquadronStateForm.get("meaSquadronStateList") as FormArray).at(index).get(type).value;
  }
  clearList() {
    const control = <FormArray>this.MeaSquadronStateForm.controls["meaSquadronStateList"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }
  getItemStoreListonClick() {
    const control = <FormArray>this.MeaSquadronStateForm.controls["meaSquadronStateList"];
    for (let i = 0; i < this.MeaSquadronStateListFromData.length; i++) {
      control.push(this.createmeaSquadronStateData());
    }
    this.MeaSquadronStateForm.patchValue({
      meaSquadronStateList: this.MeaSquadronStateListFromData,
    });
  }
  onCompletedButtonClick(event, data, index){
    const id = data.value.id;  
    console.log("data.value");
    console.log(data.value);
    //console.log(status);
    
    // console.log(this.MeaSquadronStateForm.value);

    // const formData = new FormData();
    // for (const key of Object.keys(this.MeaSquadronStateForm.value)) {
    //   const value = this.MeaSquadronStateForm.value[key];
    //   formData.append(key, value);
    // }

    (this.MeaSquadronStateForm.get("meaSquadronStateList") as FormArray).at(index).get('remarks');
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
      if (result) {
        //this.MeaSquadronStateService.updateRemarksMeaSquadronState(+id,data.value).subscribe(response => {
          this.MeaSquadronStateService.updateRemarksMeaSquadronState(+id,data.value).subscribe(response => {
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
inCompletedItem(row){
  const id = row.value.meaSquadronStateId;  
    console.log(row.value);
        this.confirmService.confirm('Confirm  Completed message', 'Are You Sure  Completed This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.MeaSquadronStateService.completedMeaSquadronState(+id).subscribe(() => {
          this.reloadCurrentRoute();
          this.snackBar.open('Information  Completed Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
      }
    })
  
}
inUnCompletedItem(row){
  const id = row.value.meaSquadronStateId;  
  console.log(row.value);
        this.confirmService.confirm('Confirm  Pending message', 'Are You Sure Pending This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.MeaSquadronStateService.unCompletedMeaSquadronState(id).subscribe(() => {
          //this.getselectedPresentStocks(this.departmentId);
          this.reloadCurrentRoute();
          this.snackBar.open('Information Pending Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
      }
    })
  
}
reloadCurrentRoute() {
  let currentUrl = this.router.url;
  this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
      this.router.navigate([currentUrl]);
  });
}
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMeaSquadronStates();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMeaSquadronStates();
  }

  deleteItem(row) {
    const id = row.meaSquadronStateId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MeaSquadronStateService.delete(id).subscribe(() => {
          this.getMeaSquadronStates();
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

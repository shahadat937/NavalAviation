import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MeaSquadronState } from '../../models/MeaSquadronState';
import { MeaSquadronStateService } from '../../service/MeaSquadronState.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
 

@Component({
  selector: 'app-workrequisition',
  templateUrl: './workrequisition-list.component.html',
  styleUrls: ['./workrequisition-list.component.sass']
})
export class WorkRequisitionListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MeaSquadronState[] = [];
  isLoading = false;
  roleDisable: boolean = true;
  userRole = Role;
  MeaSquadronStateForm: FormGroup;
  MeaSquadronStateListFromData:any[];
  selectedWorkShop:SelectedModel[]; 
  traineeId:any;
  role:any;
  branchId:any;
  showHideDiv = false;
  departmentNameId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'itemName', 'trad', 'workOrderNo','dateofSubmition',  'actions'];
  dataSource: MatTableDataSource<MeaSquadronState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private fb: FormBuilder,private authService: AuthService, private MeaSquadronStateService: MeaSquadronStateService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
    this.getMeaSquadronStatesForWorkShop();

    // if(this.role == this.userRole.CO || this.role == this.userRole.MEA){
    //   this.roleDisable = false;
    // }
    this.intitializeForm();
    this.getselectedWorkShop();

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
      controlNo:[],
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
      workOrderReceived:[''],
      workOrderDate:[''],
      workshopName: [''],
      remarks: [''],
      isActive: [true],
      meaSquadronStateList: this.fb.array([this.createmeaSquadronStateData()]),
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
  private createmeaSquadronStateData() {
    return this.fb.group({
      meaSquadronStateId: [""],
      itemName: [""],
      pattNo: [""],
      trad: [""],
      workOrderNo: [""],
      dateofSubmition: [""],
      meaWorkShopId:[""],
      controlNo:[]
      //completedDate:[],
      //endInspDate:[],
      //progressBar: [""],
      //completedStatus: [],
      //jobCard: [""],
    });
  }
  getMeaSquadronStatesForWorkShop() {
    this.isLoading = true;
    this.MeaSquadronStateService.getMeaSquadronStatesForWorkShop(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.MeaSquadronStateListFromData = response.items;
      console.log("this.dataSource.data")
      console.log(this.dataSource.data)
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      this.clearList();
      this.getItemStoreListonClick();
    })
  }
  getselectedWorkShop(){
    this.MeaSquadronStateService.getselectedWorkShop().subscribe(res=>{
      this.selectedWorkShop=res
      console.log(this.selectedWorkShop);      
    });
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

    (this.MeaSquadronStateForm.get("meaSquadronStateList") as FormArray).at(index).get('meaWorkShopId');
    (this.MeaSquadronStateForm.get("meaSquadronStateList") as FormArray).at(index).get('controlNo');
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
      if (result) {
        this.MeaSquadronStateService.updateMeaSquadronState(+id,data.value).subscribe(response => {
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
                  .table.table.tbl-by-group.db-li-s-in.mnt-scdle-lst tr .cl-nm-rnk-a{
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
        <h3>Pending Work Requisition List</h3>
        
        </div>
        <br>
        <hr>
        ${printContents}
        
      </body>
    </html>`);
  popupWin.document.close();
}
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMeaSquadronStatesForWorkShop();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMeaSquadronStatesForWorkShop();
  }

  deleteItem(row) {
    const id = row.meaSquadronStateId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MeaSquadronStateService.delete(id).subscribe(() => {
          this.getMeaSquadronStatesForWorkShop();
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

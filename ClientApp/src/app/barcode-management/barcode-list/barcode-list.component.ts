import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { ItemStorService } from '../service/ItemStor.service';
import { ItemStor } from '../../spares-management/models/ItemStor';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Component({
  selector: 'app-barcode',
  templateUrl: './barcode-list.component.html',
  styleUrls: ['./barcode-list.component.sass']
})

export class BarcodeListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;
  BarcodePrintForm: FormGroup;
  selectedDepartmentName: SelectedModel[];
  selectedSparesCategory: SelectedModel[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  userRole = Role;
  departmentNameId:any;
  itemCount:any;
  groupArrays: { departmentName: string; datas: any }[];
  traineeId:any;
  role:any;
  branchId:any;
  calibrationStateList:any[];
  showHideDiv = false;
  showHideDivBarcode = false;
  popup = false;
  barcodeId : any;
  dataSource: MatTableDataSource<ItemStor> = new MatTableDataSource();
  // displayedColumns: string[] = [ 'ser', 'itemName', 'trade', 'lastDateofCalibrated','nextDueDate', 'presentState', 'remarks', 'actions'];
  //dataSource: MatTableDataSource<CallibrationState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private fb: FormBuilder,private itemStorService: ItemStorService,private authService: AuthService, private router: Router,private confirmService: ConfirmService) { }
  
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
   this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
   this.GetSelectedSparesCategory();
   this.getBarcodePrintList(0,0);
   //this.getCalibrationStateList(this.departmentNameId);
  }
 
  intitializeForm() {
    this.BarcodePrintForm = this.fb.group({
      departmentNameId: [],
      sparesCategoryId: []
    });
  }
  GetDepartmentNameById(baseNameId) {
    this.itemStorService.getSelectedSchoolName(baseNameId).subscribe((res) => {
      this.selectedDepartmentName = res;
      console.log(res);
    });
  }
  GetSelectedSparesCategory() {
    this.itemStorService.getSelectedSparesCategory().subscribe((res) => {
      this.selectedSparesCategory = res;
      console.log(res);
    });
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    var departmentId = this.BarcodePrintForm.get("departmentNameId").value;
    console.log(departmentId);
    this.getBarcodePrintList(departmentId, 0);
  }
  applyDropdown(searchText: any, departmentNameId: any, sparesCategoryId: any) {
    this.searchText = searchText;
    //var departmentId = departmentNameId;
    //var departmentId = this.DemandForm.get("departmentNameId").value;
    console.log(departmentNameId, sparesCategoryId);
    this.getBarcodePrintList(departmentNameId, sparesCategoryId);
    //this.getDemandsList(departmentId);
  }

  getBarcodePrintList(departmentNameId,sparesCategoryId) {
    this.BarcodePrintForm.get("departmentNameId").setValue(departmentNameId);
    this.BarcodePrintForm.get("sparesCategoryId").setValue(sparesCategoryId);
    var findArr = this.BarcodePrintForm.value;
    console.log(findArr)
    this.isLoading = true;
    this.itemStorService.getBarcodePrintList( this.paging.pageIndex, 100000, this.searchText,findArr.departmentNameId == null ? 0 : findArr.departmentNameId, findArr.sparesCategoryId == null ? 0 : findArr.sparesCategoryId).subscribe((response) => {
      this.dataSource.data = response.items;
      console.log(this.dataSource.data);
      this.itemCount = response.items.length;
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;

      // this gives an object with dates as keys
      const groups = this.dataSource.data.reduce((groups, datas) => {
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

  getPopup(itemStoreId){
    this.popup = true;
    this.barcodeId = itemStoreId;
    console.log("popup apairs")
  }

  // getControlLabel(index: number, type: string) {
  //   return (this.MaintanenceScheduleForm.get("MaintanenceScheduleList") as FormArray).at(index).get(type).value;
  // }
  // reloadCurrentRoute() {
  //   let currentUrl = this.router.url;
  //   this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
  //     this.router.navigate([currentUrl]);
  //   });
  // }
  // applyFilter(searchText){
  //   this.isLoading = true;
  //   this.CallibrationStateService.getMaintenenceStateListForSearch(searchText,this.departmentNameId).subscribe(response => {
  //     this.calibrationStateList = response; 
  //     console.log("after search");
  //     console.log(this.calibrationStateList);
  //     console.log(response)
  //     this.clearList();
  //     this.getItemStoreListonClick();
  //   })
  // }

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

  toggleBarcode() {
    this.showHideDivBarcode = !this.showHideDivBarcode;
  }
  printBarcodeSingle() {
    this.showHideDivBarcode = false;
    this.printBarcode();
  }
  printBarcode() {
    let printContents, popupWin;
    printContents = document.getElementById("print-barcode").innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
            body{  width: 99%;}
            .print-barcode-design .barcode svg g rect {
              height: 65px !important;
            }
            .print-barcode-design .barcode svg g text{
              display:none;
            }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Barcode </h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  // onCompletedButtonClick(event,data){
  //   console.log(data);
  //   this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
  //     if (result) {
  //   this.CallibrationStateService.saveMaintenenceState(data.value).subscribe(response => {
  //     this.reloadCurrentRoute();
  //   //  this.router.navigateByUrl('/tools-management/callibrationstate-list');
  //     this.snackBar.open('Information Inserted Successfully ', '', {
  //       duration: 2000,
  //       verticalPosition: 'bottom',
  //       horizontalPosition: 'right',
  //       panelClass: 'snackbar-success'
  //     }); 
  //   })
  // }
  //  })
  // }

  // clearList() {
  //   const control = <FormArray>this.MaintanenceScheduleForm.controls["MaintanenceScheduleList"];
  //   while (control.length) {
  //     control.removeAt(control.length - 1);
  //   }
  //   control.clearValidators();
  // }

  // getItemStoreListonClick() {
  //   const control = <FormArray>this.MaintanenceScheduleForm.controls["MaintanenceScheduleList"];
  //   for (let i = 0; i < this.calibrationStateList.length; i++) {
  //     control.push(this.createIssueRegisterData());
  //   }
  //   this.MaintanenceScheduleForm.patchValue({
  //     MaintanenceScheduleList: this.calibrationStateList,
  //   });
  // }

  // deleteItem(row) {
  //   const id = row.callibrationStateId; 
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
  //     console.log(result);
  //     if (result) {
  //       this.CallibrationStateService.delete(id).subscribe(() => {
  //       //  this.getCallibrationStates();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 2000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })
  // }
}

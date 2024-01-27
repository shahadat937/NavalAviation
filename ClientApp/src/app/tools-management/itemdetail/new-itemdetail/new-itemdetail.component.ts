import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { ItemDetailService } from "../../service/itemDetail.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { DemandService } from "../../../spares-management/service/Demand.service";
import { ItemDetail } from "../../models/itemDetail";
import { MasterData } from "src/assets/data/master-data";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";

@Component({
  selector: "app-new-itemdetail",
  templateUrl: "./new-itemdetail.component.html",
  styleUrls: ["./new-itemdetail.component.sass"],
})
export class NewItemDetailComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  sparesCategoryId: string;
  ItemDetailForm: FormGroup;
  validationErrors: string[] = [];
  selectedCategoryTypes: SelectedModel[];
  selectedItemType: SelectedModel[];
  selectedTrades: SelectedModel[];
  selectedDepartmentName: SelectedModel[];
  itemDetailByDepartmentId: any[];
  selectedItemCategory: SelectedModel[];
  selectedEquipmentName: SelectedModel[];
  selectedSparesCategory: SelectedModel[];
  masterData = MasterData;
  selectedItemNameandPattNo: SelectedModel[];
  departmentId: any;
  isShown: boolean = false;
  isNoDataFound: boolean = false;
  showHideDiv = false;
  searchText: any = '';
  userRole = Role;
  traineeId: any;
  role: any;
  branchId: any;
  isExist:boolean;

  displayedColumns: string[] = [
    "ser",
    "partNo",
    "nameOfItem",
    "trade",
    "minimumStock",
    "purchaseQty",
    "presentStock",
    "issuedQty",
    "actions",
  ];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private confirmService: ConfirmService,
    private demandService: DemandService,
    private ItemDetailService: ItemDetailService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("itemDetailId");
    this.sparesCategoryId =
      this.route.snapshot.paramMap.get("sparesCategoryId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (id) {
      this.pageTitle = "Edit Item Detail";
      this.destination = "Edit";
      this.btnText = "Update";
      this.ItemDetailService.find(+id).subscribe((res) => {
        this.ItemDetailForm.patchValue({
          itemDetailId: res.itemDetailId,
          partNo: res.partNo,
          imcNumber: res.imcNumber,
          serialNo: res.serialNo,
          model: res.model,
          brand: res.brand,
          nameOfItem: res.nameOfItem,
          itemCategoryId: res.itemCategoryId,
          itemCategoryTypeId: res.itemCategoryTypeId,
          sparesCategoryId: res.sparesCategoryId,
          equipmentNameId: res.equipmentNameId,
          equipmentOrSystemName:res.equipmentOrSystemName,
          departmentNameId: res.departmentNameId,
          itemTypeId: res.itemTypeId,
          minimumStock: res.minimumStock,
          alternatiovePrartNo: res.alternatiovePrartNo,
          tradeId: res.tradeId,
          maintananceState:res.maintananceState,
          calibrationState:res.calibrationState,
          verificationCompletStatus:res.verificationCompletStatus,
          remarks: res.remarks,
        });
        this.onSparesCategorySelectionChangeGetEquipmentName(
          res.sparesCategoryId
        );
      });
    } else {
      this.pageTitle = "Item Details";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.ItemDetailForm.get("departmentNameId").setValue(this.branchId);
      this.onDepartmentSelectionChange();
    }
    this.getselectedItemCategoryTypes();
    this.getselectedItemType();
    this.getselectedTrades();
    this.getselectedItemNameAndPattNo();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getSelectedItemCategory();
    //this.getselectedEquipmentName();
    this.getselectedSparesCategory();
  }
  intitializeForm() {
    this.ItemDetailForm = this.fb.group({
      itemDetailId: [0],
      partNo: [""],
      imcNumber: [""],
      serialNo: [""],
      model: [""],
      brand: [""],
      nameOfItem: [""],
      departmentNameId: [""],
      itemCategoryId: [],
      itemCategoryTypeId: [],
      equipmentNameId: [],
      equipmentOrSystemName:[""],
      sparesCategoryId: [2],
      //sparesCategoryId:[this.masterData.sparescategory.spares],
      itemTypeId: [],
      alternatiovePrartNo: [""],
      minimumStock: [""],
      tradeId: [],
      maintananceState:[],
      calibrationState:[],
      verificationCompletStatus:[""],
      remarks: [""],
      isActive: [true],
    });
  }
  inActiveItem(row){
    const id = row.itemDetailId; 
          this.confirmService.confirm('Confirm Approved message', 'Are You Sure Approved This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.ItemDetailService.approvedItemDetail(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.getselectedPresentStocks(row.departmentNameId,this.searchText);
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
getselectedItemNameAndPattNo() {
  this.ItemDetailService.getselectedItemNameAndPattNo().subscribe((res) => {
    this.selectedItemNameandPattNo = res;
    console.log(this.selectedItemNameandPattNo);
  });
}
onItemNameChange(value){
  console.log("ItemName");
  console.log(value);
  this.ItemDetailService.getItemNameIsExistCheck(value).subscribe(response => {
   this.isExist=response;
   console.log("sbsbsbbs");
   console.log(this.isExist);
 })
 }
  onDepartmentSelectionChange() {
    this.isShown = true;
    var departmentNameId = this.ItemDetailForm.value["departmentNameId"];
    this.getselectedPresentStocks(departmentNameId,this.searchText);
    // this.ItemDetailService.getselectedItemDetailByDepartmentNameId(dropdown.source.value).subscribe(res=>{

    //   this.itemDetailByDepartmentId=res
    //   console.log(this.itemDetailByDepartmentId);
    //   // if(this.itemDetailByDepartmentId.length<=0){
    //   //  this.isShown=false;
    //    // this.isNoDataFound=true;
    //    // console.log("ddddddd")
    // //  }
    // });
  }
 
 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  // getselectedItemDetailByDepartmentNameId(){

  // }
  getselectedItemCategoryTypes() {
    this.ItemDetailService.getselectedItemCategoryTypes().subscribe((res) => {
      this.selectedCategoryTypes = res;
      // console.log(this.selectedCategoryTypes);
    });
  }
  getselectedPresentStocks(departmentId,searchText) {
    this.ItemDetailService.getselectedPresentStocks(departmentId,this.masterData.sparescategory.tools,searchText).subscribe((res) => {
      this.itemDetailByDepartmentId = res;
      console.log(this.itemDetailByDepartmentId);
    });
  }
  // getselectedPresentStocks(departmentId,searchText) {
  //   this.ItemDetailService.getselectedPresentStocks(departmentId, this.masterData.sparescategory.spares,searchText).subscribe((res) => {
  //     this.itemDetailByDepartmentId = res;
  //     console.log("data list");
  //     console.log(res);
  //   });
  // }
  applyDropdown() {
    // var departmentNameId = 0;
    var departmentId = this.ItemDetailForm.get("departmentNameId").value;
    
    console.log(departmentId);
    this.getselectedPresentStocks(departmentId,this.searchText);
  }
  // getSelectedDepartmentName(){
  //   this.demandService.getSelectedDepartmentName().subscribe(res=>{
  //     this.selectedDepartmentName=res
  //     //console.log(this.selectedDepartmentName);
  //   });
  // }
  GetDepartmentNameById(baseNameId) {
    this.demandService.getSelectedSchoolName(baseNameId).subscribe((res) => {
      this.selectedDepartmentName = res;
      console.log(res);
    });
  }
  getSelectedItemCategory() {
    this.demandService.getSelectedItemCategory(this.masterData.sparescategory.tools).subscribe((res) => {
      this.selectedItemCategory = res;
      //console.log(this.selectedDepartmentName);
    });
  }
  getselectedItemType() {
    this.ItemDetailService.getselectedItemType().subscribe((res) => {
      this.selectedItemType = res;
      console.log(this.selectedItemType);
    });
  }
  getselectedTrades() {
    this.ItemDetailService.getselectedTrades().subscribe((res) => {
      this.selectedTrades = res;
      console.log(this.selectedTrades);
    });
  }
  onSparesCategorySelectionChangeGetEquipmentName(sparesCategoryId) {
    this.ItemDetailService.getEquipmentNameBySparesCategoryId(
      sparesCategoryId
    ).subscribe((res) => {
      this.selectedEquipmentName = res;
    });
  }
  // getselectedEquipmentName(){
  //   this.ItemDetailService.getselectedEquipmentName().subscribe(res=>{
  //     this.selectedEquipmentName=res
  //     console.log(this.selectedEquipmentName);
  //   });
  // }
  getselectedSparesCategory() {
    this.ItemDetailService.getselectedSparesCategory().subscribe((res) => {
      this.selectedSparesCategory = res;
      console.log(this.selectedSparesCategory);
    });
  }

  deleteItem(row) {
    const id = row.itemDetailId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        console.log(result);
        if (result) {
          this.ItemDetailService.delete(id).subscribe(() => {
            //this.getItemDetails();
            this.reloadCurrentRoute();
            this.snackBar.open("Information Deleted Successfully ", "", {
              duration: 2000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-danger",
            });
          });
        }
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
                  .table-striped.tblbg tr .btn-tbl-edit {
                    display:none;
                  }
                  .table-striped.tblbg tr .btn-tbl-delete {
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
          <h3>Patt No/ Item Names Entry List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    const id = this.ItemDetailForm.get("itemDetailId").value;
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.ItemDetailService.update(
              +id,
              this.ItemDetailForm.value
            ).subscribe(
              (response) => {
                this.router.navigateByUrl("/tools-management/add-itemdetail");
                //this.reloadCurrentRoute();
                this.snackBar.open("Information Updated Successfully ", "", {
                  duration: 2000,
                  verticalPosition: "bottom",
                  horizontalPosition: "right",
                  panelClass: "snackbar-success",
                });
              },
              (error) => {
                this.validationErrors = error;
              }
            );
          }
        });
    } else {
      this.ItemDetailService.submit(this.ItemDetailForm.value).subscribe(
        (response) => {
          //  this.router.navigateByUrl('/tools-management/itemdetail-list');
          this.reloadCurrentRoute();
          this.snackBar.open("Information Inserted Successfully ", "", {
            duration: 2000,
            verticalPosition: "bottom",
            horizontalPosition: "right",
            panelClass: "snackbar-success",
          });
        },
        (error) => {
          this.validationErrors = error;
        }
      );
    }
  }
}

// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { MatSnackBar } from '@angular/material/snack-bar';
// import { ActivatedRoute, Router } from '@angular/router';
// import { ItemDetailService } from '../../service/itemDetail.service';
// import { ConfirmService } from '../../../core/service/confirm.service';
// import { SelectedModel } from 'src/app/core/models/selectedModel';
// import { MasterData } from 'src/assets/data/master-data';
// import { ItemDetail } from 'src/app/tools-management/models/itemDetail';
// import { Role } from 'src/app/core/models/role';
// import { AuthService } from 'src/app/core/service/auth.service';

// @Component({
//   selector: 'app-new-itemdetail',
//   templateUrl: './new-itemdetail.component.html',
//   styleUrls: ['./new-itemdetail.component.sass']
// })
// export class NewItemDetailComponent implements OnInit {
//   pageTitle: string;
//   sparesCategoryId:string;
//   destination:string;
//   btnText:string;
//   ItemDetailForm: FormGroup;
//   validationErrors: string[] = [];
//   selectedDepartment:SelectedModel[];
//   selectedItemType:SelectedModel[];
//   selectedTrades:SelectedModel[];
//   itemDetailList:ItemDetail[];
//   selectedItemCategory:SelectedModel[];
//   isShown: boolean = false ;
//   masterData = MasterData;

//   userRole = Role;

//   traineeId:any;
//   role:any;
//   branchId:any;

//   displayedColumns: string[] = [ 'ser', 'partNo', 'nameOfItem','trade', 'minimumStock', 'presentStock', 'actions'];
//   paging = {
//     pageIndex: this.masterData.paging.pageIndex,
//     pageSize: this.masterData.paging.pageSize,
//     length: 1
//   }
//   constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private ItemDetailService: ItemDetailService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

//   ngOnInit(): void {
//     const id = this.route.snapshot.paramMap.get('itemDetailId');
//     this.sparesCategoryId= this.route.snapshot.paramMap.get('sparesCategoryId');

//     this.role = this.authService.currentUserValue.role.trim();
//     this.traineeId =  this.authService.currentUserValue.traineeId.trim();
//     this.branchId =  this.authService.currentUserValue.branchId.trim();
//     console.log(this.role, this.traineeId,  this.branchId)

//     if (id) {
//       this.pageTitle = 'Edit Item Detail';
//       this.destination = "Edit";
//       this.btnText = 'Update';
//       this.ItemDetailService.find(+id).subscribe(
//         res => {
//           this.ItemDetailForm.patchValue({

//             itemDetailId: res.itemDetailId,
//             itemCategoryId:res.itemCategoryId,
//             departmentNameId:res.departmentNameId,
//             partNo: res.partNo,
//             imcNumber: res.imcNumber,
//             serialNo:res.serialNo,
//             model:res.model,
//             brand:res.brand,
//             nameOfItem: res.nameOfItem,
//             itemCategoryTypeId:res.itemCategoryTypeId,
//             sparesCategoryId:res.sparesCategoryId,
//             itemTypeId:res.itemTypeId,
//             minimumStock: res.minimumStock,
//             alternatiovePrartNo: res.alternatiovePrartNo,
//             tradeId: res.tradeId,
//             remarks: res.remarks,

//           });
//         }
//       );
//     } else {
//       this.pageTitle = 'Create Item Detail';
//       this.destination = "Add";
//       this.btnText = 'Save';
//     }
//     this.intitializeForm();
//     if(this.role != this.userRole.SuperAdmin){
//       this.ItemDetailForm.get('departmentNameId').setValue(this.branchId);
//       this.onItemDetailListByDepartmentSelectionChange();
//     }
//     this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
//     this.getselectedItemType();
//     this.getselectedTrades();
//     this.getSelectedItemCategory();
//   }
//   intitializeForm() {
//     this.ItemDetailForm = this.fb.group({
//       itemDetailId: [0],
//       itemCategoryId:[],
//       departmentNameId:[],
//       partNo: [''],
//       imcNumber: [''],
//       serialNo:[''],
//       model:[''],
//       brand:[''],
//       nameOfItem: [''],
//       itemCategoryTypeId:[],
//       sparesCategoryId:[this.masterData.sparescategory.tools],
//       itemTypeId:[],
//       alternatiovePrartNo: [''],
//       minimumStock:[''],
//       tradeId:[],
//       remarks: [''],
//       isActive: [true],

//     })
//   }
//   GetDepartmentNameById(baseNameId){
//     this.ItemDetailService.getSelectedSchoolName(baseNameId).subscribe(res=>{
//       this.selectedDepartment=res
//       console.log(res)
//     });
//   }

//   onItemDetailListByDepartmentSelectionChange(){
//     this.isShown=true;
//     var departmentNameId = this.ItemDetailForm.get('departmentNameId').value;
//     this.getselectedPresentStocks(departmentNameId);

//   }
//   getselectedPresentStocks(departmentId){

//     this.ItemDetailService.getselectedPresentStocks(departmentId).subscribe(res=>{
//       this.itemDetailList=res
//      console.log(this.itemDetailList);
//     });
//   }
//   getselectedItemType(){
//     this.ItemDetailService.getselectedItemType().subscribe(res=>{
//       this.selectedItemType=res
//       console.log(this.selectedItemType);
//     });
//   }
//   getSelectedItemCategory(){
//     this.ItemDetailService.getSelectedItemCategory().subscribe(res=>{
//       this.selectedItemCategory=res
//       //console.log(this.selectedDepartmentName);
//     });
//   }
//   getselectedTrades(){
//     this.ItemDetailService.getselectedTrades().subscribe(res=>{
//       this.selectedTrades=res
//       console.log(this.selectedTrades);
//     });
//   }
//   reloadCurrentRoute() {
//     let currentUrl = this.router.url;
//     this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
//         this.router.navigate([currentUrl]);
//     });
//   }
//   onSubmit() {
//     const id = this.ItemDetailForm.get('itemDetailId').value;
//     if (id) {
//       this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {

//         if (result) {
//           this.ItemDetailService.update(+id,this.ItemDetailForm.value).subscribe(response => {
//             this.router.navigateByUrl('/tools-management/add-itemdetail');
//             this.snackBar.open('Information Updated Successfully ', '', {
//               duration: 2000,
//               verticalPosition: 'bottom',
//               horizontalPosition: 'right',
//               panelClass: 'snackbar-success'
//             });
//           }, error => {
//             this.validationErrors = error;
//           })
//         }
//       })
//     } else {
//       this.ItemDetailService.submit(this.ItemDetailForm.value).subscribe(response => {
//         //this.router.navigateByUrl('/tools-management/itemdetail-list');
//         this.reloadCurrentRoute();
//         this.snackBar.open('Information Inserted Successfully ', '', {
//           duration: 2000,
//           verticalPosition: 'bottom',
//           horizontalPosition: 'right',
//           panelClass: 'snackbar-success'
//         });
//       }, error => {
//         this.validationErrors = error;
//       })
//     }

//   }
//   deleteItem(row) {
//     const id = row.itemDetailId;
//     this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
//       console.log(result);
//       if (result) {
//         this.ItemDetailService.delete(id).subscribe(() => {
//         //  this.getItemDetails();
//           //this.getItemDetailsForTools()
//           this.reloadCurrentRoute();
//           this.snackBar.open('Information Deleted Successfully ', '', {
//             duration: 2000,
//             verticalPosition: 'bottom',
//             horizontalPosition: 'right',
//             panelClass: 'snackbar-danger'
//           });
//         })
//       }
//     })
//   }
// }

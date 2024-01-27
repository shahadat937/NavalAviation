import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { ActivatedRoute, Router } from "@angular/router";
import { ItemStorService } from "../../service/ItemStor.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { ItemStor } from "../../models/ItemStor";
import { MasterData } from "src/assets/data/master-data";
import { AcceptanceService } from "../../service/Acceptance.service";
import { Acceptance } from "../../models/Acceptance";
import { DemandService } from "../../service/Demand.service";
import { MatTableDataSource } from "@angular/material/table";
import { ProcurementService } from "../../service/Procurement.service";
import { Procurement } from "../../models/Procurement";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";

@Component({
  selector: "app-new-itemstor",
  templateUrl: "./new-itemstor.component.html",
  styleUrls: ["./new-itemstor.component.sass"],
})
export class NewItemStorComponent implements OnInit {
  pageTitle: String;
  destination: String;
  btnText: String;
  masterData = MasterData;
  ItemStorForm: FormGroup;
  validationErrors: string[] = [];
  selectedItemCategory: SelectedModel[];
  selectedDeno: SelectedModel[];
  selectedSparesCategory: SelectedModel[];
  selectedConditionofItem: SelectedModel[];
  selectedToolsLocation: SelectedModel[];
  selectedLifeLimitItem: SelectedModel[];
  selectedAcctStore: SelectedModel[];
  selectedServiceLifeType: SelectedModel[];
  selectedEndLifeType: SelectedModel[];
  selectedOverhaulingTypes: SelectedModel[];
  selectedDepartmentNames: SelectedModel[];
  selectedProcurementStatuses: SelectedModel[];
  selectedPartNo: SelectedModel[];
  acceptanceByDepartmentAndCategory: Acceptance;
  groupArrays: { departmentName: string; datas: any }[];
  isShown: boolean = false;
  procurementData: Procurement[];
  acceptanceData: Acceptance[];
  isLoading = false;
  isQtyShow = false;
  qtyShown = false;

  userRole = Role;
  lifeLimit: any;

  traineeId: any;
  role: any;
  branchId: any;

  sftQty: any;
  storeQty: any;
  showHideDiv = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "partNo",
    "nameOfItem",
    "deno",
    "totalReceivedQty",
    "toolsLocation",
    "actions",
  ];
  dataSource: MatTableDataSource<ItemStor> = new MatTableDataSource();

  sftColumns: string[] = [
    "sl",
    "itemDetail",
    "sftQty",
    "storeQty",
    "demandDate",
    "deliveryDate",
    "outerLatterNo",
  ];
  procurementColumns: string[] = [
    "sl",
    "tenderNumber",
    "dateOfDelivery",
    "dateOfTenderFloat",
    "cstTec",
    "qty",
  ];

  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private procurementService: ProcurementService,
    private demandService: DemandService,
    private acceptanceService: AcceptanceService,
    private confirmService: ConfirmService,
    private ItemStorService: ItemStorService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("itemStorId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (id) {
      this.pageTitle = "Edit Item Store";
      this.destination = "Edit";
      this.btnText = "Update";
      this.ItemStorService.find(+id).subscribe((res) => {
        this.ItemStorForm.patchValue({
          itemStorId: res.itemStorId,
          acceptanceId: res.acceptanceId,
          procurementId: res.procurementId,
          demandId: res.demandId,
          denoId: res.denoId,
          departmentNameId: res.departmentNameId,
          //itemCategoryId: res.itemCategoryId,
          //serviceLifeTypeId: res.serviceLifeTypeId,
          sparesCategoryId: res.sparesCategoryId,
          conditionOfItemId: res.conditionOfItemId,
          lifeLimitItemId: res.lifeLimitItemId,
          toolsLocationId: res.toolsLocationId,
          //endLifeTypeId: res.endLifeTypeId,
          //acctStoreId: res.acctStoreId,
          //overhaulingTypeId: res.overhaulingTypeId,
          //retirementTypeId: res.retirementTypeId,
          itemDetailId: res.itemDetailId,
          itemSerNo: res.itemSerNo,
          icmNo: res.icmNo,
          shelfLife: res.shelfLife,
          endShalfLife: res.endShalfLife,
          //warrantyStartDate: res.warrantyStartDate,
          warrantyEndDate: res.warrantyEndDate,
          //itemReceivedDate: res.itemReceivedDate,
          totalReceivedQty: res.totalReceivedQty,
          //issuedQty: res.issuedQty,
          demandQty: res.demandQty,
          demandDate: res.demandDate,
          manufacturingDate: res.manufacturingDate,
          letterOuterNo: res.letterOuterNo,
          refPoNo: res.refPoNo,
          tenderNumber: res.tenderNumber,
          dateOfTenderFloat: res.dateOfTenderFloat,
          //tenderopeningDate: res.tenderopeningDate,
          tenderPublishDate: res.tenderPublishDate,
          tenderNotice: res.tenderNotice,
          location: res.location,
          serviceLife: res.serviceLife,
          endLifeTime: res.endLifeTime,
          accessories: res.accessories,
          stockRegisterPageNo: res.stockRegisterPageNo,
          retirmentLife: res.retirmentLife,
          remarks: res.remarks,
          permanentQty:res.permanentQty,
          tyQty: res.tyQty,
          repairQty: res.repairQty,
          surveyQty: res.surveyQty,
          aircraftFittedQty: res.aircraftFittedQty,
          maintenanceQty: res.maintenanceQty,
          calibrationQty: res.calibrationQty,
          //arcDoc: res.arcDoc,
          //cofcDoc: res.cofcDoc,
          otherDoc: res.otherDoc,
          //oemDoc: res.oemDoc,
          //status: res.status,
          isActive: res.isActive,
        });
        this.getselectedAcceptenceOnUpdate(res.departmentNameId);
        this.getAcceptanceData();
      });
    } else {
      this.pageTitle = "Create Item Store";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.ItemStorForm.get("departmentNameId").setValue(this.branchId);
      this.getselectedAcceptence();
    }
    this.getselectedItemCategory();
    this.getselectedDeno();
    this.getselectedAcctStore();
    this.getselectedServiceLifeType();
    this.getselectedEndLifeType();
    this.getselectedOverhaulingTypes();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedSparesCategory();
    this.getselectedConditionOfItem();
    this.getselectedToolsLocations();
    this.getselectedLifeLimitItem();
    this.getselectedProcurementStatuses();
    //this.getItemStorsList();
    //this.getItemStors();
  }
  intitializeForm() {
    this.ItemStorForm = this.fb.group({
      itemStorId: [0],
      acceptanceId: [""],
      procurementId: [""],
      demandId: [""],
      denoId: [""],
      departmentNameId: [""],
      itemCategoryId: [""],
      serviceLifeTypeId: [""],
      sparesCategoryId: [""],
      conditionOfItemId: [""],
      lifeLimitItemId: [""],
      toolsLocationId: [""],
      endLifeTypeId: [""],
      acctStoreId: [""],
      overhaulingTypeId: [""],
      retirementTypeId: [""],
      procurementStatusId: [""],
      itemDetailId: [""],
      itemSerNo: [""],
      icmNo: [""],
      shelfLife: [""],
      endShalfLife: [""],
      warrantyStartDate: [""],
      warrantyEndDate: [""],
      itemReceivedDate: [""],
      totalReceivedQty: [""],
      availableQty: [""],
      issuedQty: [""],
      demandQty: [""],
      demandDate: [""],
      manufacturingDate: [],
      letterOuterNo: [""],
      refPoNo: [""],
      tenderNumber: [""],
      dateOfTenderFloat: [""],
      tenderopeningDate: [""],
      //tenderPublishDate:[''],
      tenderNotice: [""],
      location: [""],
      qtyEntryType: [""],
      serviceLife: [""],
      endLifeTime: [""],
      accessories: [""],
      stockRegisterPageNo: [""],
      retirmentLife: [""],
      remarks: [""],
      arcDoc: [""],
      cofcDoc: [""],
      doc: [""],
      otherDoc: [""],
      oemDoc: [""],

      //status: [""],
      permanentQty:[0],
      tyQty:[0],
      repairQty:[0],
      surveyQty:[0],
      aircraftFittedQty:[0],
      maintenanceQty:[0],
      calibrationQty:[0],
      status: [0],
      isActive: [true],
      brand:[''],
      model:['']
    });
  }
  onFillDocChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log("acceptance doc");
      console.log(file);
      this.ItemStorForm.patchValue({
        doc: file,
      });
    }
  }
  inActiveItem(row){
    const id = row.itemStorId; 
          this.confirmService.confirm('Confirm Approved message', 'Are You Sure Approved This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.ItemStorService.approvedItemStor(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.getItemStorsList(row.departmentNameId);
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

onStatus(dropdown) {
  if (dropdown.isUserInput) {
    this.lifeLimit = dropdown.source.value;
    console.log(this.lifeLimit);
  }
}
  getselectedAcceptence() {
    var departmentNameId = this.ItemStorForm.value["departmentNameId"];
    this.isShown = true;
    this.ItemStorService.partnoFromAcceptanceByDepartmentName(
      departmentNameId,
      this.masterData.sparescategory.tools
    ).subscribe((res) => {
      this.selectedPartNo = res;
      //console.log(this.selectedPartNo);
    });
    this.getItemStorsList(departmentNameId);
  }
  getselectedAcceptenceOnUpdate(id) {
    this.ItemStorService.partnoFromAcceptanceForUpdateByDepartmentName(
      id,
      this.masterData.sparescategory.tools
    ).subscribe((res) => {
      this.selectedPartNo = res;
      //console.log(this.selectedPartNo)
    });
  }
  getAcceptanceData() {
    var acceptanceId = this.ItemStorForm.value["acceptanceId"];
    console.log(acceptanceId);
    this.ItemStorService.getacceptanceById(acceptanceId).subscribe((res) => {
      this.acceptanceData = res;
    });
    this.acceptanceService.find(acceptanceId).subscribe((res) => {
      this.acceptanceByDepartmentAndCategory = res;
      this.ItemStorForm.get("demandId").setValue(res.demandId);
      this.ItemStorForm.get("itemDetailId").setValue(res.itemDetailId);
      this.ItemStorForm.get("procurementId").setValue(res.procurementId);
      this.ItemStorForm.get("sparesCategoryId").setValue(res.sparesCategoryId);
      this.ItemStorForm.get("brand").setValue(res.brand);
      this.ItemStorForm.get("model").setValue(res.model);
      //console.log("acceptance")
      this.qtyShown = true;
      console.log(res.sftQty, res.storeQty);
      this.sftQty = res.sftQty;
      this.storeQty = res.storeQty;

      this.procurementService
        .GetselectedProcurementById(res.procurementId)
        .subscribe((res) => {
          this.procurementData = res;
        });
        console.log("demand Id");
        console.log(res.demandId);
      this.demandService.find(res.demandId).subscribe((res) => {
        this.ItemStorForm.get("denoId").setValue(res.denoId);
        this.ItemStorForm.get("demandQty").setValue(res.demandQty);
        this.ItemStorForm.get("demandDate").setValue(res.demandDate);
        this.ItemStorForm.get("letterOuterNo").setValue(res.letterOuterNo);
        this.ItemStorForm.get("refPoNo").setValue(res.refPoNo);
      });
      this.procurementService.find(res.procurementId).subscribe((res) => {
        // console.log(res.procurementId)
        // console.log("procurementId")
        this.ItemStorForm.get("tenderNumber").setValue(res.tenderNumber);
        // console.log(res.tenderNumber)
        // console.log("tenderNumber")
        this.ItemStorForm.get("dateOfTenderFloat").setValue(
          res.dateOfTenderFloat
        );
        // console.log(res.dateOfTenderFloat)
        // console.log("dateOfTenderFloat")
        // this.ItemStorForm.get("tenderopeningDate").setValue(
        //   res.tenderopeningDate
        // );
        // this.ItemStorForm.get("tenderPublishDate").setValue(
        //   res.tenderPublishDate
        // );
      });
      this.isShown = true;
    });
  }
  // getselectedDepartmentNames(){
  //   this.ItemStorService.getselectedDepartmentNames().subscribe(res=>{
  //     this.selectedDepartmentNames=res
  //     //console.log(this.selectedDepartmentNames);
  //   });
  // }
  GetDepartmentNameById(baseNameId) {
    this.ItemStorService.getSelectedSchoolName(baseNameId).subscribe((res) => {
      this.selectedDepartmentNames = res;
      console.log(res);
    });
  }
  getselectedItemCategory() {
    this.ItemStorService.getSelectedItemCategory(this.masterData.sparescategory.tools).subscribe((res) => {
      this.selectedItemCategory = res;
      //console.log(this.selectedItemCategory);
    });
  }
  getItemQtyField() {
    var statusId = this.ItemStorForm.value["procurementStatusId"];
    if (statusId == 2) {
      this.isQtyShow = true;
    } else {
      this.isQtyShow = false;
    }
  }
  getselectedProcurementStatuses() {
    this.ItemStorService.getselectedProcurementStatuses().subscribe((res) => {
      this.selectedProcurementStatuses = res;
      console.log(this.selectedProcurementStatuses);
    });
  }
  getselectedLifeLimitItem() {
    this.ItemStorService.getselectedLifeLimitItem().subscribe((res) => {
      this.selectedLifeLimitItem = res;
    });
  }
  getselectedDeno() {
    this.ItemStorService.getselectedDeno().subscribe((res) => {
      this.selectedDeno = res;
      //console.log(this.selectedDeno);
    });
  }
  getselectedSparesCategory() {
    this.ItemStorService.getselectedSparesCategory().subscribe((res) => {
      this.selectedSparesCategory = res;
      //console.log(this.selectedDeno);
    });
  }
  getselectedConditionOfItem() {
    this.ItemStorService.getselectedConditionOfItem().subscribe((res) => {
      this.selectedConditionofItem = res;
      //console.log(this.selectedAcctStore);
    });
  }
  getselectedToolsLocations() {
    this.ItemStorService.getselectedToolsLocations().subscribe((res) => {
      this.selectedToolsLocation = res;
      //console.log(this.selectedAcctStore);
    });
  }
  getselectedAcctStore() {
    this.ItemStorService.getselectedAcctStore().subscribe((res) => {
      this.selectedAcctStore = res;
      //console.log(this.selectedAcctStore);
    });
  }
  getselectedServiceLifeType() {
    this.ItemStorService.getselectedServiceLifeType().subscribe((res) => {
      this.selectedServiceLifeType = res;
      //console.log(this.selectedServiceLifeType);
    });
  }
  getselectedEndLifeType() {
    this.ItemStorService.getselectedEndLifeType().subscribe((res) => {
      this.selectedEndLifeType = res;
      //console.log(this.selectedEndLifeType);
    });
  }
  getselectedOverhaulingTypes() {
    this.ItemStorService.getselectedOverhaulingTypes().subscribe((res) => {
      this.selectedOverhaulingTypes = res;
      //console.log(this.selectedOverhaulingTypes);
    });
  }

  getItemStorsList(departmentId) {
    this.isLoading = true;
    console.log("departmentId");
    console.log(departmentId);
    this.ItemStorService.getItemStorsList(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText,
      departmentId,
      this.masterData.sparescategory.tools,
      0
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      console.log(this.dataSource.data);
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
  // getItemStors() {
  //   this.isLoading = true;
  //   this.ItemStorService.getItemStors(this.paging.pageIndex, this.paging.pageSize,this.searchText, this.masterData.itemcategory.mainEquipment).subscribe(response => {
  //     this.dataSource.data = response.items;
  //     this.paging.length = response.totalItemsCount
  //     this.isLoading = false;
  //   })
  // }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    var departmentId = this.ItemStorForm.get("departmentNameId").value;
    //console.log(departmentId);
    this.getItemStorsList(departmentId);
    //this.getItemStors();
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  deleteItem(row) {
    const id = row.itemStorId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        //console.log(result);
        if (result) {
          this.ItemStorService.delete(id).subscribe(() => {
            //this.getItemStors();
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
                  .table-striped.tblbg tr .fa-file-pdf tbl-pdf {
                    display:none;
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
          <h3>Stock Registor List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    const id = this.ItemStorForm.get("itemStorId").value;
    var warrantyEndDate = this.ItemStorForm.get("warrantyEndDate").value;

    this.ItemStorForm.get("demandDate").setValue(
      new Date(this.ItemStorForm.get("demandDate").value).toUTCString()
    );
    
    this.ItemStorForm.get("manufacturingDate").setValue(
      new Date(this.ItemStorForm.get("manufacturingDate").value).toUTCString()
    );
    if(warrantyEndDate){
      this.ItemStorForm.get("warrantyEndDate").setValue(
        new Date(this.ItemStorForm.get("warrantyEndDate").value).toUTCString()
      );
    }else{
      this.ItemStorForm.get("warrantyEndDate").setValue(new Date());
      this.ItemStorForm.get("warrantyEndDate").setValue(
        new Date(this.ItemStorForm.get("warrantyEndDate").value).toUTCString()
      );
    }
    console.log(this.ItemStorForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.ItemStorForm.value)) {
      const value = this.ItemStorForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.ItemStorService.update(+id, formData).subscribe(
              (response) => {
                this.router.navigateByUrl("/tools-management/add-toolstore");
                //this.getItemStors();
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
      this.ItemStorService.submit(formData).subscribe(
        (response) => {
          //this.router.navigateByUrl('/tools-management/add-toolstore');
          //this.getItemStors();
          this.reloadCurrentRoute();
          this.intitializeForm();
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
// import { MatPaginator, PageEvent } from '@angular/material/paginator';
// import { ActivatedRoute, Router } from '@angular/router';
// import { ItemStorService } from '../../service/ItemStor.service';
// import { ConfirmService } from '../../../core/service/confirm.service';
// import { SelectedModel } from 'src/app/core/models/selectedModel';
// import { ItemStor } from '../../models/ItemStor';
// import { MasterData } from 'src/assets/data/master-data';
// import { AcceptanceService } from '../../service/Acceptance.service';
// import { Acceptance } from '../../models/Acceptance';
// import { DemandService } from '../../service/Demand.service';
// import { MatTableDataSource } from '@angular/material/table';
// import { ProcurementService } from '../../service/Procurement.service';
// import { Procurement } from '../../models/Procurement';
// import { Role } from 'src/app/core/models/role';
// import { AuthService } from 'src/app/core/service/auth.service';

// @Component({
//   selector: 'app-new-itemstors',
//   templateUrl: './new-itemstors.component.html',
//   styleUrls: ['./new-itemstors.component.sass']
// })
// export class NewItemStorsComponent implements OnInit {
//   pageTitle: String;
//   destination: String;
//   btnText:String;
//   masterData = MasterData;
//   ItemStorForm: FormGroup;
//   validationErrors: string[] = [];
//   selectedItemCategory:SelectedModel[];
//   selectedDeno:SelectedModel[];
//   selectedAcctStore:SelectedModel[];
//   selectedServiceLifeType:SelectedModel[];
//   selectedEndLifeType:SelectedModel[];
//   selectedOverhaulingTypes:SelectedModel[];
//   selectedDepartmentNames:SelectedModel[];
//   selectedPartNo:SelectedModel[];
//   selectedSparesCategory:SelectedModel[];
//   selectedLifeLimitItem:SelectedModel[];
//   selectedConditionofItem:SelectedModel[];
//   acceptanceByDepartmentAndCategory:Acceptance;
//   isShown: boolean = false ;
//   procurementData: Procurement[];
//   acceptanceData: Acceptance[];
//   isLoading = false;
//   selectedToolsType:SelectedModel[];
//   selectedLocation:SelectedModel[];
//   selectedToolsBoxName:SelectedModel[];

//   userRole = Role;

//   traineeId:any;
//   role:any;
//   branchId:any;

//   paging = {
//     pageIndex: this.masterData.paging.pageIndex,
//     pageSize: this.masterData.paging.pageSize,
//     length: 1
//   }
//   searchText="";

//   displayedColumns: string[] = [ 'ser','partNo','nameOfItem', 'deno', 'totalReceivedQty', 'toolsLocation', 'actions'];
//   dataSource: MatTableDataSource<ItemStor> = new MatTableDataSource();

//   sftColumns: string[] = ['sl','itemDetail', 'sftQty','demandDate', 'deliveryDate', 'outerLatterNo'];
//   procurementColumns: string[] = ['sl','tenderNumber','dateOfDelivery', 'dateOfTenderFloat', 'cstTec', 'qty'];

//   constructor(private snackBar: MatSnackBar,private authService: AuthService,private procurementService: ProcurementService,private demandService: DemandService,private acceptanceService:AcceptanceService,private confirmService: ConfirmService,private ItemStorService: ItemStorService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

//   ngOnInit(): void {
//     const id = this.route.snapshot.paramMap.get('itemStorId');

//     this.role = this.authService.currentUserValue.role.trim();
//     this.traineeId =  this.authService.currentUserValue.traineeId.trim();
//     this.branchId =  this.authService.currentUserValue.branchId.trim();
//     console.log(this.role, this.traineeId,  this.branchId)

//     if (id) {
//       this.pageTitle = 'Edit Item Store - Tools';
//       this.destination = "Edit";
//       this.btnText = 'Update';
//       this.ItemStorService.find(+id).subscribe(
//         res => {
//           this.ItemStorForm.patchValue({
//             itemStorId: res.itemStorId,
//             //toolsTypeId:res.toolsTypeId,
//             //toolsBoxNameId:res.toolsBoxNameId,
//             //calibrationDate:res.calibrationDate,
//             //nextCalibrationDate:res.nextCalibrationDate,
//             toolsLocationId:res.toolsLocationId,
//             acceptanceId: res.acceptanceId,
//             procurementId: res.procurementId,
//             demandId:res.demandId,
//             denoId: res.denoId,
//             departmentNameId: res.departmentNameId,
//             //itemCategoryId: res.itemCategoryId,
//             //serviceLifeTypeId: res.serviceLifeTypeId,
//             sparesCategoryId: res.sparesCategoryId,
//             conditionOfItemId:res.conditionOfItemId,
//             lifeLimitItemId:res.lifeLimitItemId,
//             //endLifeTypeId: res.endLifeTypeId,
//             //acctStoreId: res.acctStoreId,
//             //overhaulingTypeId: res.overhaulingTypeId,
//             //retirementTypeId: res.retirementTypeId,
//             itemDetailId: res.itemDetailId,
//             itemSerNo: res.itemSerNo,
//             icmNo: res.icmNo,
//             shelfLife: res.shelfLife,
//             endShalfLife: res.endShalfLife,
//             //warrantyStartDate: res.warrantyStartDate,
//             warrantyEndDate: res.warrantyEndDate,
//             //itemReceivedDate: res.itemReceivedDate,
//             totalReceivedQty: res.totalReceivedQty,
//             //issuedQty: res.issuedQty,
//             demandQty: res.demandQty,
//             demandDate: res.demandDate,
//             letterOuterNo: res.letterOuterNo,
//             refPoNo: res.refPoNo,
//             tenderNumber: res.tenderNumber,
//             dateOfTenderFloat: res.dateOfTenderFloat,
//             tenderopeningDate: res.tenderopeningDate,
//             tenderPublishDate: res.tenderPublishDate,
//             tenderNotice: res.tenderNotice,
//             location: res.location,
//             serviceLife: res.serviceLife,
//             endLifeTime: res.endLifeTime,
//             accessories: res.accessories,
//             stockRegisterPageNo: res.stockRegisterPageNo,
//             retirmentLife: res.retirmentLife,
//             remarks: res.remarks,
//             //arcDoc: res.arcDoc,
//             //cofcDoc: res.cofcDoc,
//             otherDoc: res.otherDoc,
//             //oemDoc: res.oemDoc,
//             //status: res.status,
//             isActive: res.isActive
//           });
//           this.getselectedAcceptenceOnUpdate(res.departmentNameId);
//           this.getAcceptanceData();
//         }
//       );
//     } else {
//       this.pageTitle = 'Create Item Store - Tools';
//       this.destination = "Add";
//       this.btnText = 'Save';
//     }
//     this.intitializeForm();
//     if(this.role != this.userRole.SuperAdmin){
//       this.ItemStorForm.get('departmentNameId').setValue(this.branchId);
//       this.getselectedAcceptence();
//     }
//     this.getselectedItemCategory();
//     this.getselectedDeno();
//     this.getselectedAcctStore();
//     this.getselectedServiceLifeType();
//     this.getselectedEndLifeType();
//     this.getselectedOverhaulingTypes();
//     this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
//     this.getselectedToolsType();
//     this.getselectedLocation();
//     this.getselectedToolsBoxName();
//     this.getselectedSparesCategory();
//     this.getselectedLifeLimitItem();
//     this.getselectedConditionOfItem();
//    // this.getItemStors();
//   }
//   intitializeForm() {
//     this.ItemStorForm = this.fb.group({
//       itemStorId: [0],
//       doc:[''],
//       toolsTypeId:[''],
//       toolsBoxNameId:[''],
//       toolsLocationId:[''],
//       calibrationDate:[''],
//       nextCalibrationDate:[''],
//       acceptanceId: [''],
//       procurementId: [''],
//       demandId:[''],
//       denoId: [''],
//       departmentNameId: [''],
//       itemCategoryId:[''],
//       serviceLifeTypeId:[''],
//       sparesCategoryId:[''],
//       lifeLimitItemId:[''],
//       conditionOfItemId:[''],
//       endLifeTypeId: [''],
//       acctStoreId: [''],
//       overhaulingTypeId:[''],
//       retirementTypeId: [''],
//       itemDetailId:[''],
//       itemSerNo:[''],
//       icmNo:[''],
//       shelfLife:[''],
//       endShalfLife:[''],
//       warrantyStartDate:[''],
//       warrantyEndDate:[],
//       itemReceivedDate:[''],
//       totalReceivedQty:[''],
//       issuedQty:[''],
//       demandQty:[''],
//       demandDate:[''],
//       letterOuterNo:[''],
//       refPoNo:[''],
//       tenderNumber:[''],
//       dateOfTenderFloat:[''],
//       tenderopeningDate:[''],
//       //tenderPublishDate:[''],
//       tenderNotice:[''],
//       location:[''],
//       serviceLife:[''],
//       endLifeTime:[''],
//       accessories:[''],
//       stockRegisterPageNo:[''],
//       retirmentLife:[''],
//       remarks:[''],
//       arcDoc:[''],
//       cofcDoc:[''],
//       otherDoc:[''],
//       oemDoc:[''],
//       status:[''],
//       isActive: [true]

//     })
//   }

//   onFillDocChanged(event) {
//     if (event.target.files.length > 0) {
//       const file = event.target.files[0];
//       console.log('acceptance doc');
//       console.log(file);
//       this.ItemStorForm.patchValue({
//         doc: file,
//       });
//     }
//   }
//   getselectedAcceptence(){
//     var departmentNameId = this.ItemStorForm.value['departmentNameId'];
//     this.isShown=true;
//     console.log(departmentNameId);
//     this.ItemStorService.partnoFromAcceptanceByDepartmentName(departmentNameId, this.masterData.sparescategory.tools).subscribe(res=>{
//       this.selectedPartNo=res
//       console.log(this.selectedPartNo);
//     });

//     this.ItemStorService.getItemStorsByParameter(this.paging.pageIndex, this.paging.pageSize,this.searchText,departmentNameId,this.masterData.sparescategory.tools).subscribe(response => {
//       this.dataSource.data = response.items;
//       console.log("Data source list");
//       console.log(this.dataSource.data);
//       this.paging.length = response.totalItemsCount
//       this.isLoading = false;
//     })
//   }
//   getselectedAcceptenceOnUpdate(id){
//     this.ItemStorService.partnoFromAcceptanceForUpdateByDepartmentName(id, this.masterData.sparescategory.spares).subscribe(res=>{
//       this.selectedPartNo=res;
//       console.log(this.selectedPartNo)
//     });
//   }
//   getAcceptanceData(){
//     var acceptanceId = this.ItemStorForm.value['acceptanceId'];
//     console.log(acceptanceId);
//     this.ItemStorService.getacceptanceById(acceptanceId).subscribe(res=>{
//       this.acceptanceData=res;
//     });
//     this.acceptanceService.find(acceptanceId).subscribe(res=>{
//       this.acceptanceByDepartmentAndCategory=res
//       this.ItemStorForm.get('demandId').setValue(res.demandId);
//       this.ItemStorForm.get('itemDetailId').setValue(res.itemDetailId);
//       this.ItemStorForm.get('procurementId').setValue(res.procurementId);
//       this.ItemStorForm.get('sparesCategoryId').setValue(res.sparesCategoryId);
//       this.ItemStorForm.get('totalReceivedQty').setValue(res.sftQty);
//       console.log("selected acceptance");
//       console.log(this.acceptanceByDepartmentAndCategory);

//       this.procurementService.GetselectedProcurementById(res.procurementId).subscribe(res=>{
//         this.procurementData=res;
//       });
//       this.demandService.find(res.demandId).subscribe(res=>{
//         this.ItemStorForm.get('denoId').setValue(res.denoId);
//         this.ItemStorForm.get('demandQty').setValue(res.demandQty);
//         this.ItemStorForm.get('demandDate').setValue(res.demandDate);
//         this.ItemStorForm.get('letterOuterNo').setValue(res.letterOuterNo);
//         this.ItemStorForm.get('refPoNo').setValue(res.refPoNo);
//       });
//       this.procurementService.find(res.procurementId).subscribe(res=>{
//         this.ItemStorForm.get('tenderNumber').setValue(res.tenderNumber);
//         this.ItemStorForm.get('dateOfTenderFloat').setValue(res.dateOfTenderFloat);
//         this.ItemStorForm.get('tenderopeningDate').setValue(res.tenderopeningDate);
//         this.ItemStorForm.get('tenderPublishDate').setValue(res.tenderPublishDate);
//       });
//       this.isShown=true;
//     });

//   }
//   // getselectedDepartmentNames(){
//   //   this.ItemStorService.getselectedDepartmentNames().subscribe(res=>{
//   //     this.selectedDepartmentNames=res
//   //     console.log(this.selectedDepartmentNames);
//   //   });
//   // }
//   GetDepartmentNameById(baseNameId){
//     this.ItemStorService.getSelectedSchoolName(baseNameId).subscribe(res=>{
//       this.selectedDepartmentNames=res
//       console.log(res)
//     });
//   }
//   getselectedItemCategory(){
//     this.ItemStorService.getselectedItemCategory().subscribe(res=>{
//       this.selectedItemCategory=res
//       console.log(this.selectedItemCategory);
//     });
//   }
//   getselectedDeno(){
//     this.ItemStorService.getselectedDeno().subscribe(res=>{
//       this.selectedDeno=res
//       console.log(this.selectedDeno);
//     });
//   }
//   getselectedSparesCategory(){
//     this.ItemStorService.getselectedSparesCategory().subscribe(res=>{
//       this.selectedSparesCategory=res
//       //console.log(this.selectedDeno);
//     });
//   }
//   getselectedConditionOfItem(){
//     this.ItemStorService.getselectedConditionOfItem().subscribe(res=>{
//       this.selectedConditionofItem=res
//       //console.log(this.selectedAcctStore);
//     });
//   }
//   getselectedLifeLimitItem(){
//     this.ItemStorService.getselectedLifeLimitItem().subscribe(res=>{
//       this.selectedLifeLimitItem=res
//     });
//   }
//   getselectedAcctStore(){
//     this.ItemStorService.getselectedAcctStore().subscribe(res=>{
//       this.selectedAcctStore=res
//       console.log(this.selectedAcctStore);
//     });
//   }

//   getselectedToolsType(){
//     this.ItemStorService.getselectedToolsType().subscribe(res=>{
//       this.selectedToolsType=res
//       console.log(this.selectedToolsType);
//     });
//   }
//   getselectedLocation(){
//     this.ItemStorService.getselectedLocation().subscribe(res=>{
//       this.selectedLocation=res
//       console.log(this.selectedLocation);
//     });
//   }
//   getselectedToolsBoxName(){
//     this.ItemStorService.getselectedToolsBoxName().subscribe(res=>{
//       this.selectedToolsBoxName=res
//       console.log(this.selectedToolsBoxName);
//     });
//   }

//   getselectedServiceLifeType(){
//     this.ItemStorService.getselectedServiceLifeType().subscribe(res=>{
//       this.selectedServiceLifeType=res
//       console.log(this.selectedServiceLifeType);
//     });
//   }
//   getselectedEndLifeType(){
//     this.ItemStorService.getselectedEndLifeType().subscribe(res=>{
//       this.selectedEndLifeType=res
//       console.log(this.selectedEndLifeType);
//     });
//   }
//   getselectedOverhaulingTypes(){
//     this.ItemStorService.getselectedOverhaulingTypes().subscribe(res=>{
//       this.selectedOverhaulingTypes=res
//       console.log(this.selectedOverhaulingTypes);
//     });
//   }

//   getItemStors() {
//     this.isLoading = true;
//     this.ItemStorService.getItemStors(this.paging.pageIndex, this.paging.pageSize,this.searchText, this.masterData.sparescategory.tools).subscribe(response => {
//       this.dataSource.data = response.items;
//       console.log("Data source list");
//       console.log(this.dataSource.data);
//       this.paging.length = response.totalItemsCount
//       this.isLoading = false;
//     })
//   }

//   pageChanged(event: PageEvent) {
//     this.paging.pageIndex = event.pageIndex
//     this.paging.pageSize = event.pageSize
//     this.paging.pageIndex = this.paging.pageIndex + 1
//     this.getItemStors();
//   }

//   applyFilter(searchText: any){
//     this.searchText = searchText;
//     this.getItemStors();
//   }

//   deleteItem(row) {
//     const id = row.itemStorId;
//     this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
//       console.log(result);
//       if (result) {
//         this.ItemStorService.delete(id).subscribe(() => {
//       //    this.getItemStors();
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
//   reloadCurrentRoute() {
//     let currentUrl = this.router.url;
//     this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
//         this.router.navigate([currentUrl]);
//     });
//   }
//   onSubmit() {
//     const id = this.ItemStorForm.get('itemStorId').value;
//     this.ItemStorForm.get('demandDate').setValue((new Date(this.ItemStorForm.get('demandDate').value)).toUTCString());
//     this.ItemStorForm.get('warrantyEndDate').setValue((new Date(this.ItemStorForm.get('warrantyEndDate').value)).toUTCString());
//     console.log(this.ItemStorForm.value)
//     const formData = new FormData();
//     for (const key of Object.keys(this.ItemStorForm.value)) {
//       const value = this.ItemStorForm.value[key];
//       formData.append(key, value);
//     }
//     if (id) {
//       this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {

//         if (result) {
//           this.ItemStorService.update(+id,formData).subscribe(response => {
//             this.router.navigateByUrl('/tools-management/add-toolstore');
//            //this.reloadCurrentRoute();
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
//       this.ItemStorService.submit(formData).subscribe(response => {
//         this.router.navigateByUrl('/tools-management/add-toolstore');
//         this.getItemStors();
//         this.reloadCurrentRoute();
//         this.intitializeForm();
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

// }

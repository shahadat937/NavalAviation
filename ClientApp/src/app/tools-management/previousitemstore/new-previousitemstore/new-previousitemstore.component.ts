import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { PreviousItemStoreService } from "../../../spares-management/service/PreviousItemStore.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { PreviousItemStore } from "../../../spares-management/models/PreviousItemStore";
import { MasterData } from "src/assets/data/master-data";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";
import { ItemStorService } from "../../service/ItemStor.service";
import { ItemStor } from "src/app/spares-management/models/ItemStor";
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ItemDetailService } from "../../service/itemDetail.service";

@Component({
  selector: "app-new-previousitemstore",
  templateUrl: "./new-previousitemstore.component.html",
  styleUrls: ["./new-previousitemstore.component.sass"],
})
export class NewPreviousItemStoreComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  masterData = MasterData;
  PreviousItemStoreForm: FormGroup;
  validationErrors: string[] = [];
  selectedDepartmentNames: SelectedModel[];
  selectedItemDetails: SelectedModel[];
  selectedDeno: SelectedModel[];
  selectedItemCategory: SelectedModel[];
  selectedSparesCategory: SelectedModel[];
  selectedServiceLifeType: SelectedModel[];
  selectedEndLifeType: SelectedModel[];
  selectedAcctStore: SelectedModel[];
  selectedOverhaulingTypes: SelectedModel[];
  selectedRetirementTypes: SelectedModel[];
  selectedToolsType: SelectedModel[];
  selectedToolsBoxNames: SelectedModel[];
  selectedToolsLocations: SelectedModel[];
  selectedConditionofItem: SelectedModel[];
  selectedLifeLimitItem: SelectedModel[];
  previousItemStoreListByDepartmentId: PreviousItemStore[];
  isShown: boolean = false;
  isLoading = false;
  userRole = Role;
  groupArrays: { departmentName: string; datas: any }[];
  traineeId: any;
  role: any;
  branchId: any;
  showHideDiv = false;
  lifeLimit: any;
  options = [];
  filteredOptions;
  itemDetailId: number;
  nameOfItem:any;

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

  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private confirmService: ConfirmService,
    private PreviousItemStoreService: PreviousItemStoreService,
    private itemDetailsService: ItemDetailService,
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
      this.pageTitle = "Edit Previous Item Store";
      this.destination = "Edit";
      this.btnText = "Update";
      this.ItemStorService.find(+id).subscribe((res) => {
        this.PreviousItemStoreForm.patchValue({
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
          tenderopeningDate: res.tenderopeningDate,
          tenderPublishDate: res.tenderPublishDate,
          tenderNotice: res.tenderNotice,
          location: res.location,
          serviceLife: res.serviceLife,
          endLifeTime: res.endLifeTime,
          accessories: res.accessories,
          stockRegisterPageNo: res.stockRegisterPageNo,
          retirmentLife: res.retirmentLife,
          permanentQty: res.permanentQty,
          tyQty: res.tyQty,
          repairQty: res.repairQty,
          surveyQty: res.surveyQty,
          aircraftFittedQty: res.aircraftFittedQty,
          maintenanceQty: res.maintenanceQty,
          calibrationQty: res.calibrationQty,
          remarks: res.remarks,
          //arcDoc: res.arcDoc,
          //cofcDoc: res.cofcDoc,
          otherDoc: res.otherDoc,
          //oemDoc: res.oemDoc,
          //status: res.status,
          isActive: res.isActive,
          model:res.model,
          brand:res.brand
        });
        console.log(res.partNo);
        this.itemDetailId = res.itemDetailId;
        console.log("res.partNo");
      });
    } else {
      this.pageTitle = "Create Previous Item Store";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.PreviousItemStoreForm.get("departmentNameId").setValue(
        this.branchId
      );
      this.onDepartmentSelectionChange();
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.PreviousItemStoreForm.get("departmentNameId").setValue(
        this.branchId
      );
      this.onDepartmentSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    //this.getselectedItemDetails();
    this.getselectedDeno();
    this.getselectedItemCategory();
    this.getselectedSparesCategory();
    this.getselectedServiceLifeType();
    this.getselectedEndLifeType();
    this.getselectedAcctStore();
    this.getselectedOverhaulingTypes();
    this.getselectedRetirementTypes();
    this.getselectedToolsType();
    this.getselectedToolsBoxNames();
    this.getselectedToolsLocations();
    this.getselectedConditionOfItem();
    this.getselectedLifeLimitItem();
  }
  intitializeForm() {
    this.PreviousItemStoreForm = this.fb.group({
      itemStorId: [0],
      acceptanceId: [""],
      procurementId: [""],
      demandId: [""],
      denoId: [""],
      departmentNameId: [""],
      itemCategoryId: [""],
      serviceLifeTypeId: [""],
      sparesCategoryId: [2],
      conditionOfItemId: [""],
      lifeLimitItemId: [""],
      toolsLocationId: [""],
      endLifeTypeId: [""],
      acctStoreId: [""],
      overhaulingTypeId: [""],
      retirementTypeId: [""],
      itemDetailId: [""],
      part: [""],
      partNo: [""],
      itemSerNo: [""],
      icmNo: [""],
      shelfLife: [""],
      endShalfLife: [""],
      warrantyStartDate: [""],
      warrantyEndDate: [""],
      itemReceivedDate: [""],
      totalReceivedQty: [""],
      availableQty: [""],
      issuedQty: [0],
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
      remarks: ["Previous Store"],
      arcDoc: [""],
      cofcDoc: [""],
      permanentQty: [0],
      tyQty: [0],
      repairQty: [0],
      surveyQty: [0],
      aircraftFittedQty: [0],
      maintenanceQty: [0],
      calibrationQty: [0],
      doc: [""],
      otherDoc: [""],
      oemDoc: [""],
      status: [2],
      isActive: [true],
      model:[''],
      brand:['']
    });
    //autocomplete
    this.PreviousItemStoreForm.get("part").valueChanges.subscribe((value) => {
      this.getSelectedTraineeByPno(value);
    });
  }
  applyFilter(searchText: any) {
    this.searchText = searchText;
    var departmentId = this.PreviousItemStoreForm.get("departmentNameId").value;
    this.getItemStorsList(departmentId);
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  //autocomplete
  onTraineeSelectionChanged(item) {
    this.itemDetailId = item.value;
    this.PreviousItemStoreForm.get("itemDetailId").setValue(item.value);
    this.PreviousItemStoreForm.get("part").setValue(item.text);
    this.itemDetailsService.find(this.itemDetailId).subscribe((res) => {
      console.log(res);
      this.nameOfItem =res.nameOfItem
      console.log(this.nameOfItem);
      console.log("item Detail");
      
   
    });
  }
// Auto complete
  getSelectedTraineeByPno(pno) {
    var departmentNameId = this.PreviousItemStoreForm.value["departmentNameId"];
    this.PreviousItemStoreService.getSelectedPartNoForSpareParameterRequest(pno,departmentNameId,2).subscribe(
      (response) => {
        this.options = response;
        this.filteredOptions = response;
      }
    );
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
          <h3>Old Stock Registor List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onDepartmentSelectionChange() {
    this.isShown = true;
    var departmentNameId = this.PreviousItemStoreForm.value["departmentNameId"];
    // this.PreviousItemStoreService.getPreviousItemStoreListByDepartmentId(
    //   departmentNameId
    // ).subscribe((res) => {
    //   this.previousItemStoreListByDepartmentId = res;
    //   console.log(this.previousItemStoreListByDepartmentId);
    // });
    this.getItemStorsList(departmentNameId);
    this.getselectedItemDetails();
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    var departmentNameId = this.PreviousItemStoreForm.value["departmentNameId"];
    this.getItemStorsList(departmentNameId);
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
      2
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      console.log(this.dataSource.data);
      this.paging.length = response.totalItemsCount;
      console.log(this.dataSource);
      console.log("DATA");
      console.log(response.totalItemsCount)
      console.log("DATA COUNT");
      this.isLoading = false;

      // this gives an object with dates as keys
      // const groups = this.dataSource.data.reduce((groups, datas) => {
      //   const departmentName = datas.departmentName;
      //   if (!groups[departmentName]) {
      //     groups[departmentName] = [];
      //   }
      //   groups[departmentName].push(datas);
      //   return groups;
      // }, {});

      // Edit: to add it in the array format instead
      // this.groupArrays = Object.keys(groups).map((departmentName) => {
      //   return {
      //     departmentName,
      //     datas: groups[departmentName],
      //   };
      // });

      // console.log(this.groupArrays);
    });
  }
  getselectedItemDetails() {
    var departmentNameId = this.PreviousItemStoreForm.get("departmentNameId").value;
    this.PreviousItemStoreService.getselectedItemDetails(departmentNameId, this.masterData.sparescategory.tools).subscribe((res) => {
      this.selectedItemDetails = res;
      console.log(this.selectedItemDetails);
    });
  }
  getselectedLifeLimitItem() {
    this.PreviousItemStoreService.getselectedLifeLimitItem().subscribe(
      (res) => {
        this.selectedLifeLimitItem = res;
      }
    );
  }
  getselectedToolsType() {
    this.PreviousItemStoreService.getselectedToolsType().subscribe((res) => {
      this.selectedToolsType = res;
      console.log(this.selectedToolsType);
    });
  }
  getselectedToolsBoxNames() {
    this.PreviousItemStoreService.getselectedToolsBoxNames().subscribe(
      (res) => {
        this.selectedToolsBoxNames = res;
        console.log(this.selectedToolsBoxNames);
      }
    );
  }

  getselectedConditionOfItem() {
    this.PreviousItemStoreService.getselectedConditionOfItem().subscribe(
      (res) => {
        this.selectedConditionofItem = res;
        //console.log(this.selectedAcctStore);
      }
    );
  }
  getselectedToolsLocations() {
    this.PreviousItemStoreService.getselectedToolsLocations().subscribe(
      (res) => {
        this.selectedToolsLocations = res;
        console.log(this.selectedToolsLocations);
      }
    );
  }
  getselectedDeno() {
    this.PreviousItemStoreService.getselectedDeno().subscribe((res) => {
      this.selectedDeno = res;
      console.log(this.selectedDeno);
    });
  }
  // getselectedDepartmentNames(){
  //   this.PreviousItemStoreService.getselectedDepartmentNames().subscribe(res=>{
  //     this.selectedDepartmentNames=res
  //     console.log(this.selectedDepartmentNames);
  //   });
  // }

  onFillDocChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log("acceptance doc");
      console.log(file);
      this.PreviousItemStoreForm.patchValue({
        doc: file,
      });
    }
  }

  GetDepartmentNameById(baseNameId) {
    this.PreviousItemStoreService.getSelectedSchoolName(baseNameId).subscribe(
      (res) => {
        this.selectedDepartmentNames = res;
        console.log(res);
      }
    );
  }
  getselectedItemCategory() {
    this.PreviousItemStoreService.getSelectedItemCategory(this.masterData.sparescategory.tools).subscribe((res) => {
      this.selectedItemCategory = res;
      console.log(this.selectedItemCategory);
    });
  }
  getselectedSparesCategory() {
    this.PreviousItemStoreService.getselectedSparesCategory().subscribe(
      (res) => {
        this.selectedSparesCategory = res;
        console.log(this.selectedSparesCategory);
      }
    );
  }
  getselectedServiceLifeType() {
    this.PreviousItemStoreService.getselectedServiceLifeType().subscribe(
      (res) => {
        this.selectedServiceLifeType = res;
        console.log(this.selectedServiceLifeType);
      }
    );
  }
  getselectedEndLifeType() {
    this.PreviousItemStoreService.getselectedEndLifeType().subscribe((res) => {
      this.selectedEndLifeType = res;
      console.log(this.selectedEndLifeType);
    });
  }
  getselectedAcctStore() {
    this.PreviousItemStoreService.getselectedAcctStore().subscribe((res) => {
      this.selectedAcctStore = res;
      console.log(this.selectedAcctStore);
    });
  }
  getselectedOverhaulingTypes() {
    this.PreviousItemStoreService.getselectedOverhaulingTypes().subscribe(
      (res) => {
        this.selectedOverhaulingTypes = res;
        console.log(this.selectedOverhaulingTypes);
      }
    );
  }
  onStatus(dropdown) {
    if (dropdown.isUserInput) {
      this.lifeLimit = dropdown.source.value;
      console.log(this.lifeLimit);
    }
  }
  getselectedRetirementTypes() {
    this.PreviousItemStoreService.getselectedRetirementTypes().subscribe(
      (res) => {
        this.selectedRetirementTypes = res;
        console.log(this.selectedRetirementTypes);
      }
    );
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.PreviousItemStoreForm.get("itemStorId").value;
    var warrantyEndDate = this.PreviousItemStoreForm.get("warrantyEndDate").value;

    this.PreviousItemStoreForm.get("demandDate").setValue(new Date());
    this.PreviousItemStoreForm.get("demandDate").setValue(
      new Date(this.PreviousItemStoreForm.get("demandDate").value).toUTCString()
    );
    
    this.PreviousItemStoreForm.get("manufacturingDate").setValue(
      new Date(this.PreviousItemStoreForm.get("manufacturingDate").value).toUTCString()
    );

    if(warrantyEndDate){
      this.PreviousItemStoreForm.get("warrantyEndDate").setValue(
        new Date(this.PreviousItemStoreForm.get("warrantyEndDate").value).toUTCString()
      );
    }else{
      this.PreviousItemStoreForm.get("warrantyEndDate").setValue(new Date());
      this.PreviousItemStoreForm.get("warrantyEndDate").setValue(
        new Date(this.PreviousItemStoreForm.get("warrantyEndDate").value).toUTCString()
      );
    }
    console.log(this.PreviousItemStoreForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.PreviousItemStoreForm.value)) {
      const value = this.PreviousItemStoreForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.ItemStorService.update(+id, formData).subscribe(
              (response) => {
                this.router.navigateByUrl("/spares-management/add-itemstor");
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
          //this.router.navigateByUrl('/spares-management/add-itemstor');
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

  deleteItem(row) {
    console.log(row);
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
}

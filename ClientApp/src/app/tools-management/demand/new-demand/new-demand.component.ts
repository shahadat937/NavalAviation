import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { DemandService } from "../../../tools-management/service/Demand.service";
import { ItemDetailService } from "../../../tools-management/service/itemDetail.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ConfirmService } from "../../../core/service/confirm.service";
import { MasterData } from "src/assets/data/master-data";
import { Demand } from "../../models/Demand";
import { MatTableDataSource } from "@angular/material/table";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";

@Component({
  selector: "app-new-demand",
  templateUrl: "./new-demand.component.html",
  styleUrls: ["./new-demand.component.sass"],
})
export class NewDemandComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  DemandForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel: SelectedModel[];
  selectedAuthority: SelectedModel[];
  selectedItemDetails: SelectedModel[];
  selectedDeno: SelectedModel[];
  selectedDemandStaus: SelectedModel[];
  selectedTrade: SelectedModel[];
  groupArrays: { departmentName: string; datas: any }[];
  selectedItemCategory: SelectedModel[];
  selectedSupplierValue: SelectedModel[];
  selectedFiscalYear: SelectedModel[];
  selectedItemType: SelectedModel[];
  selectedOccasionOfDemand: SelectedModel[];
  selectedDemandAuthority: SelectedModel[];
  selectedDepartmentName: SelectedModel[];
  selectedConditionOfItem: SelectedModel[];
  selectedTypeOfDemandValue: SelectedModel[];
  selectedManufacture: SelectedModel[];
  selectedPartNo: SelectedModel[];
  selectedItemName: SelectedModel[];
  itemValue: string;
  itemCount: any = 0;
  itemDetailId: number;
  itemCategoryId: number;
  sparesCategoryId: 1;
  options = [];
  filteredOptions;
  isShown: boolean = false;
  isConditionShown: boolean = false;
  masterData = MasterData;
  demandList: Demand[];
  isLoading = false;
  status: any;
  showHideDiv = false;
  userRole = Role;

  traineeId: any;
  role: any;
  branchId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  displayedColumns: string[] = [
    "ser",
    "itemDetail",
    "itemName",
    "conditionOfItem",
    "deno",
    "demandQty",
    "demandNo",
    "demandDate",
    "refPrice",
    "actions",
  ];
  dataSource: MatTableDataSource<Demand> = new MatTableDataSource();
  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private itemDetailsService: ItemDetailService,
    private confirmService: ConfirmService,
    private DemandService: DemandService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("demandId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (id) {
      this.pageTitle = "Edit Demand";
      this.destination = "Edit";
      this.btnText = "Update";
      this.DemandService.find(+id).subscribe((res) => {
        this.DemandForm.patchValue({
          demandId: res.demandId,
          authorityId: res.authorityId,
          tradeId: res.tradeId,
          departmentNameId: res.departmentNameId,
          demandStatusId: res.demandStatusId,
          demandTypeId: res.demandTypeId,
          itemDetailId: res.itemDetailId,
          denoId: res.denoId,
          //supplierId:res.supplierId,
          manufactureId: res.manufactureId,
          fiscalYearId: res.fiscalYearId,
          itemCategoryId: res.itemCategoryId,
          //itemTypeId: res.itemTypeId,
          //sparesCategoryId: res.sparesCategoryId,
          occasionOfDemandId: res.occasionOfDemandId,
          //demandAuthorityId: res.demandAuthorityId,
          demandNo: res.demandNo,
          demandDate: res.demandDate,
          letterOuterNo: res.letterOuterNo,
          refPrice: res.refPrice,
          refPoNo: res.refPoNo,
          conditionOfItemId: res.conditionOfItemId,
          //demandDocId: res.demandDocId,
          //demandCompleteStatusId: res.demandCompleteStatusId,
          demandQty: res.demandQty,
          demandLetterNo: res.demandLetterNo,
          specDoc: res.specDoc,
          remarks: res.remarks,
          oldPrice: res.oldPrice,
          oldRefNo: res.oldRefNo,
          manufactureAddress: res.manufactureAddress,
          part: res.partNo,
          // status: res.status,
          // menuPosition: res.menuPosition,
          // isActive: res.isActive
        });
        console.log(res.partNo);
        this.itemDetailId = res.itemDetailId;
        console.log("res.partNo");
        this.getItemNameById(this.itemDetailId);
      });
    } else {
      this.pageTitle = "Create Demand";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.DemandForm.get("departmentNameId").setValue(this.branchId);
      this.onDepartmentSelectionChange();
    }
    this.getSelectedAuthority();
    this.getSelectedItemDetails();
    this.getSelectedDeno();
    this.getSelectedDemandStatus();
    this.getSelectedFiscalYear();
    this.getSelectedItemType();
    this.getSelectedOccasionOfDemand();
    this.getSelectedDemandAuthority();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getSelectedConditionOfItem();
    this.getSelectedSuplier();
    this.getSelectedTypeOfDemand();
    this.getSelectedManufacture();
    this.getSelectedTrade();
    this.getSelectedItemCategory();

    if (this.role == this.userRole.CO) {
      this.isShown = true;
      this.getDemandsList(0, 0);
    }
  }
  intitializeForm() {
    this.DemandForm = this.fb.group({
      demandId: [0],
      authorityId: [""],
      tradeId: [""],
      part: [""],
      doc: [""],
      specDocument: [""],
      specDoc: [""],
      itemName: [""],
      itemDetailId: [""],
      denoId: [""],
      //supplierId:[''],
      manufactureId: [""],
      sparesCategoryId: [2],
      fiscalYearId: [""],
      itemCategoryId: [],
      //itemTypeId: [''],
      occasionOfDemandId: [""],
      //demandAuthorityId: [1],
      demandStatusId: [""],
      demandTypeId: [""],
      //demandDocId: [''],
      conditionOfItemId: [""],
      departmentNameId: [""],
      demandCompleteStatus: [0],
      demandQty: [""],
      demandLetterNo: [""],
      demandNo: [""],
      demandDate: [],
      letterOuterNo: [""],
      refPrice: [""],
      refPoNo: [""],
      remarks: [""],
      oldPrice: [""],
      oldRefNo: [""],
      manufactureAddress: [""],
      status: [1],
      menuPosition: [1],
      isActive: [true],
    });
    //autocomplete
    this.DemandForm.get("part").valueChanges.subscribe((value) => {
      this.getSelectedTraineeByPno(value);
    });
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      this.DemandForm.patchValue({
        doc: file,
      });
    }
  }
  inActiveItem(row){
    const id = row.demandId; 
          this.confirmService.confirm('Confirm Approved message', 'Are You Sure Approved This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.DemandService.approvedDemand(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.getDemandsList(row.departmentNameId, 0);
            // this.reloadCurrentRoute();
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
  onDemandTypeSelect() {
    var demandTypeId = this.DemandForm.value["demandTypeId"];
    console.log(demandTypeId);
    if (demandTypeId == 1) {
      this.isConditionShown = true;
    } else {
      this.isConditionShown = false;
    }
  }

  onTenderSpecChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      // this.labelImport.nativeElement.value = file.name;

      console.log(file);
      // this.BIODataGeneralInfoForm.controls["picture"].setValue(event.target.files[0]);
      this.DemandForm.patchValue({
        specDocument: file,
      });
    }
  }
  getPartNoPassItemCategoryIdInDemand(itemDetailId: number) {
    this.DemandService.getPartNoPassItemCategoryIdInDemand(
      itemDetailId
    ).subscribe((res) => {
      this.selectedItemDetails = res;
      console.log(this.filteredOptions);
    });
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
    // console.log(item);
    this.itemDetailId = item.value;
    this.itemCategoryId = item.value;
    this.DemandForm.get("itemDetailId").setValue(item.value);
    this.DemandForm.get("part").setValue(item.text);
    this.getItemNameById(this.itemDetailId);
    this.getPartNoPassItemCategoryIdInDemand(this.itemCategoryId);
    console.log(item.value);
    console.log("V");
    this.itemDetailsService.find(this.itemDetailId).subscribe((res) => {
      console.log("Trade response");
      console.log(res);
      this.DemandForm.get("itemCategoryId").setValue(res.itemCategoryId);
      this.DemandForm.get("tradeId").setValue(res.tradeId);
      console.log(res.itemCategoryId);
      //this.sparesCategoryId = Number(res.sparesCategoryId);
      //this.DemandForm.get('sparesCategoryId').setValue(this.sparesCategoryId);
      //console.log(this.sparesCategoryId);
    });
    // this.baseSchoolNameId = this.CourseModuleForm.get('baseSchoolNameId').value;

    //    this.isShown=true;
    //  this.CourseNameService.getCourseModuleListByBaseSchoolNameIdCourseNameId(this.baseSchoolNameId,this.courseNameId).subscribe(response => {
    //    this.moduleList = response;
    //  })getSelectedPartNoByNameForSpares
  }
  //autocomplete
  //  getSelectedTraineeByPno(pno){
  //    this.DemandService.getSelectedCourseByName(pno).subscribe(response => {
  //      this.options = response;
  //      this.filteredOptions = response;
  //    })
  //  }
  getSelectedTraineeByPno(pno) {
    var departmentNameId = this.DemandForm.value["departmentNameId"];
    this.DemandService.getSelectedPartNoForToolsParameterRequest(pno,departmentNameId,2).subscribe(
      (response) => {
        this.options = response;
        this.filteredOptions = response;
      }
    );
  }

  onStatus(dropdown) {
    if (dropdown.isUserInput) {
      this.status = dropdown.source.value;
      console.log(this.status);
    }
  }
  getSelectedItemDetails() {
    this.DemandService.getSelectedItemDetails().subscribe((res) => {
      this.selectedItemDetails = res;
    });
  }
  getSelectedAuthority() {
    this.DemandService.getSelectedAuthority().subscribe((res) => {
      this.selectedAuthority = res;
    });
  }

  getSelectedTypeOfDemand() {
    this.DemandService.getSelectedTypeOfDemand().subscribe((res) => {
      this.selectedTypeOfDemandValue = res;
    });
  }
  getSelectedDeno() {
    this.DemandService.getSelectedDeno().subscribe((res) => {
      this.selectedDeno = res;
    });
  }
  getSelectedDemandStatus() {
    this.DemandService.getSelectedDemandStatus().subscribe((res) => {
      this.selectedDemandStaus = res;
    });
  }
  getSelectedTrade() {
    this.DemandService.getSelectedTrade().subscribe((res) => {
      this.selectedTrade = res;
    });
  }
  getSelectedItemCategory() {
    this.DemandService.getSelectedItemCategory(this.masterData.sparescategory.tools).subscribe((res) => {
      this.selectedItemCategory = res;
    });
  }
  getSelectedManufacture() {
    this.DemandService.getSelectedManufacture().subscribe((res) => {
      this.selectedManufacture = res;
    });
  }
  reloadManufacturerers() {
    console.log("reloading");
    this.getSelectedManufacture();
  }
  getSelectedSuplier() {
    this.DemandService.getSelectedSuplier().subscribe((res) => {
      this.selectedSupplierValue = res;
    });
  }

  getSelectedFiscalYear() {
    this.DemandService.getSelectedFiscalYear().subscribe((res) => {
      this.selectedFiscalYear = res;
    });
  }
  getSelectedItemType() {
    this.DemandService.getSelectedItemType().subscribe((res) => {
      this.selectedItemType = res;
    });
  }

  getSelectedOccasionOfDemand() {
    this.DemandService.getSelectedOccasionOfDemand().subscribe((res) => {
      this.selectedOccasionOfDemand = res;
    });
  }
  getSelectedDemandAuthority() {
    this.DemandService.getSelectedDemandAuthority().subscribe((res) => {
      this.selectedDemandAuthority = res;
    });
  }
  // getSelectedDepartmentName() {
  //   this.DemandService.getSelectedDepartmentName().subscribe(res => {
  //     this.selectedDepartmentName = res;

  //   });
  // }
  GetDepartmentNameById(baseNameId) {
    this.DemandService.getSelectedSchoolName(baseNameId).subscribe((res) => {
      this.selectedDepartmentName = res;
      console.log(res);
    });
  }

  getSelectedConditionOfItem() {
    this.DemandService.getSelectedConditionOfItem().subscribe((res) => {
      this.selectedConditionOfItem = res;
    });
  }
  getPartNoByDepartmentNameId(id: number) {
    this.itemDetailsService.getPartNoForToolsByDepartmentNameId(id,2).subscribe((res) => {
      this.filteredOptions = res;
      // this.filteredOptions=this.filteredOptions.filter(x=>x.sparesCategoryId==1)

      console.log(this.filteredOptions);
    });
  }
  onDepartmentSelectionChange() {
    this.isShown = true;
    var departmentNameId = this.DemandForm.value["departmentNameId"];
    this.getPartNoByDepartmentNameId(departmentNameId);
    this.getDemandsList(departmentNameId, 0);
  }
  getItemNameById(id: number) {
    console.log(id);
    this.itemDetailsService.getItemNameById(id).subscribe((res) => {
      this.selectedItemName = res;
      console.log(this.selectedItemName);
      this.itemValue = this.selectedItemName[0].value;
      console.log(this.itemValue);
    });
  }
  onPartNoSelectionChange(dropdown) {
    if (dropdown.isUserInput) {
      console.log(dropdown.source.value);
      this.getItemNameById(dropdown.source.value);
      //this.getPartNoByDepartmentNameId(dropdown.source.value);
    }
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  getDemandsList(departmentId, demandTypeId) {
    this.isLoading = true;
    this.DemandService.getDemandListByDepartmentNameId(
      this.paging.pageIndex,
      100000,
      this.searchText,
      this.masterData.sparescategory.tools,
      departmentId,
      demandTypeId
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      console.log("dddddd");
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

  applyFilter(searchText: any) {
    this.searchText = searchText;
    var departmentId = this.DemandForm.get("departmentNameId").value;
    console.log(departmentId);
    this.getDemandsList(departmentId, 0);
  }
  applyDropdown(searchText: any, departmentNameId: any, demandTypeId: any) {
    this.searchText = searchText;
    //var departmentId = departmentNameId;
    //var departmentId = this.DemandForm.get("departmentNameId").value;
    console.log(departmentNameId, demandTypeId);
    this.getDemandsList(departmentNameId, demandTypeId);
    //this.getDemandsList(departmentId);
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
          <h3>New Demand List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    const id = this.DemandForm.get("demandId").value;
    console.log(this.DemandForm);
    this.DemandForm.get("demandDate").setValue(
      new Date(this.DemandForm.get("demandDate").value).toUTCString()
    );

    console.log(this.DemandForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.DemandForm.value)) {
      const value = this.DemandForm.value[key];
      formData.append(key, value);
    }

    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.DemandService.update(+id, formData).subscribe(
              (response) => {
                this.router.navigateByUrl("/tools-management/add-demand");
                //this.router.navigateByUrl('/tools-management/add-demand');
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
      this.DemandService.submit(formData).subscribe(
        (response) => {
          //this.router.navigateByUrl('/tools-management/add-demand');
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
  deleteItem(row) {
    const id = row.demandId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This  Item?")
      .subscribe((result) => {
        console.log(result);
        if (result) {
          this.DemandService.delete(id).subscribe(() => {
            //this.getDemands();
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

// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { ActivatedRoute, Router } from '@angular/router';
// import { DemandService } from '../../../tools-management/service/Demand.service';
// import { ItemDetailService } from '../../../tools-management/service/itemDetail.service';
// import { SelectedModel } from 'src/app/core/models/selectedModel';
// import { MatSnackBar } from '@angular/material/snack-bar';
// import { ConfirmService } from '../../../core/service/confirm.service';
// import { MasterData } from 'src/assets/data/master-data';
// import { MatTableDataSource } from '@angular/material/table';
// import { Demand } from '../../models/Demand';
// import { Role } from 'src/app/core/models/role';
// import { AuthService } from 'src/app/core/service/auth.service';

// @Component({
//   selector: 'app-new-demand',
//   templateUrl: './new-demand.component.html',
//   styleUrls: ['./new-demand.component.sass']
// })
// export class NewDemandComponent implements OnInit {
//   pageTitle: string;
//   destination:string;
//   btnText:string;
//   DemandForm: FormGroup;
//   validationErrors: string[] = [];
//   selectedModel:SelectedModel[];
//   selectedAuthority:SelectedModel[];
//   selectedItemDetails:SelectedModel[];
//  selectedDeno:SelectedModel[];
//  selectedFiscalYear:SelectedModel[];
//  selectedManufacture:SelectedModel[];
//  selectedItemCategory:SelectedModel[];
//  selectedTrade:SelectedModel[];
//  selectedItemType:SelectedModel[];
//  selectedOccasionOfDemand:SelectedModel[];
//  selectedDemandAuthority:SelectedModel[];
//  selectedDepartmentName:SelectedModel[];
//  selectedConditionOfItem:SelectedModel[];
//  selectedPartNo:SelectedModel[];
//  selectedItemName:SelectedModel[];
//  selectedTypeOfDemandValue:SelectedModel[];
//  selectedDemandStaus:SelectedModel[];
//  itemValue:string;
//  itemDetailId:number;
//  sparesCategoryId:any;
//  options = [];
//  filteredOptions;
//  masterData = MasterData;
//  isLoading = false;
//  isShown: boolean = false;
//  status:any;
//  userRole = Role;

//  traineeId:any;
//  role:any;
//  branchId:any;

//  paging = {
//   pageIndex: this.masterData.paging.pageIndex,
//   pageSize: this.masterData.paging.pageSize,
//   length: 1
// }
// searchText="";

// displayedColumns: string[] = [ 'ser','itemDetail', 'itemName', 'conditionOfItem','deno','demandQty', 'demandNo', 'demandDate',   'refPrice', 'actions'];
// dataSource: MatTableDataSource<Demand> = new MatTableDataSource();
// constructor(private snackBar: MatSnackBar,private authService: AuthService,private itemDetailsService:ItemDetailService,private confirmService: ConfirmService,private DemandService: DemandService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

//   ngOnInit(): void {
//     const id = this.route.snapshot.paramMap.get('demandId');

//     this.role = this.authService.currentUserValue.role.trim();
//     this.traineeId =  this.authService.currentUserValue.traineeId.trim();
//     this.branchId =  this.authService.currentUserValue.branchId.trim();
//     console.log(this.role, this.traineeId,  this.branchId)

//     if (id) {
//       this.pageTitle = 'Edit Demand';
//       this.destination = "Edit";
//       this.btnText = 'Update';
//       this.DemandService.find(+id).subscribe(
//         res => {
//           this.DemandForm.patchValue({
//             demandId: res.demandId,
//             authorityId: res.authorityId,
//             itemDetailId: res.itemDetailId,
//             denoId: res.denoId,
//             manufactureId:res.manufactureId,
//             itemCategoryId:res.itemCategoryId,
//             fiscalYearId: res.fiscalYearId,
//             tradeId:res.tradeId,
//             //itemTypeId: res.itemTypeId,
//             demandStatusId:res.demandStatusId,
//             occasionOfDemandId: res.occasionOfDemandId,
//             sparesCategoryId: res.sparesCategoryId,
//             //demandAuthorityId: res.demandAuthorityId,
//             //demandTypeId: res.demandTypeId,
//             //demandDocId: res.demandDocId,
//             demandNo: res. demandNo,
//             conditionOfItemId: res.conditionOfItemId,
//             departmentNameId: res.departmentNameId,
//             demandCompleteStatusId: res.demandCompleteStatusId,
//             demandQty: res.demandQty,
//             demandLetterNo: res.demandLetterNo,
//             demandDate: res.demandDate,
//             letterOuterNo: res.letterOuterNo,
//             specDoc:res.specDoc,
//             refPrice: res.refPrice,
//             refPoNo: res.refPoNo,
//             remarks: res.remarks,
//             oldPrice: res.oldPrice,
//             oldRefNo: res.oldRefNo,
//             manufactureAddress: res.manufactureAddress,
//             partNo:res.partNo,
//             // status: res.status,
//             // menuPosition: res.menuPosition,
//             // isActive: res.isActive
//           });
//           console.log(res.partNo)
//           this.itemDetailId = res.itemDetailId
//           this.getItemNameById(this.itemDetailId);
//         }
//       );
//     } else {
//       this.pageTitle = 'Create Demand';
//       this.destination = "Add";
//       this.btnText = 'Save';
//     }
//     this.intitializeForm();
//     if(this.role != this.userRole.SuperAdmin){
//       this.DemandForm.get('departmentNameId').setValue(this.branchId);
//       this.onDepartmentNameSelectionChange();
//     }
//     this.getSelectedAuthority();
//     this.getSelectedItemDetails();
//     this.getSelectedDeno();
//     this.getSelectedFiscalYear();
//     this.getSelectedItemType();
//     this.getSelectedOccasionOfDemand();
//     this.getSelectedDemandAuthority();
//     this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
//     this.getSelectedConditionOfItem();
//     this.getSelectedTrade();
//     this.getSelectedItemCategory();
//     this.getSelectedManufacture();
//     this.getSelectedDemandStatus();
//     this.getSelectedTypeOfDemand();
//   }
//   intitializeForm() {
//     this.DemandForm = this.fb.group({
//       demandId: [0],
//       authorityId: [''],
//       partNo:[''],
//       doc:[''],
//       specDocument:[''],
//       specDoc:[''],
//       manufactureId:[],
//       itemCategoryId:[''],
//       tradeId:[],
//       demandStatusId:[''],
//       demandNo:[''],
//      // itemName:[''],
//       itemDetailId: [''],
//       denoId: [''],
//       fiscalYearId: [''],
//       itemTypeId:[''],
//       occasionOfDemandId:[''],
//       sparesCategoryId:[2],
//       demandAuthorityId:[''],
//       demandTypeId:[''],
//       demandDocId: [''],
//       conditionOfItemId:[''],
//       departmentNameId: [''],
//       demandCompleteStatus:[0],
//       demandQty:[''],
//       demandLetterNo:[''],
//       demandDate: [''],
//       letterOuterNo: [''],
//       refPrice:[''],
//       refPoNo:[''],
//       remarks: [''],
//       oldPrice: [''],
//       oldRefNo:[''],
//       manufactureAddress: [''],
//       status: [2],
//       menuPosition: [2],
//       isActive: [true]
//     })
//       //autocomplete
//       this.DemandForm.get('partNo').valueChanges
//       .subscribe(value => {
//           this.getSelectedTraineeByPno(value);
//       })
//   }

//     //autocomplete
//     onTraineeSelectionChanged(item) {
//       // console.log(item);
//        this.itemDetailId = item.value
//        this.DemandForm.get('itemDetailId').setValue(item.value);
//        this.DemandForm.get('partNo').setValue(item.text);

//        this.getItemNameById(this.itemDetailId);

//        this.itemDetailsService.find(this.itemDetailId).subscribe(res => {
//        })
//    }

//   onFileChanged(event) {
//     if (event.target.files.length > 0) {
//       const file = event.target.files[0];
//       console.log('jjjjjjj');
//      console.log(file);
//       this.DemandForm.patchValue({
//         doc: file,
//       });
//     }
//   }
//   onStatus(dropdown){
//     if(dropdown.isUserInput) {
//       this.status=dropdown.source.value;
//       console.log(this.status)
//     }
//   }
//   getSelectedDemandStatus() {
//     this.DemandService.getSelectedDemandStatus().subscribe(res => {
//       this.selectedDemandStaus = res;
//     });
//   }
//   getSelectedTypeOfDemand() {
//     this.DemandService.getSelectedTypeOfDemand().subscribe(res => {
//       this.selectedTypeOfDemandValue = res;
//     });
//   }

//   onTenderSpecChanged(event){
//     if (event.target.files.length > 0) {
//       const file = event.target.files[0];
//       console.log('tenderspecg');
//      console.log(file);
//       this.DemandForm.patchValue({
//         specDocument: file,
//       });
//     }
//   }
//   getSelectedTraineeByPno(pno){
//     this.DemandService.getSelectedPartNoByDepartment(pno).subscribe(response => {
//       this.options = response;
//         this.filteredOptions = response;
//     })
//   }
//   getSelectedTrade() {
//     this.DemandService.getSelectedTrade().subscribe(res => {
//       this.selectedTrade = res;
//     });
//   }
//   getSelectedItemCategory() {
//     this.DemandService.getSelectedItemCategory().subscribe(res => {
//       this.selectedItemCategory = res;
//     });
//   }
//   getSelectedManufacture() {
//     this.DemandService.getSelectedManufacture().subscribe(res => {
//       this.selectedManufacture = res;
//     });
//   }
//   getSelectedItemDetails(){
//     this.DemandService.getSelectedItemDetails().subscribe(res=>{
//       this.selectedItemDetails=res;
//     });
//   }
//   getSelectedAuthority(){
//     this.DemandService.getSelectedAuthority().subscribe(res=>{
//       this.selectedAuthority=res;
//     });
//   }
//   getSelectedDeno(){
//     this.DemandService.getSelectedDeno().subscribe(res=>{
//       this.selectedDeno=res;
//     });
//   }

//   getSelectedFiscalYear(){
//     this.DemandService.getSelectedFiscalYear().subscribe(res=>{
//       this.selectedFiscalYear=res;
//     });
//   }
//   getSelectedItemType(){
//     this.DemandService.getSelectedItemType().subscribe(res=>{
//       this.selectedItemType=res;
//     });
//   }

//   getSelectedOccasionOfDemand(){
//     this.DemandService.getSelectedOccasionOfDemand().subscribe(res=>{
//       this.selectedOccasionOfDemand=res;
//     });
//   }
//   getSelectedDemandAuthority(){
//     this.DemandService.getSelectedDemandAuthority().subscribe(res=>{
//       this.selectedDemandAuthority=res;
//     });
//   }
//   GetDepartmentNameById(baseNameId){
//     this.DemandService.getSelectedSchoolName(baseNameId).subscribe(res=>{
//       this.selectedDepartmentName=res
//       console.log(res)
//     });
//   }

//   getSelectedConditionOfItem(){
//     this.DemandService.getSelectedConditionOfItem().subscribe(res=>{
//       this.selectedConditionOfItem=res;
//     });
//   }
//   getPartNoByDepartmentNameId(id:number){
//     this.itemDetailsService.getPartNoByDepartmentNameId(id).subscribe(res=>{
//       this.selectedPartNo=res;
//       console.log(this.selectedPartNo);
//     });
//   }
//   getItemNameById(id:number){
//     console.log(id);
//     this.itemDetailsService.getItemNameById(id).subscribe(res=>{
//        this.selectedItemName=res;
//        console.log(this.selectedItemName);
//        this.itemValue = this.selectedItemName[0].value
//       console.log(this.itemValue);
//     });
//   }
//   onPartNoSelectionChange(dropdown){
//     if(dropdown.isUserInput) {
//       console.log(dropdown.source.value);
//       this.getItemNameById(dropdown.source.value);
//       //this.getPartNoByDepartmentNameId(dropdown.source.value);
//     }
//   }
//   onDepartmentNameSelectionChange() {
//     this.isShown = true;
//     var departmentId = this.DemandForm.get('departmentNameId').value;
//     this.getDemandsList(departmentId);
//   }
//   getDemandsList(departmentId) {
//     this.isLoading = true;
//     this.DemandService.getDemandListByDepartmentNameId(this.paging.pageIndex, this.paging.pageSize, this.searchText, this.masterData.sparescategory.spares, departmentId).subscribe(response => {

//       this.dataSource.data = response.items;
//       console.log("dddddd");
//       console.log(this.dataSource.data)
//       this.paging.length = response.totalItemsCount
//       this.isLoading = false;
//     })
//   }

//   applyFilter(searchText: any) {
//     this.searchText = searchText;
//     var departmentId = this.DemandForm.get('departmentNameId').value;
//     console.log(departmentId);
//     this.getDemandsList(departmentId);
//   }
//   reloadCurrentRoute() {
//     let currentUrl = this.router.url;
//     this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
//       this.router.navigate([currentUrl]);
//     });
//   }
//   onSubmit() {
//     const id = this.DemandForm.get('demandId').value;
//     this.DemandForm.get('demandDate').setValue((new Date(this.DemandForm.get('demandDate').value)).toUTCString()) ;
//     console.log(this.DemandForm.value)

//     const formData = new FormData();
//     for (const key of Object.keys(this.DemandForm.value)) {
//       const value = this.DemandForm.value[key];
//       formData.append(key, value);
//     }

//     if (id) {
//       this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {

//         if (result) {
//           this.DemandService.update(+id,formData).subscribe(response => {
//             this.router.navigateByUrl('/tools-management/add-demand');
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
//       this.DemandService.submit(formData).subscribe(response => {
//         //this.router.navigateByUrl('/tools-management/demand-list');
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
//     const id = row.demandId;
//     this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
//       console.log(result);
//       if (result) {
//         this.DemandService.delete(id).subscribe(() => {
//           //this.getDemands();
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

import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { IssueRegisterService } from "../../service/IssueRegister.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { DepartmentNameService } from "src/app/basic-setup/service/DepartmentName.service";
import { ItemStor } from "src/app/spares-management/models/ItemStor";
import { ItemDetailService } from "src/app/spares-management/service/itemDetail.service";
import { style } from "@angular/animations";
import { MasterData } from "src/assets/data/master-data";
import { AuthService } from "src/app/core/service/auth.service";
import { Role } from "src/app/core/models/role";

@Component({
  selector: "app-new-toolsissueregister",
  templateUrl: "./new-toolsissueregister.component.html",
  styleUrls: ["./new-toolsissueregister.component.sass"],
})
export class NewToolsIssueRegisterComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  IssueRegisterForm: FormGroup;
  validationErrors: string[] = [];
  selectedItemDetails: SelectedModel[];
  selectedIssueStatuses: SelectedModel[];
  selectedDepartmentNames: SelectedModel[];
  selectedSparesCategory: SelectedModel[];
  selectedItemNameValue: SelectedModel[];
  getitemdetailid: number;
  getitemname: string;
  selectedItemStoreList: ItemStor[];
  isShown: boolean = false;
  isDynamicFormShown: boolean = false;
  checked: boolean = false;
  message: string;
  titleColor: "#FF0000";
  itemName: string;
  trainingCrewId: number;
  itemDetailId: number;
  masterData = MasterData;
  userRole = Role;
  IsButtonShow:boolean = true;

  options = [];
  filteredOptions;

  traineeId: any;
  role: any;
  branchId: any;

  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private itemDetailService: ItemDetailService,
    private departmentNameService: DepartmentNameService,
    private confirmService: ConfirmService,
    private IssueRegisterService: IssueRegisterService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("issueRegisterId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (id) {
      this.pageTitle = "Edit Tools Issue Register";
      this.destination = "Edit";
      this.btnText = "Update";
      this.IssueRegisterService.find(+id).subscribe((res) => {
        this.IssueRegisterForm.patchValue({
          issueRegisterId: res.issueRegisterId,
          itemDetailId: res.itemDetailId,
          issueStatusId: res.issueStatusId,
          trainingCrewId: res.trainingCrewId,
          totalReceivedQty: res.totalReceivedQty,
          issueQty: res.issueQty,
          issueDate: res.issueDate,
          issuedTo: res.issuedTo,
          reason: res.reason,
          isRefundable: res.isRefundable,
          availableQtyBeforeIssue: res.availableQtyBeforeIssue,
          availableQtyAfterIssue: res.issueDate,
          receivedPerson: res.receivedPerson,
          remarks: res.remarks,
        });
      });
    } else {
      this.pageTitle = "Create Tools Issue Register";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.IssueRegisterForm.get("departmentNameId").setValue(this.branchId);
      this.onDepartmentSelectionChange();
    }
    this.getselectedItemDetails();
    this.getselectedIssueStatuses();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedSparesCategory();
    this.getselectedItemDetails();
  }
  intitializeForm() {
    this.IssueRegisterForm = this.fb.group({
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
      ItemStoreList: this.fb.array([this.createIssueRegisterData()]),
    });
    //autocomplete for pno
    this.IssueRegisterForm.get("pno").valueChanges.subscribe((value) => {
      this.getSelectedTraineeCrewByPno(value);
    });
    //autocomplete for PartNo
    this.IssueRegisterForm.get("partNo").valueChanges.subscribe((value) => {
      this.getSelectedItemDetailByPartNo(value);
    });
  }

  getControlLabel(index: number, type: string) {
    return (this.IssueRegisterForm.get("ItemStoreList") as FormArray)
      .at(index)
      .get(type).value;
  }

  private createIssueRegisterData() {
    return this.fb.group({
      deno: [""],
      itemDetail: [""],
      partNo: [""],
      itemSerNo: [""],
      issuedQty: [""],
      issueQty: [""],
      issueStatusId: [""],
      status: [""],
      itemDetailId: [""],
      itemStorId: [""],
      departmentNameId: [""],
      sparesCategoryId: [""],
      isRefundable: [false],
      isChecked: [false],
      totalReceivedQty: [""],
      availableQty: [""],
      returnQty: [""],
      itemReceivedDate: [],
      warrantyEndDate: [],
      lastMaintenanceDate:[],
      lastCalibrationDate:[],
      acctStore: [""],
    });
  }

  onCheckboxChange(event, data) {
    if (data.value.availableQty < data.value.issueQty) {
      this.message = "Available QTY not Smaller then Issue QTY";
      this.confirmService
        .confirm(this.message, "Are you sure you want to do this", "OK", "red")
        .subscribe((result) => {
          if (result) {
            console.log(result);
            this.snackBar.open("OK ", "", {
              duration: 2000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-success",
            });
          }
        });
    }
    this.isDynamicFormShown = true;
  }

  clearList() {
    const control = <FormArray>this.IssueRegisterForm.controls["ItemStoreList"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  getItemStoreListonClick() {
    const control = <FormArray>this.IssueRegisterForm.controls["ItemStoreList"];
    for (let i = 0; i < this.selectedItemStoreList.length; i++) {
      control.push(this.createIssueRegisterData());
    }
    console.log("12");

    // for(let i=0;i<=this.selectedItemStoreList.length;i++){
    //   console.log(this.selectedItemStoreList['itemDetail'].value)
    // }
    // this.selectedItemStoreList=this.selectedItemStoreList.filter(x=>x.status ==true)
    this.IssueRegisterForm.patchValue({
      ItemStoreList: this.selectedItemStoreList,
    });
  }
  //autocomplete for pno
  onTraineeSelectionChanged(item) {
    console.log(item.value);
    this.trainingCrewId = item.value;
    this.IssueRegisterForm.get("trainingCrewId").setValue(item.value);
    this.IssueRegisterForm.get("pno").setValue(item.text);
  }
  //autocomplete for PartNo
  onPartNoSelectionChanged(item) {
    console.log(item.value);
    this.itemDetailId = item.value;
    this.IssueRegisterForm.get("itemDetailId").setValue(item.value);
    this.IssueRegisterForm.get("partNo").setValue(item.text);
    this.ongetItemNameByItemDetailId(this.itemDetailId);

    var departmentNameId = this.IssueRegisterForm.value["departmentNameId"];
    var sparesCategoryId = 2;
    this.IssueRegisterService.getSelectedItemStorebyDepartmentNameIdAndSparesCategoryIdAndItemDetailId(
      departmentNameId,
      sparesCategoryId,
      this.itemDetailId
    ).subscribe((res) => {
      this.selectedItemStoreList = res;
      console.log(this.selectedItemStoreList);
      this.clearList();
      this.getItemStoreListonClick();

      this.IssueRegisterService.getselectedPartNoByDepartmentNameIdAndSpareCategoryIdFromItemStore(
        departmentNameId,
        sparesCategoryId
      ).subscribe((res) => {
        this.selectedItemDetails = res;
      });
    });
    this.isShown = true;
  }
  //autocomplete for pno
  getSelectedTraineeCrewByPno(pno) {
    this.IssueRegisterService.getSelectedPno(pno).subscribe((response) => {
      this.options = response;
      this.filteredOptions = response;
    });
  }
  //autocomplete for PartNo
  getSelectedItemDetailByPartNo(partNo) {
    var departmentNameId = this.IssueRegisterForm.value["departmentNameId"];
    this.IssueRegisterService.getSelectedPartNoByNameByDepartmentId(partNo,departmentNameId).subscribe(
      (response) => {
        this.options = response;
        this.filteredOptions = response;
      }
    );
  }
  ongetItemNameByItemDetailId(itemDetailId) {
    this.IssueRegisterService.getItemNameByItemDetailId(itemDetailId).subscribe(
      (res) => {
        this.selectedItemNameValue = res;
        (this.getitemdetailid = this.selectedItemNameValue[0].value),
          (this.getitemname = this.selectedItemNameValue[0].text);
      }
    );
  }

  OnTextCheck(value, index, type) {
    console.log(value);
    var getqty = (this.IssueRegisterForm.get("ItemStoreList") as FormArray)
      .at(index)
      .get(type).value;
    var calculateData = getqty - value;
    if(calculateData >=0){
      (this.IssueRegisterForm.get("ItemStoreList") as FormArray)
      .at(index)
      .get("returnQty")
      .setValue(calculateData);
    console.log(calculateData);
    }
    else{
      (this.IssueRegisterForm.get("ItemStoreList") as FormArray)
      .at(index)
      .get("returnQty")
      .setValue("Must be Non Negative Value");
      this.IsButtonShow =false
    }
  }

  onDepartmentSelectionChange() {
    var departmentNameId = this.IssueRegisterForm.value["departmentNameId"];
    var sparesCategoryId = 2;
    this.IssueRegisterService.getselectedPartNoByDepartmentNameIdAndSpareCategoryIdFromItemStore(
      departmentNameId,
      sparesCategoryId
    ).subscribe((res) => {
      this.selectedItemDetails = res;
    });
  }

  onPartNoSelectionChange(dropdown) {
    this.itemName = "";
    var departmentNameId = this.IssueRegisterForm.value["departmentNameId"];
    var sparesCategoryId = 2;
    this.IssueRegisterService.getselectedItemNameByDepartmentNameIdAndSpareCategoryIdItemDetailIdFromItemStore(
      departmentNameId,
      sparesCategoryId,
      dropdown
    ).subscribe((res) => {
      console.log(departmentNameId + "--" + sparesCategoryId + "--" + dropdown);
      //    console.log(res);
      for (let i = 0; i <= res.length; i++) {
        console.log("dddd");
        console.log(res[i].text);
        this.itemName = res[i].text;
        //  console.log(this.itemName);
      }
    });
    this.IssueRegisterService.getSelectedItemStorebyDepartmentNameIdAndSparesCategoryIdAndItemDetailId(
      departmentNameId,
      sparesCategoryId,
      dropdown
    ).subscribe((res) => {
      this.selectedItemStoreList = res;

      for (let i = 0; i <= this.selectedItemStoreList.length; i++) {
        console.log(this.selectedItemStoreList[i]);
        //  console.log(this.selectedItemStoreList[i].);
      }
      // console.log(this.selectedItemStoreList.);
      this.clearList();
      this.getItemStoreListonClick();
    });
    this.isShown = true;
  }

  // getselectedItemDetails(){
  //   this.itemDetailService.getselectedItemDetail().subscribe(res=>{
  //     this.selectedDepartmentNames=res
  //   });
  // }

  // getSelectedDepartment() {
  //   this.departmentNameService.getselectedDepertments().subscribe(res => {
  //     this.selectedDepartmentNames = res
  //     // console.log(this.selectedDepartmentNames);
  //   });
  // }
  GetDepartmentNameById(baseNameId) {
    this.departmentNameService
      .getSelectedSchoolName(baseNameId)
      .subscribe((res) => {
        this.selectedDepartmentNames = res;
        console.log(res);
      });
  }
  getselectedSparesCategory() {
    this.IssueRegisterService.getselectedSparesCategory().subscribe((res) => {
      this.selectedSparesCategory = res;
      //console.log(this.selectedSparesCategory);
    });
  }
  getselectedItemDetails() {
    this.IssueRegisterService.getselectedItemDetails().subscribe((res) => {
      this.selectedItemDetails = res;
    });
  }
  getselectedIssueStatuses() {
    this.IssueRegisterService.getselectedIssueStatuses().subscribe((res) => {
      this.selectedIssueStatuses = res;
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.IssueRegisterForm.get("issueRegisterId").value;

    this.IssueRegisterForm.value.ItemStoreList =
      this.IssueRegisterForm.value.ItemStoreList.filter(
        (x) => x.isChecked == true
      );
    // if(this.IssueRegisterForm.value.ItemStoreList.where(x=>x.availableQty === x.issuedQty)){
    //   console.log("valid");
    // }
    //console.log(this.IssueRegisterForm.value.ItemStoreList.filter(x=>x.availableQty === ));
    // for (var char of this.IssueRegisterForm.value.ItemStoreList) {
    //   if(char.availableQty == char.issuedQty){
    //     console.log("saved");
    //   }
    // }

    console.log(this.IssueRegisterForm.value);
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.IssueRegisterService.update(
              +id,
              this.IssueRegisterForm.value
            ).subscribe(
              (response) => {
                this.router.navigateByUrl(
                  "/issue-management/add-issueregister"
                );
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
      this.IssueRegisterService.submit(this.IssueRegisterForm.value).subscribe(
        (response) => {
          //this.router.navigateByUrl('/issue-management/issueregister-list');
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
    const id = row.issueRegisterId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        console.log(result);
        if (result) {
          this.IssueRegisterService.delete(id).subscribe(() => {
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

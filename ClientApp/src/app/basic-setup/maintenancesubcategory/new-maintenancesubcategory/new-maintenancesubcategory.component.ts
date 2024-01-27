import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { MaintenanceSubCategoryService } from 'src/app/basic-setup/service/maintenanceSubCategory.service';
import { MaintenanceCategoryService } from "../../service/MaintenanceCategory.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { MaintenanceSubCategory } from "../../models/maintenanceSubCategory";
import { MasterData } from "src/assets/data/master-data";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";

@Component({
  selector: "app-new-maintenancesubcategory",
  templateUrl: "./new-maintenancesubcategory.component.html",
  styleUrls: ["./new-maintenancesubcategory.component.sass"],
})
export class NewMaintenanceSubCategoryComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  MaintenanceSubCategoryForm: FormGroup;
  validationErrors: string[] = [];
  selectedMaintenanceCategory: SelectedModel[];
  selectedDepartmentName: SelectedModel[];
  selectedMaintenanceCategoryByDepartment: SelectedModel[];
  selectedMaintenanceType: SelectedModel[];
  selectedMaintenanceSubCategoryByDepartmentAndMaintenenceCategory: MaintenanceSubCategory[];
  isShown: boolean = false;
  masterData = MasterData;

  userRole = Role;

  traineeId: any;
  role: any;
  branchId: any;

  displayedColumns: string[] = [
    "ser",
    "maintenanceCategory",
    "subCategoryName",
    "allowedExtension",
    "departmentName",
    "totalDaysCount",
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
    private MaintenanceSubCategoryService: MaintenanceSubCategoryService,
    private MaintenanceCategoryService: MaintenanceCategoryService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("maintenanceSubCategoryId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (id) {
      this.pageTitle = "Edit Maintenance Sub Category";
      this.destination = "Edit";
      this.btnText = "Update";
      this.MaintenanceSubCategoryService.find(+id).subscribe((res) => {
        this.MaintenanceSubCategoryForm.patchValue({
          maintenanceSubCategoryId: res.maintenanceSubCategoryId,
          maintenanceCategoryId: res.maintenanceCategoryId,
          maintenanceTypeId: res.maintenanceTypeId,
          subCategoryName: res.subCategoryName,
          totalDaysCount: res.totalDaysCount,
          allowedExtension: res.allowedExtension,
          departmentNameId: res.departmentNameId,
          remarks: res.remarks,
        });
        this.onDepartmentSelectionChange();
        this.onMaintenanceTypeSelectionChange();
      });
    } else {
      this.pageTitle = "Create Maintenance Sub Category";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.MaintenanceSubCategoryForm.get("departmentNameId").setValue(
        this.branchId
      );
      this.onDepartmentSelectionChange();
    }
    this.getselectedMaintenanceCategory();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.MaintenanceSubCategoryForm = this.fb.group({
      maintenanceSubCategoryId: [0],
      maintenanceCategoryId: [],
      maintenanceTypeId: [],
      totalDaysCount: [],
      subCategoryName: [""],
      allowedExtension: [""],
      departmentNameId: [],
      remarks: [""],
      isActive: [true],
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  onDepartmentSelectionChange() {
    var departmentNameId = this.MaintenanceSubCategoryForm.value["departmentNameId"];    

    this.MaintenanceCategoryService.getMaintenanceTypeByDepartmentNameId(
      departmentNameId
    ).subscribe((res) => {
      //this.onDepartmentNameSelectionChangeGetAirCraftName(departmentNameId)
      this.selectedMaintenanceType = res;
      console.log(this.selectedMaintenanceType);
    });
  }
  onMaintenanceTypeSelectionChange() {
    var departmentNameId = this.MaintenanceSubCategoryForm.value["departmentNameId"];
    var maintenanceTypeId = this.MaintenanceSubCategoryForm.value["maintenanceTypeId"];

    this.MaintenanceSubCategoryService.getMaintenanceCategoryByDepartmentAndType(departmentNameId,maintenanceTypeId).subscribe((res) => {
      this.selectedMaintenanceCategoryByDepartment = res;
      console.log(this.selectedMaintenanceCategoryByDepartment);
    });
  }
  onMaintenanceCategorySelectionChange(dropdown) {
    this.isShown = true;
    console.log(dropdown);
    var departmentNameId =
      this.MaintenanceSubCategoryForm.value["departmentNameId"];
    this.MaintenanceSubCategoryService.getSelectedMaintenanceSubCategory(
      departmentNameId,
      dropdown
    ).subscribe((res) => {
      this.selectedMaintenanceSubCategoryByDepartmentAndMaintenenceCategory =
        res;
      console.log(
        this.selectedMaintenanceSubCategoryByDepartmentAndMaintenenceCategory
      );
    });
  }
  getselectedMaintenanceCategory() {
    this.MaintenanceSubCategoryService.getselectedMaintenanceCategory().subscribe(
      (res) => {
        this.selectedMaintenanceCategory = res;
        // console.log(this.selectedMaintenanceCategory);
      }
    );
  }
  // getselectedDepartmentName(){
  //   this.MaintenanceSubCategoryService.getselectedDepartmentName().subscribe(res=>{
  //     this.selectedDepartmentName=res
  //    // console.log(this.selectedDepartmentName);
  //   });
  // }
  GetDepartmentNameById(baseNameId) {
    this.MaintenanceSubCategoryService.getSelectedSchoolName(
      baseNameId
    ).subscribe((res) => {
      this.selectedDepartmentName = res;
      console.log(res);
    });
  }
  onSubmit() {
    const id = this.MaintenanceSubCategoryForm.get(
      "maintenanceSubCategoryId"
    ).value;
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.MaintenanceSubCategoryService.update(
              +id,
              this.MaintenanceSubCategoryForm.value
            ).subscribe(
              (response) => {
                this.router.navigateByUrl(
                  "/basic-setup/add-maintenancesubcategory"
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
      this.MaintenanceSubCategoryService.submit(
        this.MaintenanceSubCategoryForm.value
      ).subscribe(
        (response) => {
          //this.router.navigateByUrl('/basic-setup/maintenancesubcategory-list');
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
    const id = row.maintenanceSubCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MaintenanceSubCategoryService.delete(id).subscribe(() => {
          this.reloadCurrentRoute();
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

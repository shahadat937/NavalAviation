import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { DailyAirworthinessFromService } from "../../service/DailyAirworthinessFrom.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { DailyAirworthinessFrom } from "../../models/DailyAirworthinessFrom";
import { MasterData } from "src/assets/data/master-data";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";

@Component({
  selector: "app-new-new-dailyairworthinesrecordsfrom",
  templateUrl: "./new-new-dailyairworthinesrecordsfrom.component.html",
  styleUrls: ["./new-new-dailyairworthinesrecordsfrom.component.sass"],
})
export class NewDailyAirworthinessRecordFromComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  sparesCategoryId: number;
  DailyAirworthinessFromForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  FromCategory: SelectedModel[];
  AircraftNamevalue: SelectedModel[];
  public files: any[];
  dailyAirworthinessFromList: any[];
  groupArrays: { departmentName: string; datas: any }[];
  isShown: boolean = false;
  masterData = MasterData;

  userRole = Role;

  traineeId: any;
  role: any;
  branchId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };

  displayedColumns: string[] = ["ser", "fromCategory", "name", "actions"];
  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private confirmService: ConfirmService,
    private DailyAirworthinessFromService: DailyAirworthinessFromService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.files = [];
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("dailyAirworthinessFromId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (id) {
      this.pageTitle = "Edit Daily Airworthiness From ";
      this.destination = "Edit";
      this.btnText = "Update";
      this.DailyAirworthinessFromService.find(+id).subscribe((res) => {
        this.DailyAirworthinessFromForm.patchValue({
          dailyAirworthinessFromId: res.dailyAirworthinessFromId,
          departmentNameId: res.departmentNameId,
          airCraftNameId: res.airCraftNameId,
          docType: res.docType,
          uploadDate: res.uploadDate,
          dailyAirworthinessFromCategoryId:
            res.dailyAirworthinessFromCategoryId,
          name: res.name,
          doc: res.doc,
          //status: res.status,
          //menuPosition: res.menuPosition
        });
      });
    } else {
      this.pageTitle = "Create Daily Airworthiness From ";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.DailyAirworthinessFromForm.get("departmentNameId").setValue(
        this.branchId
      );
      this.onDailyAirworthinessFromListByDepartmentNameSelectionChange();
      this.getAircraftName();
    }
    if (this.role == this.userRole.CO) {
      this.onDailyAirworthinessFromListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getDailyAirworthinessFromCategory();
  }
  intitializeForm() {
    this.DailyAirworthinessFromForm = this.fb.group({
      dailyAirworthinessFromId: [0],
      departmentNameId: [],
      airCraftNameId: [""],
      dailyAirworthinessFromCategoryId: [],
      docType: [1],
      uploadDate: [""],
      name: [""],
      doc: [""],
      document: [""],
      //status: [],
      //menuPosition: [],
      isActive: [true],
    });
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      this.DailyAirworthinessFromForm.patchValue({
        document: file,
      });
    }
  }
  onDailyAirworthinessFromListByDepartmentNameSelectionChange() {
    this.isShown = true;
    if (this.role == this.userRole.CO) {
      var departmentNameId = 0;
    } else {
      departmentNameId =
        this.DailyAirworthinessFromForm.value["departmentNameId"];
    }

    this.DailyAirworthinessFromService.getDailyAirworthinessFromListByDepartmentName(
      departmentNameId,
      1
    ).subscribe((res) => {
      this.getAircraftName();
      this.dailyAirworthinessFromList = res;
      console.log(this.dailyAirworthinessFromList);
      // this gives an object with dates as keys
      const groups = this.dailyAirworthinessFromList.reduce((groups, datas) => {
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
  GetDepartmentNameById(baseNameId) {
    this.DailyAirworthinessFromService.getSelectedSchoolName(
      baseNameId
    ).subscribe((res) => {
      this.departmentName = res;
      console.log(res);
    });
  }
  getDailyAirworthinessFromCategory() {
    this.DailyAirworthinessFromService.getDailyAirworthinessFromCategory().subscribe(
      (res) => {
        this.FromCategory = res;
        console.log(res);
      }
    );
  }
  getAircraftName() {
    var departmentNameId =
      this.DailyAirworthinessFromForm.value["departmentNameId"];
    this.DailyAirworthinessFromService.getAircraftName(
      departmentNameId
    ).subscribe((res) => {
      this.AircraftNamevalue = res;
      console.log(res);
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.DailyAirworthinessFromForm.get(
      "dailyAirworthinessFromId"
    ).value;
    this.DailyAirworthinessFromForm.get("uploadDate").setValue(
      new Date(
        this.DailyAirworthinessFromForm.get("uploadDate").value
      ).toUTCString()
    );
    const formData = new FormData();
    for (const key of Object.keys(this.DailyAirworthinessFromForm.value)) {
      const value = this.DailyAirworthinessFromForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          console.log(result);
          if (result) {
            this.DailyAirworthinessFromService.update(+id, formData).subscribe(
              (response) => {
                this.router.navigateByUrl(
                  "/record-room/add-dailyairworthinessfrom"
                );
                // this.router.navigateByUrl('/record-room/add-dailyairworthinessfrom');
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
      this.DailyAirworthinessFromService.submit(formData).subscribe(
        (response) => {
          console.log(this.DailyAirworthinessFromForm);
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
    const id = row.dailyAirworthinessFromId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        console.log(result);
        if (result) {
          this.DailyAirworthinessFromService.delete(id).subscribe(() => {
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

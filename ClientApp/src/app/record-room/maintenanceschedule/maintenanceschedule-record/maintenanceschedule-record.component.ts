import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MaintenanceScheduleService } from '../../service/MaintenanceSchedule.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MaintenanceSchedule } from '../../models/MaintenanceSchedule';
import { MasterData } from 'src/assets/data/master-data';
import { MaintenanceSubCategoryService } from 'src/app/basic-setup/service/maintenanceSubCategory.service';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { count } from 'rxjs';

@Component({
  selector: 'app-maintenanceschedule-record',
  templateUrl: './maintenanceschedule-record.component.html',
  styleUrls: ['./maintenanceschedule-record.component.sass']
})
export class MaintenanceScheduleRecordComponent implements OnInit {
  pageTitle: string;
  fileUrl = "/content/";
  destination: string;
  btnText: string;
  departmentNameId: number;
  maintenanceCategoryId: number;
  maintenanceSubCategoryId: number;
  MaintenanceScheduleForm: FormGroup;
  validationErrors: string[] = [];
  selectedStatus: SelectedModel[];
  selectedDepartmentNames: SelectedModel[];
  selectedAirCraftName: SelectedModel[];
  selectedType: SelectedModel[];
  selectedCategory: SelectedModel[];
  selectedSubCategory: SelectedModel[];
  selectedExtensionValue: SelectedModel[];
  selectedMaintenanceType: SelectedModel[];
  selectedMaintenanceCategoryByDepartment: SelectedModel[];
  selectedMaintenanceTypes1: any;
  allowedExtension: string;
  selectedMaintenancePlanning: SelectedModel[];
  selectedNestInsDateValue: SelectedModel[];


  deptId:any;
  airCraftId:any;
  mntTypeId:any;
  mntCategoryId:any;
  mntSubCategoryId:any;

  getsubcategoryid: number;
  getmaintenanceplanningid: number;
  getextensionname: string;
  getnextdate: Date;
  maintenanceScheduleRecordList: any[];
  maintenanceScheduleListByRange: any[];
  groupArrays: { departmentName: string; datas: any }[];
  isShown: boolean = false;
  isCoShown: boolean = true;
  masterData = MasterData;
  lastInspDate: any;
  nextDate = new Date();

  extentionDays:any;
  getCalculate: any = {};

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  

  displayedColumns: string[] = ['ser', 'airCraftName', 'categoryType', 'category', 'maintenanceDocument', 'actions'];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  constructor(private snackBar: MatSnackBar, private authService: AuthService, private MaintenanceSubCategoryService: MaintenanceSubCategoryService, private confirmService: ConfirmService, private MaintenanceScheduleService: MaintenanceScheduleService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('maintenanceScheduleId');
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
 
    
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin && this.role != this.userRole.CO){
      this.MaintenanceScheduleForm.get('departmentNameId').setValue(this.branchId);
      this.onDepartmentNameSelectionChangeGetAirCraftName();
    }
    if(this.role == this.userRole.CO){
      this.isCoShown = false;
    }
    // this.getselectedplanningStatus();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    // this.getselectedMaintenanceTypes();
    // this.getselectedSubCategory();
    this.getMaintenanceRecords();
  }
  intitializeForm() {
    this.MaintenanceScheduleForm = this.fb.group({
      departmentNameId: [],
      airCraftNameId: [],
      maintenanceTypeId: [],
      maintenanceCategoryId: [],
      maintenanceSubCategoryId:[]
    })
  }

  GetDepartmentNameById(baseNameId){    
    this.MaintenanceScheduleService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentNames=res
      console.log(res)
    }); 
    this.getMaintenanceRecords();
  }
  onDepartmentNameSelectionChangeGetAirCraftName() {
    var departmentNameId = this.MaintenanceScheduleForm.value['departmentNameId'];
    this.MaintenanceScheduleService.getAirCraftNameByDepartmentNameId(departmentNameId).subscribe(res => {
      this.selectedAirCraftName = res
    });

    this.MaintenanceScheduleService.getMaintenanceTypeByDepartmentNameId(departmentNameId).subscribe((res) => {
      //this.onDepartmentNameSelectionChangeGetAirCraftName(departmentNameId)
      this.selectedMaintenanceType = res;
      console.log(this.selectedMaintenanceType);
    });
    this.getMaintenanceRecords();
  }

  onMaintenanceTypeSelectionChange() {
    var departmentNameId = this.MaintenanceScheduleForm.value["departmentNameId"];
    var maintenanceTypeId = this.MaintenanceScheduleForm.value["maintenanceTypeId"];

    this.MaintenanceSubCategoryService.getMaintenanceCategoryByDepartmentAndType(departmentNameId,maintenanceTypeId).subscribe((res) => {
      this.selectedMaintenanceCategoryByDepartment = res;
      console.log(this.selectedMaintenanceCategoryByDepartment);
    });
    this.getMaintenanceRecords();
  }

  onMaintenanceCategoryChangeGetSubCategory(){
    var departmentNameId = this.MaintenanceScheduleForm.value["departmentNameId"];
    var maintenanceCategoryId = this.MaintenanceScheduleForm.value["maintenanceCategoryId"];

    this.MaintenanceSubCategoryService.getMaintenanceSubCategoryByDepartmentAndCategory(departmentNameId,maintenanceCategoryId).subscribe((res) => {
      this.selectedSubCategory = res;
      console.log(this.selectedSubCategory);
    });
    this.getMaintenanceRecords();
  }


  onSubCategoryChangeGetInspDate(){
    // this.deptId = this.MaintenanceScheduleForm.value["departmentNameId"];
    // this.airCraftId = this.MaintenanceScheduleForm.value["airCraftNameId"];
    // this.mntTypeId = this.MaintenanceScheduleForm.value["maintenanceTypeId"];
    // this.mntCategoryId = this.MaintenanceScheduleForm.value["maintenanceCategoryId"];
    // this.mntSubCategoryId = this.MaintenanceScheduleForm.value["maintenanceSubCategoryId"];

    this.getMaintenanceRecords();

    
    // this.MaintenanceScheduleService.getMaintenancePlanningByParams(this.deptId,this.airCraftId,this.mntTypeId,this.mntCategoryId,this.mntSubCategoryId).subscribe((res) => {
      
    //   console.log(res);
    //   this.lastInspDate = res[0].lastInspDate;
    //   var maintanencePlanningId = res[0].maintenancePlanningId;      
    //   this.MaintenanceScheduleForm.get('maintenancePlanningId').setValue(maintanencePlanningId);

    //   this.MaintenanceSubCategoryService.find(this.mntSubCategoryId).subscribe((res) =>{
    //     console.log(res);
    //     this.extentionDays = res.allowedExtension;
    //     this.MaintenanceScheduleService.getMaintenancePlanningListTableByDateRange(maintanencePlanningId,res.totalDaysCount).subscribe((res) =>{
    //       console.log(res);
    //       this.maintenanceScheduleListByRange=res;
    //     });

    //   });

      
    // });
    

  }

  getMaintenanceRecords(){
    var findArr = this.MaintenanceScheduleForm.value;
    console.log(findArr);

    
    this.MaintenanceScheduleService.maintenanceScheduleRecordListByParams(findArr.departmentNameId == null ? 0 : findArr.departmentNameId,findArr.airCraftNameId == null ? 0 : findArr.airCraftNameId,findArr.maintenanceTypeId == null ? 0 : findArr.maintenanceTypeId,findArr.maintenanceCategoryId== null ? 0 : findArr.maintenanceCategoryId,findArr.maintenanceSubCategoryId== null ? 0 : findArr.maintenanceSubCategoryId).subscribe(res=>{
      this.maintenanceScheduleRecordList=res;
      console.log(res);
    console.log("444444444");
    console.log(this.maintenanceScheduleRecordList);
      // this gives an object with dates as keys
      const groups = this.maintenanceScheduleRecordList.reduce((groups, datas) => {
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

  

//   onDepartmentNameAndTypeSelectionChangeGetCategory(maintenanceTypeId) {
//     this.MaintenanceScheduleService.getCategoryByDepartmentNameIdAndMaintenanceTypeId(maintenanceTypeId).subscribe(res => {
//       this.selectedCategory = res
//     });
//   }
//   getselectedSubCategory() {
    
//     this.MaintenanceScheduleService.getselectedMaintenancePlanning().subscribe(res => {
//       this.selectedSubCategory = res;
      
//     });
//   }
//   onSubCategorySelectionChangeGetExtension(maintenanceSubCategoryId) {
//     this.MaintenanceScheduleService.getAllowedExtensionBySubCategoryId(maintenanceSubCategoryId).subscribe(res => {
//       this.selectedExtensionValue = res
//       this.getsubcategoryid = this.selectedExtensionValue[0].value,
//         this.getextensionname = this.selectedExtensionValue[0].text
        
//     });
//   }
//   onLastInsDateelectionChangeGetNestInspDate(maintenancePlanningId) {
    
//     this.MaintenanceScheduleService.getAllowedNestInspDateByMaintenancePlanningId(maintenancePlanningId).subscribe(res => {
//       this.selectedNestInsDateValue = res
//       this.getmaintenanceplanningid = this.selectedNestInsDateValue[0].value,
//       this.getnextdate = this.selectedNestInsDateValue[0].text


//     });
//   }
//   onMaintenanceScheduleListSelectionChange(dropdown) {
//     if (dropdown.isUserInput) {
//       var departmentNameId = this.MaintenanceScheduleForm.value['departmentNameId'];
//       this.MaintenanceScheduleService.maintenanceScheduleListByDepartmentAndAirCraftName(dropdown.source.value, departmentNameId).subscribe(res => {
//         this.maintenanceScheduleList = res;
//       });

//     }
//   }
//   getselectedplanningStatus() {
//     this.MaintenanceScheduleService.getselectedplanningStatus().subscribe(res => {
//       this.selectedStatus = res
//     });
//   }


//   reloadCurrentRoute() {
//     let currentUrl = this.router.url;
//     this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
//       this.router.navigate([currentUrl]);
//     });
//   }
//   onSubmit() {
//     const id = this.MaintenanceScheduleForm.get('maintenanceScheduleId').value;
//     this.MaintenanceScheduleForm.get('startInspDate').setValue((new Date(this.MaintenanceScheduleForm.get('startInspDate').value)).toUTCString());
//     this.MaintenanceScheduleForm.get('endInspDate').setValue((new Date(this.MaintenanceScheduleForm.get('endInspDate').value)).toUTCString());
//     console.log(this.MaintenanceScheduleForm.value)
//     const formData = new FormData();
//     for (const key of Object.keys(this.MaintenanceScheduleForm.value)) {
//       const value = this.MaintenanceScheduleForm.value[key];
//       formData.append(key, value);
//     }


//     if (id) {
//       this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {

//         if (result) {
//           this.MaintenanceScheduleService.update(+id, formData).subscribe(response => {
//             this.router.navigateByUrl('/record-room/maintenanceschedule-list');
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
//     }
//     else {
//       this.MaintenanceScheduleService.submit(formData).subscribe(response => {
//         this.router.navigateByUrl('/record-room/maintenanceschedule-list');
//         // this.reloadCurrentRoute();
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
//     const id = row.maintenanceScheduleId;
//     this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
//       console.log(result);
//       if (result) {
//         this.MaintenanceScheduleService.delete(id).subscribe(() => {
//           //this.getMaintenanceSchedules();
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

}

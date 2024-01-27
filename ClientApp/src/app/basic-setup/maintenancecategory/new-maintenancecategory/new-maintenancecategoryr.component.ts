import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MaintenanceCategoryService } from 'src/app/basic-setup/service/MaintenanceCategory.service';
import { DepartmentNameService } from 'src/app/basic-setup/service/DepartmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectionModel } from '@angular/cdk/collections';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MaintenanceCategory } from '../../models/MaintenanceCategory';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-maintenancecategory',
  templateUrl: './new-maintenancecategory.component.html',
  styleUrls: ['./new-maintenancecategory.component.sass']
})
export class NewMaintenanceCategoryComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  MaintenanceCategoryForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  maintenanceType:SelectedModel[];
  selectedType:SelectedModel[];
  maintenenceCategoryList:MaintenanceCategory[];
  isShown: boolean = false ;
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  
  displayedColumns: string[] = ['ser', 'categoryName',  'remarks', 'departmentName', 'maintenanceType', 'actions'];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private DepartmentNameService: DepartmentNameService,private confirmService: ConfirmService,private MaintenanceCategoryService: MaintenanceCategoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('maintenanceCategoryId'); 
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
 
    if (id) {
       //this.isShown=false;
       console.log(this.isShown);
      this.pageTitle = 'Edit Maintenance Category';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.MaintenanceCategoryService.find(+id).subscribe(
        res => {
          this.MaintenanceCategoryForm.patchValue({          

            maintenanceCategoryId: res.maintenanceCategoryId,
            categoryName: res.categoryName,
            remarks: res.remarks,
            departmentNameId: res.departmentNameId,
            maintenanceTypeId:res.maintenanceTypeId,
            isActive: res.isActive,
           
            //menuPosition: res.menuPosition,
          
          });          
          this.onDepartmentNameSelectionChangeGetMaintenanceType()
        }
      );
    } else {
      this.pageTitle = 'Create Maintenance Category';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.MaintenanceCategoryForm.get('departmentNameId').setValue(this.branchId);
      this.onDepartmentNameSelectionChangeGetMaintenanceType();
      // this.onDepartmentSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    //this.getselectedMaintenanceType();
  }
  intitializeForm() {
    this.MaintenanceCategoryForm = this.fb.group({
      maintenanceCategoryId: [0],
      categoryName: ['', Validators.required],
      remarks: [''],
      departmentNameId: [],
      maintenanceTypeId:[],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }

  onMaintenanceTypeSelectionChange(dropdown){
    this.isShown=true;
    if(dropdown.isUserInput) {
      var departmentNameId =this.MaintenanceCategoryForm.value['departmentNameId'];
      console.log(dropdown.source.value, departmentNameId);
      this.MaintenanceCategoryService.getMaintainencesCategoryByTypeAndDepartment(dropdown.source.value,departmentNameId).subscribe(res=>{
        this.maintenenceCategoryList=res
        console.log( this.maintenenceCategoryList);
      });
    }
  }

  // getDepartmentName(){
  //   this.DepartmentNameService.getselectedDepertments().subscribe(res=>{
  //     this.departmentName=res
  //     console.log(this.departmentName);
  //   });
  // }
  GetDepartmentNameById(baseNameId){    
    this.DepartmentNameService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log(res)
    }); 
  }
  onDepartmentNameSelectionChangeGetMaintenanceType(){
    var departmentNameId = this.MaintenanceCategoryForm.value['departmentNameId'];
    this.MaintenanceCategoryService.getMaintenanceTypeByDepartmentNameId(departmentNameId).subscribe(res=>{
      //this.onDepartmentNameSelectionChangeGetAirCraftName(departmentNameId)
      this.selectedType=res
      console.log(this.selectedType)
    });
   }
  // getselectedMaintenanceType(){
  //   this.MaintenanceCategoryService.getselectedMaintenanceType().subscribe(res=>{
  //     this.maintenanceType=res
  //   });
  // }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  deleteItem(row) {
    const id = row.maintenanceCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MaintenanceCategoryService.delete(id).subscribe(() => {

         // this.getCastes();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
          this.reloadCurrentRoute();
        })
      }
    })    
  }
  
  onSubmit() {
    const id = this.MaintenanceCategoryForm.get('maintenanceCategoryId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.MaintenanceCategoryService.update(+id,this.MaintenanceCategoryForm.value).subscribe(response => {
          this.router.navigateByUrl('/basic-setup/add-maintenancecategory');
           // this.reloadCurrentRoute();
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
         // this.router.navigateByUrl('/basic-setup/add-maintenancesubcategory');
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    } else {
      this.MaintenanceCategoryService.submit(this.MaintenanceCategoryForm.value).subscribe(response => {
        //this.router.navigateByUrl('/basic-setup/maintenencecategory-list');
        this.reloadCurrentRoute();
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}

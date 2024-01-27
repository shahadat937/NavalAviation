import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MaintenanceTypeService } from '../../service/MaintenanceType.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-maintenancetype',
  templateUrl: './new-maintenancetype.component.html',
  styleUrls: ['./new-maintenancetype.component.sass']
})
export class NewMaintenanceTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  MaintenanceTypeForm: FormGroup;
  validationErrors: string[] = [];
  selectedDepartmentNames:SelectedModel[]; 
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private MaintenanceTypeService: MaintenanceTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('maintenanceTypeId'); 
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
 
    if (id) {
      this.pageTitle = 'Edit Maintenance Type';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.MaintenanceTypeService.find(+id).subscribe(
        res => {
          this.MaintenanceTypeForm.patchValue({          

            maintenanceTypeId: res.maintenanceTypeId,
            name: res.name,
            remarks: res.remarks,
            departmentNameId:res.departmentNameId,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Maintenance Type';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.MaintenanceTypeForm.get('departmentNameId').setValue(this.branchId);
      // this.onDepartmentSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.MaintenanceTypeForm = this.fb.group({
      maintenanceTypeId: [0],
      name: [''],
      remarks: [''],
      departmentNameId:[],
      isActive: [true],
    
    })
  }
  // getselectedDepartmentNames(){
  //   this.MaintenanceTypeService.getselectedDepartmentNames().subscribe(res=>{
  //     this.selectedDepartmentNames=res
  //     console.log(this.selectedDepartmentNames);      
  //   });
  // }
  GetDepartmentNameById(baseNameId){    
    this.MaintenanceTypeService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentNames=res
      console.log(res)
    }); 
  }
  
  onSubmit() {
    const id = this.MaintenanceTypeForm.get('maintenanceTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.MaintenanceTypeService.update(+id,this.MaintenanceTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/maintenence-planning/maintenancetype-list');
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    } else {
      this.MaintenanceTypeService.submit(this.MaintenanceTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/maintenence-planning/maintenancetype-list');
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

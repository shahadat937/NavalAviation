import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { GseMaintenanceScheduleNameService } from '../../service/GseMaintenanceScheduleName.service';
import { DepartmentNameService } from '../../service/DepartmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectionModel } from '@angular/cdk/collections';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-gsemaintenanceschedulename',
  templateUrl: './new-gsemaintenanceschedulename.component.html',
  styleUrls: ['./new-gsemaintenanceschedulename.component.sass']
})
export class NewGseMaintenanceScheduleNameComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  GseMaintenanceScheduleNameForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  GseMaintenanceScheduleNameScheduleName: SelectedModel[];
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private DepartmentNameService: DepartmentNameService,private confirmService: ConfirmService,private GseMaintenanceScheduleNameService: GseMaintenanceScheduleNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('gseMaintenanceScheduleNameId'); 
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Gse Maintenance Schedule Name';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.GseMaintenanceScheduleNameService.find(+id).subscribe(
        res => {
          this.GseMaintenanceScheduleNameForm.patchValue({          

            gseMaintenanceScheduleNameId: res.gseMaintenanceScheduleNameId,        
            scheduleName: res.scheduleName,
            remarks: res.remarks,
            departmentNameId: res.departmentNameId,
            isActive: res.isActive,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Gse Maintenance Schedule Name';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.GseMaintenanceScheduleNameForm.get('departmentNameId').setValue(this.branchId);
      // this.onEquipmentNameListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.GseMaintenanceScheduleNameForm = this.fb.group({
      gseMaintenanceScheduleNameId: [0],
      scheduleName: [''],
      remarks: [''],
      departmentNameId: [],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
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
  
  onSubmit() {
    const id = this.GseMaintenanceScheduleNameForm.get('gseMaintenanceScheduleNameId').value;   
    console.log(this.GseMaintenanceScheduleNameForm.value )
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.GseMaintenanceScheduleNameService.update(+id,this.GseMaintenanceScheduleNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/gsemaintenanceschedulename-list');
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
      this.GseMaintenanceScheduleNameService.submit(this.GseMaintenanceScheduleNameForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/gsemaintenanceschedulename-list');
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

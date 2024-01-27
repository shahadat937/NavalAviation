import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { GseScheduleWorkTypeService } from '../../service/GseScheduleWorkType.service';
import { DepartmentNameService } from '../../service/DepartmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectionModel } from '@angular/cdk/collections';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-gsescheduleworktype',
  templateUrl: './new-gsescheduleworktype.component.html',
  styleUrls: ['./new-gsescheduleworktype.component.sass']
})
export class NewGseScheduleWorkTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  GseScheduleWorkTypeForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  GseScheduleWorkTypeScheduleName: SelectedModel[];
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private DepartmentNameService: DepartmentNameService,private confirmService: ConfirmService,private GseScheduleWorkTypeService: GseScheduleWorkTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('gseScheduleWorkTypeId'); 
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Gse Schedule Work Type';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.GseScheduleWorkTypeService.find(+id).subscribe(
        res => {
          this.GseScheduleWorkTypeForm.patchValue({          

            gseScheduleWorkTypeId: res.gseScheduleWorkTypeId,
            gseMaintenanceScheduleNameId: res.gseMaintenanceScheduleNameId,            
            scheduleWorkName: res.scheduleWorkName,
            remarks: res.remarks,
            departmentNameId: res.departmentNameId,
            isActive: res.isActive,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Gse Schedule Work Type';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.GseScheduleWorkTypeForm.get('departmentNameId').setValue(this.branchId);
      // this.onEquipmentNameListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedGseMaintenanceScheduleNames();
  }
  intitializeForm() {
    this.GseScheduleWorkTypeForm = this.fb.group({
      gseScheduleWorkTypeId: [0],
      gseMaintenanceScheduleNameId: [],
      scheduleWorkName: [''],
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

  getselectedGseMaintenanceScheduleNames(){
    this.GseScheduleWorkTypeService.getselectedGseMaintenanceScheduleNames().subscribe(res=>{
      this.GseScheduleWorkTypeScheduleName=res
      console.log(this.GseScheduleWorkTypeScheduleName);
    });
  }
  
  onSubmit() {
    const id = this.GseScheduleWorkTypeForm.get('gseScheduleWorkTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.GseScheduleWorkTypeService.update(+id,this.GseScheduleWorkTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/gsescheduleworktype-list');
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
      this.GseScheduleWorkTypeService.submit(this.GseScheduleWorkTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/gsescheduleworktype-list');
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { GseMaintenanceService } from '../../service/GseMaintenance.service';
import { DepartmentNameService } from '../../service/DepartmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectionModel } from '@angular/cdk/collections';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-gsemaintenance',
  templateUrl: './new-gsemaintenance.component.html',
  styleUrls: ['./new-gsemaintenance.component.sass']
})
export class NewGseMaintenanceComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  GseMaintenanceForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  gseItemName: SelectedModel[];
  gseScheduleWorkType: SelectedModel[];
  gseMaintenanceScheduleName: SelectedModel[];
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private DepartmentNameService: DepartmentNameService,private confirmService: ConfirmService,private GseMaintenanceService: GseMaintenanceService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('gseMaintenanceId'); 
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Gse Maintenance';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.GseMaintenanceService.find(+id).subscribe(
        res => {
          this.GseMaintenanceForm.patchValue({          

            gseMaintenanceId: res.gseMaintenanceId,
            gseItemNameId: res.gseItemNameId,
            gseScheduleWorkTypeId: res.gseScheduleWorkTypeId,
            gseMaintenanceScheduleNameId: res.gseMaintenanceScheduleNameId,
            date: res.date,
            remarks: res.remarks,
            departmentNameId: res.departmentNameId,
            isActive: res.isActive,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Gse Maintenance';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.GseMaintenanceForm.get('departmentNameId').setValue(this.branchId);
      // this.onEquipmentNameListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedGseItemNames();
    this.getselectedGseMaintenanceScheduleNames();
    this.getselectedGseScheduleWorkTypes();
  }
  intitializeForm() {
    this.GseMaintenanceForm = this.fb.group({
      gseMaintenanceId: [0],
      gseItemNameId: [],
      gseScheduleWorkTypeId: [],
      gseMaintenanceScheduleNameId: [],
      date: [],
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

  getselectedGseItemNames(){
    this.GseMaintenanceService.getselectedGseItemNames().subscribe(res=>{
      this.gseItemName=res
      console.log(this.gseItemName);
    });
  }

  getselectedGseScheduleWorkTypes(){
    this.GseMaintenanceService.getselectedGseScheduleWorkTypes().subscribe(res=>{
      this.gseScheduleWorkType=res
      console.log(this.gseScheduleWorkType);
    });
  }

  getselectedGseMaintenanceScheduleNames(){
    this.GseMaintenanceService.getselectedGseMaintenanceScheduleNames().subscribe(res=>{
      this.gseMaintenanceScheduleName=res
      console.log(this.gseMaintenanceScheduleName);
    });
  }
  
  onSubmit() {
    const id = this.GseMaintenanceForm.get('gseMaintenanceId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.GseMaintenanceService.update(+id,this.GseMaintenanceForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/gsemaintenance-list');
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
      this.GseMaintenanceService.submit(this.GseMaintenanceForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/gsemaintenance-list');
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

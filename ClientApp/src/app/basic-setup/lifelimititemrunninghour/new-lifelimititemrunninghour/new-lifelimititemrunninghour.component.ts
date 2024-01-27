import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { LifeLimitItemRunningHourService } from '../../service/LifeLimitItemRunningHour.service';
import { DepartmentNameService } from '../../service/DepartmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectionModel } from '@angular/cdk/collections';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-lifelimititemrunninghour',
  templateUrl: './new-lifelimititemrunninghour.component.html',
  styleUrls: ['./new-lifelimititemrunninghour.component.sass']
})
export class NewLifeLimitItemRunningHourComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  LifeLimitItemRunningHourForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  lifeLimitItem: SelectedModel[];
  maintenanceCategory: SelectedModel[];
  itemDetail: SelectedModel[];
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private DepartmentNameService: DepartmentNameService,private confirmService: ConfirmService,private LifeLimitItemRunningHourService: LifeLimitItemRunningHourService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('lifeLimitItemRunningHourId'); 

    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)


    if (id) {
      this.pageTitle = 'Edit Life Limit Item Running Hour';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.LifeLimitItemRunningHourService.find(+id).subscribe(
        res => {
          this.LifeLimitItemRunningHourForm.patchValue({          

            lifeLimitItemRunningHourId: res.lifeLimitItemRunningHourId,
            lifeLimitItemId: res.lifeLimitItemId,
            maintenanceCategoryId: res.maintenanceCategoryId,
            itemDetailId: res.itemDetailId,
            slNo: res.slNo,
            flightDate: res.flightDate,
            flightTimeHr: res.flightTimeHr,
            flightTimeMin: res.flightTimeMin,
            departmentNameId: res.departmentNameId,
            remarks: res.remarks,
            isActive: res.isActive,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Life Limit Item Running Hour';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.LifeLimitItemRunningHourForm.get('departmentNameId').setValue(this.branchId);
      // this.onEquipmentNameListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedLifeLimitItems();
    this.getselectedMaintenanceCategorys();


  }
  intitializeForm() {
    this.LifeLimitItemRunningHourForm = this.fb.group({
      lifeLimitItemRunningHourId: [0],
      lifeLimitItemId: [],
      maintenanceCategoryId: [],
      itemDetailId: [],
      slNo: [''],
      flightDate: [],
      flightTimeHr: [''],
      flightTimeMin: [''],
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
  getselectedLifeLimitItems(){
    this.LifeLimitItemRunningHourService.getselectedLifeLimitItems().subscribe(res=>{
      this.lifeLimitItem=res
      console.log(this.lifeLimitItem);
    });
  }

  getselectedMaintenanceCategorys(){
    this.LifeLimitItemRunningHourService.getselectedMaintenanceCategorys().subscribe(res=>{
      this.maintenanceCategory=res
      console.log(this.maintenanceCategory);
    });
  }

  
  
  onSubmit() {
    const id = this.LifeLimitItemRunningHourForm.get('lifeLimitItemRunningHourId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.LifeLimitItemRunningHourService.update(+id,this.LifeLimitItemRunningHourForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/lifelimititemrunninghour-list');
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
      this.LifeLimitItemRunningHourService.submit(this.LifeLimitItemRunningHourForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/lifelimititemrunninghour-list');
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

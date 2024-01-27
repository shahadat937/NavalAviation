import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { NameofPublicationService } from '../../service/NameofPublication.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-nameofpublication',
  templateUrl: './new-nameofpublication.component.html',
  styleUrls: ['./new-nameofpublication.component.sass']
})
export class NewNameofPublicationComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  NameofPublicationForm: FormGroup;
  validationErrors: string[] = [];
  selectedDepartmentNames:SelectedModel[]; 
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private NameofPublicationService: NameofPublicationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('nameofPublicationId'); 
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
 
    if (id) {
      this.pageTitle = 'Edit Name of Publication';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.NameofPublicationService.find(+id).subscribe(
        res => {
          this.NameofPublicationForm.patchValue({          

            nameofPublicationId: res.nameofPublicationId,
            name: res.name,
            departmentNameId:res.departmentNameId,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Name of Publication';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.NameofPublicationForm.get('departmentNameId').setValue(this.branchId);
      // this.onDepartmentSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.NameofPublicationForm = this.fb.group({
      nameofPublicationId: [0],
      name: [''],
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
    this.NameofPublicationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentNames=res
      console.log(res)
    }); 
  }
  
  onSubmit() {
    const id = this.NameofPublicationForm.get('nameofPublicationId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.NameofPublicationService.update(+id,this.NameofPublicationForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/nameofpublication-list');
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
      this.NameofPublicationService.submit(this.NameofPublicationForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/nameofpublication-list');
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

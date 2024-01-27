import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentNameService } from '../../service/DepartmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-departmentname',
  templateUrl: './new-departmentname.component.html',
  styleUrls: ['./new-departmentname.component.sass']
})
export class NewDepartmentNameComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  DepartmentNameForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private DepartmentNameService: DepartmentNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('departmentNameId'); 
    if (id) {
      this.pageTitle = 'Edit Department Name';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.DepartmentNameService.find(+id).subscribe(
        res => {
          this.DepartmentNameForm.patchValue({          

            departmentNameId: res.departmentNameId,
            name: res.name,
            remarks: res.remarks,
            status: res.status,
            isActive: res.isActive,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Department Name';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.DepartmentNameForm = this.fb.group({
      departmentNameId: [0],
      name: ['', Validators.required],
      remarks: [''],
      status: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.DepartmentNameForm.get('departmentNameId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.DepartmentNameService.update(+id,this.DepartmentNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/departmentname-list');
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
      this.DepartmentNameService.submit(this.DepartmentNameForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/departmentname-list');
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

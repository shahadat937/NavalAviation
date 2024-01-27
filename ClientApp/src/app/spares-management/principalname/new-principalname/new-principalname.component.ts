import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PrincipalNameService } from '../../service/PrincipalName.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-principalname',
  templateUrl: './new-principalname.component.html',
  styleUrls: ['./new-principalname.component.sass']
})
export class NewPrincipalNameComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  PrincipalNameForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private PrincipalNameService: PrincipalNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('principalNameId'); 
    if (id) {
      this.pageTitle = 'Edit Principal Name';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.PrincipalNameService.find(+id).subscribe(
        res => {
          this.PrincipalNameForm.patchValue({          

            principalNameId: res.principalNameId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Principal Name';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.PrincipalNameForm = this.fb.group({
      principalNameId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.PrincipalNameForm.get('principalNameId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.PrincipalNameService.update(+id,this.PrincipalNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/spares-management/principalname-list');
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
      this.PrincipalNameService.submit(this.PrincipalNameForm.value).subscribe(response => {
        this.router.navigateByUrl('/spares-management/principalname-list');
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

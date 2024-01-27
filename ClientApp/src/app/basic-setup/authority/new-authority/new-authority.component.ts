import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorityService } from '../../service/authority.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-authority',
  templateUrl: './new-authority.component.html',
  styleUrls: ['./new-authority.component.sass']
})
export class NewAuthorityComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  AuthorityForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private AuthorityService: AuthorityService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('authorityId'); 
    if (id) {
      this.pageTitle = 'Edit Authority';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.AuthorityService.find(+id).subscribe(
        res => {
          this.AuthorityForm.patchValue({          

            authorityId: res.authorityId,
            name: res.name,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Authority';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.AuthorityForm = this.fb.group({
      authorityId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.AuthorityForm.get('authorityId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.AuthorityService.update(+id,this.AuthorityForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/authority-list');
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
      this.AuthorityService.submit(this.AuthorityForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/authority-list');
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

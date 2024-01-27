import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { LifeLimitItemService } from '../../service/LifeLimitItem.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-lifelimititem',
  templateUrl: './new-lifelimititem.component.html',
  styleUrls: ['./new-lifelimititem.component.sass']
})
export class NewLifeLimitItemComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  LifeLimitItemForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private LifeLimitItemService: LifeLimitItemService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('lifeLimitItemId'); 
    if (id) {
      this.pageTitle = 'Edit Life Limit Item';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.LifeLimitItemService.find(+id).subscribe(
        res => {
          this.LifeLimitItemForm.patchValue({          

            lifeLimitItemId: res.lifeLimitItemId,
            name: res.name,
            remarks: res.remarks,
            status: res.status,
            isActive: res.isActive
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create  Life Limit Item';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.LifeLimitItemForm = this.fb.group({
      lifeLimitItemId: [0],
      name: ['', Validators.required],
      remarks: [''],
      status: [true],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.LifeLimitItemForm.get('lifeLimitItemId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.LifeLimitItemService.update(+id,this.LifeLimitItemForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/lifelimititem-list');
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
      this.LifeLimitItemService.submit(this.LifeLimitItemForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/lifelimititem-list');
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ReminderTypeService } from '../../service/ReminderType.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-remindertype',
  templateUrl: './new-remindertype.component.html',
  styleUrls: ['./new-remindertype.component.sass']
})
export class NewReminderTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ReminderTypeForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ReminderTypeService: ReminderTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('reminderTypeId'); 
    if (id) {
      this.pageTitle = 'Edit Reminder Type';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ReminderTypeService.find(+id).subscribe(
        res => {
          this.ReminderTypeForm.patchValue({          

            reminderTypeId: res.reminderTypeId,
            name: res.name,
            remarks: res.remarks,
            status: res.status,
            isActive: res.isActive
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create  Reminder Type';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ReminderTypeForm = this.fb.group({
      reminderTypeId: [0],
      name: ['', Validators.required],
      remarks: [''],
      status: [true],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.ReminderTypeForm.get('reminderTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ReminderTypeService.update(+id,this.ReminderTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/remindertype-list');
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
      this.ReminderTypeService.submit(this.ReminderTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/remindertype-list');
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

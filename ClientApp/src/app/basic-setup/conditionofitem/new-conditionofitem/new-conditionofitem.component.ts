import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConditionOfItemService } from '../../service/ConditionOfItem.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-conditionofitem',
  templateUrl: './new-conditionofitem.component.html',
  styleUrls: ['./new-conditionofitem.component.sass']
})
export class NewConditionOfItemComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
 ConditionOfItemForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ConditionOfItemService:ConditionOfItemService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('conditionOfItemId'); 
    if (id) {
      this.pageTitle = 'EditConditionOfItem';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ConditionOfItemService.find(+id).subscribe(
        res => {
          this.ConditionOfItemForm.patchValue({          

            conditionOfItemId: res.conditionOfItemId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'CreateConditionOfItem';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ConditionOfItemForm = this.fb.group({
      conditionOfItemId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ConditionOfItemForm.get('conditionOfItemId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ConditionOfItemService.update(+id,this.ConditionOfItemForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/conditionofitem-list');
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
      this.ConditionOfItemService.submit(this.ConditionOfItemForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/conditionofitem-list');
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

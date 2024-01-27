import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemStatusService } from '../../service/ItemStatus.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-itemstatus',
  templateUrl: './new-itemstatus.component.html',
  styleUrls: ['./new-itemstatus.component.sass']
})
export class NewItemStatusComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ItemStatusForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ItemStatusService: ItemStatusService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('itemStatusId'); 
    if (id) {
      this.pageTitle = 'Edit ItemStatus';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ItemStatusService.find(+id).subscribe(
        res => {
          this.ItemStatusForm.patchValue({          

            itemStatusId: res.itemStatusId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create ItemStatus';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ItemStatusForm = this.fb.group({
      itemStatusId: [0],
      name: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ItemStatusForm.get('itemStatusId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ItemStatusService.update(+id,this.ItemStatusForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/itemstatus-list');
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
      this.ItemStatusService.submit(this.ItemStatusForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/itemstatus-list');
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

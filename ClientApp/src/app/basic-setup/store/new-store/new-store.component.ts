import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from '../../service/store.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-store',
  templateUrl: './new-store.component.html',
  styleUrls: ['./new-store.component.sass']
})
export class NewStoreComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  StoreForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private StoreService: StoreService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('storeId'); 
    if (id) {
      this.pageTitle = 'Edit Store';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.StoreService.find(+id).subscribe(
        res => {
          this.StoreForm.patchValue({          

            storeId: res.storeId,
            name: res.name,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Store';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.StoreForm = this.fb.group({
      storeId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.StoreForm.get('storeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.StoreService.update(+id,this.StoreForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/store-list');
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
      this.StoreService.submit(this.StoreForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/store-list');
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ShelfLifeCategoryService } from '../../service/shelfLifeCategory.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-shelflifecategory',
  templateUrl: './new-shelflifecategory.component.html',
  styleUrls: ['./new-shelflifecategory.component.sass']
})
export class NewShelfLifeCategoryComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ShelfLifeCategoryForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ShelfLifeCategoryService: ShelfLifeCategoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('shelfLifeCategoryId'); 
    if (id) {
      this.pageTitle = 'Edit Shelf Life Category';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ShelfLifeCategoryService.find(+id).subscribe(
        res => {
          this.ShelfLifeCategoryForm.patchValue({          

            shelfLifeCategoryId: res.shelfLifeCategoryId,
            name: res.name,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Shelf Life Category';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ShelfLifeCategoryForm = this.fb.group({
      shelfLifeCategoryId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.ShelfLifeCategoryForm.get('shelfLifeCategoryId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.ShelfLifeCategoryService.update(+id,this.ShelfLifeCategoryForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/shelflifecategory-list');
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
      this.ShelfLifeCategoryService.submit(this.ShelfLifeCategoryForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/shelflifecategory-list');
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemCategoryTypeService } from '../../service/ItemCategoryType.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-itemcategorytype',
  templateUrl: './new-itemcategorytype.component.html',
  styleUrls: ['./new-itemcategorytype.component.sass']
})
export class NewItemCategoryTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ItemCategoryTypeForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ItemCategoryTypeService: ItemCategoryTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('itemCategoryTypeId'); 
    if (id) {
      this.pageTitle = 'Edit Item Category Type';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ItemCategoryTypeService.find(+id).subscribe(
        res => {
          this.ItemCategoryTypeForm.patchValue({          

            itemCategoryTypeId: res.itemCategoryTypeId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Item Category Type';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ItemCategoryTypeForm = this.fb.group({
      itemCategoryTypeId: [0],
      name: [''],
      remarks: [''],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ItemCategoryTypeForm.get('itemCategoryTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ItemCategoryTypeService.update(+id,this.ItemCategoryTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/itemcategorytype-list');
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
      this.ItemCategoryTypeService.submit(this.ItemCategoryTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/itemcategorytype-list');
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

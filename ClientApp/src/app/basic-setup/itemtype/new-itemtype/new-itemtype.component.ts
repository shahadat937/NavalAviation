import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemTypeService } from '../../service/ItemType.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-itemtype',
  templateUrl: './new-itemtype.component.html',
  styleUrls: ['./new-itemtype.component.sass']
})
export class NewItemTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
 ItemTypeForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ItemTypeService:ItemTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('itemTypeId'); 
    if (id) {
      this.pageTitle = 'EditItemType';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ItemTypeService.find(+id).subscribe(
        res => {
          this.ItemTypeForm.patchValue({          

            itemTypeId: res.itemTypeId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'CreateItemType';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ItemTypeForm = this.fb.group({
     itemTypeId: [0],
      name: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ItemTypeForm.get('itemTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ItemTypeService.update(+id,this.ItemTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/itemtype-list');
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
      this.ItemTypeService.submit(this.ItemTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/itemtype-list');
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemCategoryService } from '../../service/ItemCategory.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { MasterData } from 'src/assets/data/master-data';

@Component({
  selector: 'app-new-itemcategory',
  templateUrl: './new-itemcategory.component.html',
  styleUrls: ['./new-itemcategory.component.sass']
})
export class NewItemCategoryComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  pageTitle: string;
  destination:string;
  btnText:string;
  ItemCategoryForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 
  selectedSparesCategory:SelectedModel[]; 

  traineeId:any;
  role:any;
  branchId:any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private ItemCategoryService: ItemCategoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    const id = this.route.snapshot.paramMap.get('itemCategoryId'); 
    if (id) {
      this.pageTitle = 'Edit ItemCategory';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ItemCategoryService.find(+id).subscribe(
        res => {
          this.ItemCategoryForm.patchValue({          

            itemCategoryId: res.itemCategoryId,
            sparesCategoryId: res.sparesCategoryId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create ItemCategory';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    
    this.getSelectedSparesCategory();
  }
  intitializeForm() {
    this.ItemCategoryForm = this.fb.group({
      itemCategoryId: [0],
      sparesCategoryId: [],
      name: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }

  getSelectedSparesCategory(){    
    this.ItemCategoryService.getSelectedSparesCategory().subscribe(res=>{
      this.selectedSparesCategory=res;
      console.log(res)
    }); 
  }
  
  onSubmit() {
    const id = this.ItemCategoryForm.get('itemCategoryId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ItemCategoryService.update(+id,this.ItemCategoryForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/itemcategory-list');
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
      this.ItemCategoryService.submit(this.ItemCategoryForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/itemcategory-list');
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

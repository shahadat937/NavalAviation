import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OverhaulingTypeService } from '../../service/OverhaulingType.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-overhaulingtype',
  templateUrl: './new-overhaulingtype.component.html',
  styleUrls: ['./new-overhaulingtype.component.sass']
})
export class NewOverhaulingTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  OverhaulingTypeForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private OverhaulingTypeService: OverhaulingTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('overhaulingTypeId'); 
    if (id) {
      this.pageTitle = 'Edit Overhauling Type';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.OverhaulingTypeService.find(+id).subscribe(
        res => {
          this.OverhaulingTypeForm.patchValue({          

            overhaulingTypeId: res.overhaulingTypeId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Overhauling Type';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.OverhaulingTypeForm = this.fb.group({
      overhaulingTypeId: [0],
      name: [''],
      remarks: [''],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.OverhaulingTypeForm.get('overhaulingTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.OverhaulingTypeService.update(+id,this.OverhaulingTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/overhaulingtype-list');
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
      this.OverhaulingTypeService.submit(this.OverhaulingTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/overhaulingtype-list');
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

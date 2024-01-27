import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EndLifeTypeService } from '../../service/EndLifeType.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-endlifetype',
  templateUrl: './new-endlifetype.component.html',
  styleUrls: ['./new-endlifetype.component.sass']
})
export class NewEndLifeTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  EndLifeTypeForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private EndLifeTypeService: EndLifeTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('endLifeTypeId'); 
    if (id) {
      this.pageTitle = 'Edit End Life Type';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.EndLifeTypeService.find(+id).subscribe(
        res => {
          this.EndLifeTypeForm.patchValue({          

            endLifeTypeId: res.endLifeTypeId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create End Life Type';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.EndLifeTypeForm = this.fb.group({
      endLifeTypeId: [0],
      name: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.EndLifeTypeForm.get('endLifeTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.EndLifeTypeService.update(+id,this.EndLifeTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/endlifetype-list');
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
      this.EndLifeTypeService.submit(this.EndLifeTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/endlifetype-list');
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

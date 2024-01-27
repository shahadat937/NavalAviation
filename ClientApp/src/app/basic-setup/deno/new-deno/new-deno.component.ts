import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DenoService } from '../../service/Deno.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-deno',
  templateUrl: './new-deno.component.html',
  styleUrls: ['./new-deno.component.sass']
})
export class NewDenoComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  DenoForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private DenoService: DenoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('denoId'); 
    if (id) {
      this.pageTitle = 'Edit Deno';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.DenoService.find(+id).subscribe(
        res => {
          this.DenoForm.patchValue({          

            denoId: res.denoId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Deno';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.DenoForm = this.fb.group({
      denoId: [0],
      name: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.DenoForm.get('denoId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.DenoService.update(+id,this.DenoForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/deno-list');
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
      this.DenoService.submit(this.DenoForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/deno-list');
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

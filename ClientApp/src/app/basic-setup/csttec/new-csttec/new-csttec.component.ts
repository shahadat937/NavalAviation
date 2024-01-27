import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CstTecService } from '../../service/CstTec.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-csttec',
  templateUrl: './new-csttec.component.html',
  styleUrls: ['./new-csttec.component.sass']
})
export class NewCstTecComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  CstTecForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private CstTecService: CstTecService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('cstTecId'); 
    if (id) {
      this.pageTitle = 'Edit Cst Tec';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.CstTecService.find(+id).subscribe(
        res => {
          this.CstTecForm.patchValue({          

            cstTecId: res.cstTecId,
            name: res.name
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Cst Tec';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.CstTecForm = this.fb.group({
      cstTecId: [0],
      name: [''],
      isActive: [true]
    })
  }
  
  onSubmit() {
    const id = this.CstTecForm.get('cstTecId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.CstTecService.update(+id,this.CstTecForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/csttec-list');
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
      this.CstTecService.submit(this.CstTecForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/csttec-list');
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

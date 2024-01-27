import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ManufactureService } from '../../service/Manufacture.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-manufacture',
  templateUrl: './new-manufacture.component.html',
  styleUrls: ['./new-manufacture.component.sass']
})
export class NewManufactureComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ManufactureForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ManufactureService: ManufactureService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('manufactureId'); 
    if (id) {
      this.pageTitle = 'Edit Manufacture';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ManufactureService.find(+id).subscribe(
        res => {
          this.ManufactureForm.patchValue({          

            manufactureId: res.manufactureId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Manufacture';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ManufactureForm = this.fb.group({
      manufactureId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ManufactureForm.get('manufactureId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ManufactureService.update(+id,this.ManufactureForm.value).subscribe(response => {
            this.router.navigateByUrl('/spares-management/manufacture-list');
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
      this.ManufactureService.submit(this.ManufactureForm.value).subscribe(response => {
        this.router.navigateByUrl('/spares-management/manufacture-list');
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

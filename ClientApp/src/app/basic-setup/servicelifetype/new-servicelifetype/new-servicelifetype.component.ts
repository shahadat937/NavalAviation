import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceLifeTypeService } from '../../service/ServiceLifeType.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-servicelifetype',
  templateUrl: './new-servicelifetype.component.html',
  styleUrls: ['./new-servicelifetype.component.sass']
})
export class NewServiceLifeTypeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ServiceLifeTypeForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ServiceLifeTypeService: ServiceLifeTypeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('serviceLifeTypeId'); 
    if (id) {
      this.pageTitle = 'Edit Service Life Type';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ServiceLifeTypeService.find(+id).subscribe(
        res => {
          this.ServiceLifeTypeForm.patchValue({          

            serviceLifeTypeId: res.serviceLifeTypeId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Service Life Type';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ServiceLifeTypeForm = this.fb.group({
      serviceLifeTypeId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ServiceLifeTypeForm.get('serviceLifeTypeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ServiceLifeTypeService.update(+id,this.ServiceLifeTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/servicelifetype-list');
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
      this.ServiceLifeTypeService.submit(this.ServiceLifeTypeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/servicelifetype-list');
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

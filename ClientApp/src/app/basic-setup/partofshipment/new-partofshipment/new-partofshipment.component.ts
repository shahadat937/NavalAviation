import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PartOfShipmentService } from '../../service/PartOfShipment.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-partofshipment',
  templateUrl: './new-partofshipment.component.html',
  styleUrls: ['./new-partofshipment.component.sass']
})
export class NewPartOfShipmentComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  PartOfShipmentForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private PartOfShipmentService: PartOfShipmentService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('partOfShipmentId'); 
    if (id) {
      this.pageTitle = 'Edit Part Of Shipment';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.PartOfShipmentService.find(+id).subscribe(
        res => {
          this.PartOfShipmentForm.patchValue({          

            partOfShipmentId: res.partOfShipmentId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Part Of Shipment';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.PartOfShipmentForm = this.fb.group({
      partOfShipmentId: [0],
      name: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.PartOfShipmentForm.get('partOfShipmentId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.PartOfShipmentService.update(+id,this.PartOfShipmentForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/partofshipment-list');
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
      this.PartOfShipmentService.submit(this.PartOfShipmentForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/partofshipment-list');
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

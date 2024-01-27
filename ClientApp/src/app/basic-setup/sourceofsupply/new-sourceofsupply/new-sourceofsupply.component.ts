import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SourceOfSupplyService } from '../../service/SourceOfSupply.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-sourceofsupply',
  templateUrl: './new-sourceofsupply.component.html',
  styleUrls: ['./new-sourceofsupply.component.sass']
})
export class NewSourceOfSupplyComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  SourceOfSupplyForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private SourceOfSupplyService: SourceOfSupplyService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('sourceOfSupplyId'); 
    if (id) {
      this.pageTitle = 'Edit Source Of Supply';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.SourceOfSupplyService.find(+id).subscribe(
        res => {
          this.SourceOfSupplyForm.patchValue({          

            sourceOfSupplyId: res.sourceOfSupplyId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Source Of Supply';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.SourceOfSupplyForm = this.fb.group({
      sourceOfSupplyId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.SourceOfSupplyForm.get('sourceOfSupplyId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.SourceOfSupplyService.update(+id,this.SourceOfSupplyForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/sourceofsupply-list');
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
      this.SourceOfSupplyService.submit(this.SourceOfSupplyForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/sourceofsupply-list');
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

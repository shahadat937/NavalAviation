import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToolsLocationService } from '../../service/ToolsLocation.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-toolslocation',
  templateUrl: './new-toolslocation.component.html',
  styleUrls: ['./new-toolslocation.component.sass']
})
export class NewToolsLocationComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ToolsLocationForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ToolsLocationService: ToolsLocationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('toolsLocationId'); 
    if (id) {
      this.pageTitle = 'Edit ToolsLocation';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ToolsLocationService.find(+id).subscribe(
        res => {
          this.ToolsLocationForm.patchValue({          

            toolsLocationId: res.toolsLocationId,
            toolsLocationName: res.toolsLocationName,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create ToolsLocation';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ToolsLocationForm = this.fb.group({
      toolsLocationId: [0],
      toolsLocationName: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ToolsLocationForm.get('toolsLocationId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ToolsLocationService.update(+id,this.ToolsLocationForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/toolslocation-list');
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
      this.ToolsLocationService.submit(this.ToolsLocationForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/toolslocation-list');
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

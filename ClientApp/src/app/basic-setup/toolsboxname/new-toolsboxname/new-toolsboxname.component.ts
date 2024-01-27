import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToolsBoxNameService } from '../../service/ToolsBoxName.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-toolsboxname',
  templateUrl: './new-toolsboxname.component.html',
  styleUrls: ['./new-toolsboxname.component.sass']
})
export class NewToolsBoxNameComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  ToolsBoxNameForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ToolsBoxNameService: ToolsBoxNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('toolsBoxNameId'); 
    if (id) {
      this.pageTitle = 'Edit ToolsBoxName';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ToolsBoxNameService.find(+id).subscribe(
        res => {
          this.ToolsBoxNameForm.patchValue({          

            toolsBoxNameId: res.toolsBoxNameId,
            name: res.name,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create ToolsBoxName';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ToolsBoxNameForm = this.fb.group({
      toolsBoxNameId: [0],
      name: ['', Validators.required],
      remarks: ['', Validators.required],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.ToolsBoxNameForm.get('toolsBoxNameId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.ToolsBoxNameService.update(+id,this.ToolsBoxNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/toolsboxname-list');
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
      this.ToolsBoxNameService.submit(this.ToolsBoxNameForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/toolsboxname-list');
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { IssueStatusService } from '../../service/IssueStatus.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-issuestatus',
  templateUrl: './new-issuestatus.component.html',
  styleUrls: ['./new-issuestatus.component.sass']
})
export class NewIssueStatusComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  IssueStatusForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private IssueStatusService: IssueStatusService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('issueStatusId'); 
    if (id) {
      this.pageTitle = 'Edit Issue Status';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.IssueStatusService.find(+id).subscribe(
        res => {
          this.IssueStatusForm.patchValue({          

            issueStatusId: res.issueStatusId,
            name: res.name,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Issue Status';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.IssueStatusForm = this.fb.group({
      issueStatusId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.IssueStatusForm.get('issueStatusId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.IssueStatusService.update(+id,this.IssueStatusForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/issuestatus-list');
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
      this.IssueStatusService.submit(this.IssueStatusForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/issuestatus-list');
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

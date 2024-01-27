import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FiscalYearService } from '../../service/FiscalYear.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-fiscalYear',
  templateUrl: './new-fiscalYear.component.html',
  styleUrls: ['./new-fiscalYear.component.sass']
})
export class NewFiscalYearComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  FiscalYearForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private FiscalYearService: FiscalYearService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('fiscalYearId'); 
    if (id) {
      this.pageTitle = 'Edit FiscalYear';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.FiscalYearService.find(+id).subscribe(
        res => {
          this.FiscalYearForm.patchValue({          
           
            fiscalYearId: res.fiscalYearId,
          fiscalYearName: res.fiscalYearName,
          shortName:res.shortName,
          menuPosition:res.menuPosition,
          isActive:res.isActive
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create FiscalYear';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.FiscalYearForm = this.fb.group({
      fiscalYearId: [0],
      fiscalYearName: ['', Validators.required],
      shortName: [''],
      menuPosition:[],
      isActive: [true],
      status:[true]
    })
  }
  
  onSubmit() {
    const id = this.FiscalYearForm.get('fiscalYearId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.FiscalYearService.update(+id,this.FiscalYearForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/fiscalyear-list');
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
      this.FiscalYearService.submit(this.FiscalYearForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/fiscalyear-list');
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { OccasionOfDemandService } from '../../service/occasionOfDemand.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Component({
  selector: 'app-new-occasionofdemand',
  templateUrl: './new-occasionofdemand.component.html',
  styleUrls: ['./new-occasionofdemand.component.sass']
})
export class NewOccasionOfDemandComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  OccasionOfDemandForm: FormGroup;
  validationErrors: string[] = [];
  selectedFiscalYear: SelectedModel[];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private OccasionOfDemandService: OccasionOfDemandService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('occasionOfDemandId'); 
    if (id) {
      this.pageTitle = 'Edit Occasion Of Demand';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.OccasionOfDemandService.find(+id).subscribe(
        res => {
          this.OccasionOfDemandForm.patchValue({          

            occasionOfDemandId: res.occasionOfDemandId,
            name: res.name,
            fiscalYearId:res.fiscalYearId,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Occasion Of Demand';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    this.getSelectedFiscalYear();
  }
  intitializeForm() {
    this.OccasionOfDemandForm = this.fb.group({
      occasionOfDemandId: [0],
      name: ['', Validators.required],
      fiscalYearId:[],
      remarks: [''],
      isActive: [true],
    
    })
  }
  getSelectedFiscalYear() {
    this.OccasionOfDemandService.getSelectedFiscalYear().subscribe(res => {
      this.selectedFiscalYear = res;
    });
  }
  
  onSubmit() {
    const id = this.OccasionOfDemandForm.get('occasionOfDemandId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.OccasionOfDemandService.update(+id,this.OccasionOfDemandForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/occasionofdemand-list');
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
      this.OccasionOfDemandService.submit(this.OccasionOfDemandForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/occasionofdemand-list');
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

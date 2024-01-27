import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SailorRankService } from '../../service/SailorRank.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-sailorrank',
  templateUrl: './new-sailorrank.component.html',
  styleUrls: ['./new-sailorrank.component.sass']
})
export class NewSailorRankComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  SailorRankForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private SailorRankService: SailorRankService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('sailorRankId'); 
    if (id) {
      this.pageTitle = 'Edit Sailor Rank';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.SailorRankService.find(+id).subscribe(
        res => {
          this.SailorRankForm.patchValue({          

            sailorRankId: res.sailorRankId,
            name: res.name
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Sailor Rank';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.SailorRankForm = this.fb.group({
      sailorRankId: [0],
      name: [''],
      isActive: [true]
    })
  }
  
  onSubmit() {
    const id = this.SailorRankForm.get('sailorRankId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.SailorRankService.update(+id,this.SailorRankForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/sailorrank-list');
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
      this.SailorRankService.submit(this.SailorRankForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/sailorrank-list');
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

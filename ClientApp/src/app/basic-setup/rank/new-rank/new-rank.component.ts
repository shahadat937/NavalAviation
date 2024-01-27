import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { RankService } from '../../service/rank.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-rank',
  templateUrl: './new-rank.component.html',
  styleUrls: ['./new-rank.component.sass']
})
export class NewRankComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  RankForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private RankService: RankService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('rankId'); 
    if (id) {
      this.pageTitle = 'Edit Rank';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.RankService.find(+id).subscribe(
        res => {
          this.RankForm.patchValue({          

            rankId: res.rankId,
            name: res.name,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Rank';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.RankForm = this.fb.group({
      rankId: [0],
      name: ['', Validators.required],
      remarks: [''],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.RankForm.get('rankId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.RankService.update(+id,this.RankForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/rank-list');
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
      this.RankService.submit(this.RankForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/rank-list');
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

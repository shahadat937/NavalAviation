import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MeaWorkShopService } from '../../service/MeaWorkShop.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-meaworkshop',
  templateUrl: './new-meaworkshop.component.html',
  styleUrls: ['./new-meaworkshop.component.sass']
})
export class NewMeaWorkShopComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  MeaWorkShopForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private MeaWorkShopService: MeaWorkShopService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('meaWorkShopId'); 
    if (id) {
      this.pageTitle = 'Edit Mea Work Shop';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.MeaWorkShopService.find(+id).subscribe(
        res => {
          this.MeaWorkShopForm.patchValue({          

            meaWorkShopId: res.meaWorkShopId,
            name: res.name,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Mea Work Shop';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.MeaWorkShopForm = this.fb.group({
      meaWorkShopId: [0],
      name: [''],
      remarks: [''],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.MeaWorkShopForm.get('meaWorkShopId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.MeaWorkShopService.update(+id,this.MeaWorkShopForm.value).subscribe(response => {
            this.router.navigateByUrl('/mea/meaworkshop-list');
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
      this.MeaWorkShopService.submit(this.MeaWorkShopForm.value).subscribe(response => {
        this.router.navigateByUrl('/mea/meaworkshop-list');
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

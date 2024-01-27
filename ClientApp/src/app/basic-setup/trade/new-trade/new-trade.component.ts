import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { TradeService } from '../../service/Trade.service';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-trade',
  templateUrl: './new-trade.component.html',
  styleUrls: ['./new-trade.component.sass']
})
export class NewTradeComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  TradeForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private TradeService: TradeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('tradeId'); 
    if (id) {
      this.pageTitle = 'Edit Trade';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.TradeService.find(+id).subscribe(
        res => {
          this.TradeForm.patchValue({          

            tradeId: res.tradeId,
            name: res.name,
            remarks: res.remarks,
            status: res.status,
            isActive: res.isActive
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create  Trade';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.TradeForm = this.fb.group({
      tradeId: [0],
      name: ['', Validators.required],
      remarks: [''],
      status: [true],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    const id = this.TradeForm.get('tradeId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.TradeService.update(+id,this.TradeForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/trade-list');
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
      this.TradeService.submit(this.TradeForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/trade-list');
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

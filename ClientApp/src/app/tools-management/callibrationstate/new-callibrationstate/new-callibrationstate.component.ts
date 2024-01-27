import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CallibrationStateService } from '../../service/CallibrationState.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { MasterData } from 'src/assets/data/master-data';

@Component({
  selector: 'app-new-callibrationstate',
  templateUrl: './new-callibrationstate.component.html',
  styleUrls: ['./new-callibrationstate.component.sass']
})
export class NewCallibrationStateComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  CallibrationStateForm: FormGroup;
  validationErrors: string[] = [];
  selectedDepartmentNames:SelectedModel[]; 
  selectedTrades:SelectedModel[]; 

  masterData = MasterData;
  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private CallibrationStateService: CallibrationStateService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('callibrationStateId');
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
  
    if (id) {
      this.pageTitle = 'Edit Callibration State';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.CallibrationStateService.find(+id).subscribe(
        res => {
          this.CallibrationStateForm.patchValue({          

            callibrationStateId: res.callibrationStateId,
            itemDetailId:res.itemDetailId,
            departmentNameId: res.departmentNameId,
            tradeId:res.tradeId,
            serNo:res.serNo,
            itemName:res.itemName,
            lastDateofCalibrated:res.lastDateofCalibrated,
            nextDueDate:res.nextDueDate,
            presentState: res.presentState,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Callibration State';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.CallibrationStateForm.get('departmentNameId').setValue(this.branchId);
      // this.onDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedTrades();
  }
  intitializeForm() {
    this.CallibrationStateForm = this.fb.group({
      callibrationStateId: [0],
      itemDetailId:[],
      departmentNameId:[],
      tradeId:[],
      serNo:[''],
      itemName:[''],
      lastDateofCalibrated:[''],
      nextDueDate:[''],
      presentState: [''],
      remarks: [''],
      isActive: [true],
    
    })
  }

  GetDepartmentNameById(baseNameId){    
    this.CallibrationStateService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentNames=res
      console.log(res)
    }); 
  }

  getselectedTrades(){
    this.CallibrationStateService.getselectedTrades().subscribe(res=>{
      this.selectedTrades=res
      console.log(this.selectedTrades);      
    });
  }
  
  onSubmit() {
    const id = this.CallibrationStateForm.get('callibrationStateId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.CallibrationStateService.update(+id,this.CallibrationStateForm.value).subscribe(response => {
            this.router.navigateByUrl('/tools-management/callibrationstate-list');
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
      this.CallibrationStateService.submit(this.CallibrationStateForm.value).subscribe(response => {
        this.router.navigateByUrl('/tools-management/callibrationstate-list');
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

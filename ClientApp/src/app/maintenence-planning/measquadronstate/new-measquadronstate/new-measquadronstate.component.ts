import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MeaSquadronStateService } from '../../service/MeaSquadronState.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-measquadronstate',
  templateUrl: './new-measquadronstate.component.html',
  styleUrls: ['./new-measquadronstate.component.sass']
})
export class NewMeaSquadronStateComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  MeaSquadronStateForm: FormGroup;
  validationErrors: string[] = [];
  selectedDepartmentNames:SelectedModel[]; 
  selectedPresentStates:SelectedModel[]; 
  
  masterData = MasterData;
  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private MeaSquadronStateService: MeaSquadronStateService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('meaSquadronStateId'); 
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
  
    if (id) {
      this.pageTitle = 'Edit MEA Squadron State';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.MeaSquadronStateService.find(+id).subscribe(
        res => {
          this.MeaSquadronStateForm.patchValue({          

            meaSquadronStateId: res.meaSquadronStateId,
            departmentNameId: res.departmentNameId,
            presentStateId:res.presentStateId,
            //serNo:res.serNo,
            workOrderReceived:res.workOrderReceived,
            workOrderDate:res.workOrderDate,
            workshopName: res.workshopName,
            remarks: res.remarks,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create MEA Squadron State';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.MeaSquadronStateForm.get('departmentNameId').setValue(this.branchId);
      // this.onDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedPresentStates();
  }
  intitializeForm() {
    this.MeaSquadronStateForm = this.fb.group({
      meaSquadronStateId: [0],
      departmentNameId:[],
      presentStateId:[],
      //serNo:[''],
      workOrderReceived:[''],
      workOrderDate:[''],
      workshopName: [''],
      remarks: [''],
      isActive: [true],
    
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.MeaSquadronStateService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentNames=res
      console.log(res)
    }); 
  }

  getselectedPresentStates(){
    this.MeaSquadronStateService.getselectedPresentStates().subscribe(res=>{
      this.selectedPresentStates=res
      console.log(this.selectedPresentStates);      
    });
  }
  
  onSubmit() {
    const id = this.MeaSquadronStateForm.get('meaSquadronStateId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.MeaSquadronStateService.update(+id,this.MeaSquadronStateForm.value).subscribe(response => {
            this.router.navigateByUrl('/maintenence-planning/measquadronstate-list');
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
      this.MeaSquadronStateService.submit(this.MeaSquadronStateForm.value).subscribe(response => {
        this.router.navigateByUrl('/maintenence-planning/measquadronstate-list');
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

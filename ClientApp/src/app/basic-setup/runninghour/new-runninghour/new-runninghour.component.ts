import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { RunningHourService } from '../../service/runningHour.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { RunningHour } from '../../models/runningHour';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-runninghour',
  templateUrl: './new-runninghour.component.html',
  styleUrls: ['./new-runninghour.component.sass']
})
export class NewRunningHourComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  RunningHourForm: FormGroup;
  validationErrors: string[] = [];
  selectedAirCraftName:SelectedModel[]; 
  selectedDepartmentName:SelectedModel[]; 
  runningHourList:RunningHour[];
  isShown: boolean = false ;
  masterData = MasterData;
  
  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  displayedColumns: string[] = ['ser', 'airCraftName', 'flightDate','flightTimeHr', 'flightTimeMin',  'actions'];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private RunningHourService: RunningHourService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('runningHourId'); 

     
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)


    if (id) {
      this.pageTitle = 'Edit Running Hour';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.RunningHourService.find(+id).subscribe(
        res => {
          this.RunningHourForm.patchValue({          

            runningHourId: res.runningHourId,
            airCraftNameId: res.airCraftNameId,
            flightDate: res.flightDate,
            flightTimeHr: res.flightTimeHr,
            flightTimeMin: res.flightTimeMin,
            departmentNameId: res.departmentNameId,
            remarks: res.remarks,
          
          });  
          this.onDepartmentSelectionChangeGetAirCraftName()     
        }
      );
    } else {
      this.pageTitle = 'Create Running Hour';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.RunningHourForm.get('departmentNameId').setValue(this.branchId);
      this.onDepartmentSelectionChangeGetAirCraftName();
    }
    //this.getselectedAirCraftName();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.RunningHourForm = this.fb.group({
      runningHourId: [0],
      airCraftNameId: [],
      flightDate: [''],
      flightTimeHr: [''],
      flightTimeMin: [''],
      departmentNameId: [],
      remarks: [''],
      isActive: [true],
    
    })
  }
  onRunningHourListByDepartmentAndAirCraftNameSelectionChange(dropdown){
    this.isShown=true;
    if(dropdown.isUserInput) {
      var departmentNameId =this.RunningHourForm.value['departmentNameId'];
      console.log(dropdown.source.value, departmentNameId);
      this.RunningHourService.getRunningHourListByDepartmentAndAirCraftName(dropdown.source.value,departmentNameId).subscribe(res=>{
        this.runningHourList=res
        console.log( this.runningHourList);
      });
    }
  }
  // getselectedAirCraftName(){
  //   this.RunningHourService.getselectedAirCraftName().subscribe(res=>{
  //     this.selectedAirCraftName=res
  //     console.log(this.selectedAirCraftName);      
  //   });
  // }
  onDepartmentSelectionChangeGetAirCraftName(){
    var departmentNameId =this.RunningHourForm.value['departmentNameId'];
    this.RunningHourService.getAirCraftNameByDepartmentId(departmentNameId).subscribe(res=>{
      this.selectedAirCraftName=res
      console.log(this.selectedAirCraftName);
    });
   }
  // getselectedDepartmentName(){
  //   this.RunningHourService.getselectedDepartmentName().subscribe(res=>{
  //     this.selectedDepartmentName=res
  //     console.log(this.selectedDepartmentName);      
  //   });
  // }
  GetDepartmentNameById(baseNameId){    
    this.RunningHourService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      // console.log(this.selectedDepartmentName)
    }); 
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.RunningHourForm.get('runningHourId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.RunningHourService.update(+id,this.RunningHourForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-runninghour');
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
      this.RunningHourService.submit(this.RunningHourForm.value).subscribe(response => {
       // this.router.navigateByUrl('/basic-setup/runninghour-list');
       this.reloadCurrentRoute();
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
  deleteItem(row) {
    const id = row.runningHourId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.RunningHourService.delete(id).subscribe(() => {
          //this.getRunningHours();
          this.reloadCurrentRoute();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
  }

}

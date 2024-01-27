import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AcStatusService } from '../../service/AcStatus.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AirCraftNameService } from '../../service/airCraftName.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-new-acstatus',
  templateUrl: './new-acstatus.component.html',
  styleUrls: ['./new-acstatus.component.sass']
})
export class NewAcStatusComponent implements OnInit {
  pageTitle: string;
  destination:string;
  masterData = MasterData;
  role:any;
  userRole = Role;
  branchId:any;
  btnText:string;
  AcStatusForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 
  departmentName:SelectedModel[]; 
  selectedAirCraftName:SelectedModel[]; 
  statusValue:SelectedModel[]; 
  isShown: boolean = false ;
  acAstatusList:any;

  traineeId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'aircraftName', 'status','excepRelease','upcomingMaint','plannedDate','requiredDays','remarks','aircraftStatus', 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private AirCraftNameService: AirCraftNameService,private confirmService: ConfirmService,private AcStatusService: AcStatusService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('acStatusId'); 
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
    if (id) {
      this.pageTitle = 'Edit Aircraft Status';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.AcStatusService.find(+id).subscribe(
        res => {
          this.AcStatusForm.patchValue({          

            acStatusId: res.acStatusId,
            airCraftNameId: res.airCraftNameId,
            departmentNameId:res.departmentNameId,
            statusId: res.statusId,
            excepRelease:res.excepRelease,
            upcomingMaint: res.upcomingMaint,
            plannedDate:res.plannedDate,
            requiredDays: res.requiredDays,
            remarks:res.remarks,
          });
          this.onDepartmentSelectionChangeGetAirCraftName()          
        }
      );
    } else {
      this.pageTitle = 'Create Aircraft Status';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.AcStatusForm.get('departmentNameId').setValue(this.branchId);
      this.onAcStatusListByDepartmentNameSelectionChange();
      //this.onDepartmentSelectionChangeGetAirCraftName();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getStatus()
  }
  intitializeForm() {
    this.AcStatusForm = this.fb.group({
      acStatusId: [0],
      airCraftNameId: [''],
      departmentNameId: [''],
      statusId: [],
      excepRelease: [''],
      upcomingMaint: [''],
      plannedDate: [''],
      requiredDays: [''],
      remarks: [''],
      isActive:[true]
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.AcStatusService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
    }); 
  }
  getStatus(){    
    this.AcStatusService.getStatus().subscribe(res=>{
      this.statusValue=res
      console.log("status value");
      console.log(this.statusValue);
    }); 
  }
  onDepartmentSelectionChangeGetAirCraftName() {
    var departmentNameId =this.AcStatusForm.value['departmentNameId'];
    console.log(departmentNameId)
    this.AcStatusService.getAirCraftNameByDepartmentIdForStatus(departmentNameId).subscribe(res => {
      this.selectedAirCraftName = res
      console.log(this.selectedAirCraftName);
    });
  }
  onAcStatusListByDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.AcStatusForm.value['departmentNameId'];
    console.log(departmentNameId);
      this.AcStatusService.getAcStatusesByDepartment(departmentNameId).subscribe(res=>{
        this.acAstatusList=res
        console.log(this.acAstatusList);
        console.log("acAstatusList");
        // this gives an object with dates as keys
        this.onDepartmentSelectionChangeGetAirCraftName();
      });
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    //this.getAcStatuses();
  }
  underMaintAircraft(element) {
    console.log(element);
    this.confirmService.confirm('Confirm Stop message', 'Are You Sure Change This Item?').subscribe(result => {
      if (result) {
        this.AirCraftNameService.underMaintAircraft(element.acStatusId).subscribe(() => {
          this.onAcStatusListByDepartmentNameSelectionChange();
          this.snackBar.open('Information UnderMaint Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
        // this.AirCraftNameService.operationalAircraft(element.airCraftNameId).subscribe(() => {
        //   this.getAcStatuses();
        //   this.snackBar.open('Information Operational Successfully ', '', {
        //     duration: 3000,
        //     verticalPosition: 'bottom',
        //     horizontalPosition: 'right',
        //     panelClass: 'snackbar-warning'
        //   });
        // })
      }
      
    })
    
  }
  //UnderMaint Aircraft
  underMaintAircraft1(element) {
  this.confirmService.confirm('Confirm Stop message', 'Are You Sure UnderMaint This Item?').subscribe(result => {
    if (result) {
      this.AirCraftNameService.underMaintAircraft(element.courseDurationId).subscribe(() => {


          // this.AirCraftNameService.getInterServiceCourseByParameters(this.courseNameId, this.organizationNameId).subscribe(res => {
          //   this.interServiceList = res;
          //   console.log(this.interServiceList);
          // });
        
        this.snackBar.open('Information UnderMaint Successfully ', '', {
          duration: 3000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-warning'
        });
      })
    }
    
  })
  
}
//Operational  aircraft 
operationalAircraft(element) {
  this.confirmService.confirm('Confirm Stop message', 'Are You Sure Operational This Item?').subscribe(result => {
    if (result) {
      this.AirCraftNameService.operationalAircraft(element.courseDurationId).subscribe(() => {

        

          // this.CourseDurationService.getInterServiceCourseByParameters(this.courseNameId,this.organizationNameId).subscribe(res => {
          //   this.interServiceList = res;
          //   console.log(this.interServiceList);
          // });
        
        this.snackBar.open('Information Operational Successfully ', '', {
          duration: 3000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-warning'
        });
      })
    }
  })
}
reloadCurrentRoute() {
  let currentUrl = this.router.url;
  this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
    this.router.navigate([currentUrl]);
  });
}
  onSubmit() {
    const id = this.AcStatusForm.get('acStatusId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.AcStatusService.update(+id,this.AcStatusForm.value).subscribe(response => {
            this.router.navigateByUrl('/admin/dashboard/add-acstatus');
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
      this.AcStatusService.submit(this.AcStatusForm.value).subscribe(response => {
        //this.router.navigateByUrl('/admin/dashboard/acstatus-list'); //admin/dashboard/add-acstatus
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
    const id = row.acStatusId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.AcStatusService.delete(id).subscribe(() => {
          //this.getAcStatuses();
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

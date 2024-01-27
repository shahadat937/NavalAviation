import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AirCraftFlyingService } from '../../service/AirCraftFlying.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { AirCraftFlying } from '../../models/AirCraftFlying';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
//import { PickerInteractionMode } from 'igniteui-angular';

@Component({
  selector: 'app-new-aircraftflyingdelay',
  templateUrl: './new-aircraftflyingdelay.component.html',
  styleUrls: ['./new-aircraftflyingdelay.component.sass']
})
export class NewAircraftFlyingDelayComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  AirCraftFlyingForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel: SelectedModel[];
  selectedAirCraftName: SelectedModel[];
  selectedDepartmentName: SelectedModel[];
  airCraftFlyingList:AirCraftFlying[];
  isShown: boolean = false ;
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  displayedColumns: string[] = ['ser',  'airCraftName', 'date', 'crew', 'startUp', 'dup', 'endurance',  'actions'];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  constructor(private snackBar: MatSnackBar,private authService: AuthService, private confirmService: ConfirmService, private AirCraftFlyingService: AirCraftFlyingService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('airCraftFlyingId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'AC Flying Delay';
      this.destination = "Edit";
      this.btnText = 'Save';
      this.AirCraftFlyingService.find(+id).subscribe(
        res => {
          this.AirCraftFlyingForm.patchValue({

            airCraftFlyingId: res.airCraftFlyingId,
            // airCraftNameId: res.airCraftNameId,
            // departmentNameId: res.departmentNameId,
            // date: res.date,
            // typeOfAC: res.typeOfAC,
            // acNo: res.acNo,
            // crew: res.crew,
            // callSign: res.callSign,
            // mon: res.mon,
           // startUp: res.startUp,
            // dup: res.dup,
            // endurance: res.endurance,
            // fuel: res.fuel,
            // opaOff: res.opaOff,
            // pdf: res.pdf,
            // startUpStatus:res.startUpStatus,
            // remarks: res.remarks
            startUpDelay:res.startUpDelay
          });
          this.onDepartmentSelectionChangeGetAirCraftName()
        }
      );
    } else {
      this.pageTitle = 'Create AC Flying Program';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.AirCraftFlyingForm.get('departmentNameId').setValue(this.branchId);
      this.onDepartmentSelectionChangeGetAirCraftName();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.AirCraftFlyingForm = this.fb.group({
      airCraftFlyingId: [0],
      // airCraftNameId: [],
      // departmentNameId: [],
      // date: [''],
      // typeOfAC: [''],
      // acNo: [''],
      // crew: [''],
      // callSign: [''],
      // mon: [''],
      startUpDelay: [''],
    //  startUp: [''],
      // dup: [''],
      // endurance: [''],
      // startUpStatus:[0],
      // fuel: [''],
      // opaOff: [''],
      // pdf: [''],
      // remarks: [''],
      // isActive: [true]

    })
  }
  onAirCraftFlyingListByDepartmentNameSelectionChange(dropdown){
    this.isShown=true;
    if(dropdown.isUserInput) {
      var departmentNameId =this.AirCraftFlyingForm.value['departmentNameId'];
      console.log(dropdown.source.value, departmentNameId);
      this.AirCraftFlyingService.getAirCraftFlyingListByDepartmentName(dropdown.source.value,departmentNameId).subscribe(res=>{
        this.airCraftFlyingList=res
        console.log( this.airCraftFlyingList);
      });
    }
  }
  onDepartmentSelectionChangeGetAirCraftName() {
    var departmentNameId =this.AirCraftFlyingForm.value['departmentNameId'];
    console.log(departmentNameId)
    this.AirCraftFlyingService.getAirCraftNameByDepartmentId(departmentNameId).subscribe(res => {
      this.selectedAirCraftName = res
      console.log(this.selectedAirCraftName);
    });
  }
  GetDepartmentNameById(baseNameId){    
    this.AirCraftFlyingService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      console.log(res)
    }); 
  }
  // getselectedDepartmentName() {
  //   this.AirCraftFlyingService.getselectedDepartmentName().subscribe(res => {
  //     this.selectedDepartmentName = res
  //     console.log(this.selectedDepartmentName);
  //   });
  // }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.AirCraftFlyingForm.get('airCraftFlyingId').value;
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {

        if (result) {
          this.AirCraftFlyingService.updateAircraftFlyingDelay(+id, this.AirCraftFlyingForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-aircraftflying');
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
      this.AirCraftFlyingService.submit(this.AirCraftFlyingForm.value).subscribe(response => {
        //this.router.navigateByUrl('/basic-setup/aircraftflying-list');
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
    const id = row.airCraftFlyingId;
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.AirCraftFlyingService.delete(id).subscribe(() => {
          //this.getAirCraftFlyings();
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

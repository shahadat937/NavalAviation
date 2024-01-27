import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AirCraftNameService } from '../../service/airCraftName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { AirCraftName } from '../../models/airCraftName';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-aircraftname',
  templateUrl: './new-aircraftname.component.html',
  styleUrls: ['./new-aircraftname.component.sass']
})
export class NewAirCraftNameComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  AirCraftNameForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  public files: any[];
  airCraftNameList:AirCraftName[];
  isShown: boolean = false ;
  masterData = MasterData;
  
  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'image', 'name', 'overallLength','wingSpan', 'height', 'maxRange' , 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private AirCraftNameService: AirCraftNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('airCraftNameId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

   // console.log("hhhhh")
    //console.log(id)
    if (id) {
      this.pageTitle = 'Edit Air Craft Name';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.AirCraftNameService.find(+id).subscribe(
        res => {
          this.AirCraftNameForm.patchValue({          

            airCraftNameId: res.airCraftNameId,
            departmentNameId:res.departmentNameId,
            name: res.name,
            image:res.image,
            overallLength: res.overallLength,
            wingSpan: res.wingSpan,
            height: res.height,
            maxRange: res.maxRange,
            endurance: res.endurance,
            maxTakeoffAndLandingWt: res.maxTakeoffAndLandingWt,
            basicOperatingWt: res.basicOperatingWt,
            cruisingSpeed: res.cruisingSpeed,
            fuelCapacity: res.fuelCapacity,
            crew: res.crew,
            madeBy: res.madeBy,
            manufacturer: res.manufacturer,
            aircraftStatus: res.aircraftStatus,
            manufacturerMobile: res.manufacturerMobile,
            email: res.email,
            remarks: res.remarks,
          
          });
          //console.log("nnnnnn")     
         // console.log(res)    
        }
      );
    } else {
      this.pageTitle = 'Create Air Craft Name';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.AirCraftNameForm.get('departmentNameId').setValue(this.branchId);
      this.onAirCraftNameListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.AirCraftNameForm = this.fb.group({
      airCraftNameId: [0],
      departmentNameId:[],
      name: [''],
      image:[''],
      photo:[''],
      overallLength: [''],
      wingSpan: [''],
      height: [''],
      maxRange: [''],
      endurance: [''],
      maxTakeoffAndLandingWt: [''],
      basicOperatingWt: [''],
      cruisingSpeed: [''],
      fuelCapacity: [''],
      crew: [''],
      madeBy: [''],
      manufacturer: [''],
      manufacturerMobile: [''],
      aircraftStatus: [1],
      email: [''],
      remarks: [''],
      isActive: [true],
    
    })
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log('dddd')
     console.log(file);
      this.AirCraftNameForm.patchValue({
        photo: file,
      });
    }
  }
  onAirCraftNameListByDepartmentNameSelectionChange(){
    this.isShown=true;
      var departmentNameId =this.AirCraftNameForm.value['departmentNameId'];
      console.log(departmentNameId);
      this.AirCraftNameService.getAirCraftNameListByDepartmentName(departmentNameId).subscribe(res=>{
        this.airCraftNameList=res
        console.log( this.airCraftNameList);
      });
  }
  // getDepartmentName(){
  //   this.AirCraftNameService.getselectedDepartmentNames().subscribe(res=>{
  //     this.departmentName=res
  //     console.log(this.departmentName);
  //   });
  // }
  GetDepartmentNameById(baseNameId){    
    this.AirCraftNameService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("rrrrrrrrrrr");
      console.log(res)
    }); 
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.AirCraftNameForm.get('airCraftNameId').value;   
    console.log(this.AirCraftNameForm.value)
    const formData = new FormData();
    for (const key of Object.keys(this.AirCraftNameForm.value)) {
      const value = this.AirCraftNameForm.value[key];
      formData.append(key, value);
    }
    console.log(formData)
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
         console.log(result)
        if (result) {
          this.AirCraftNameService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-aircraftname');
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
      this.AirCraftNameService.submit(formData).subscribe(response => {
        console.log(this.AirCraftNameForm)
        //this.router.navigateByUrl('/basic-setup/aircraftname-list');
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
    const id = row.airCraftNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.AirCraftNameService.delete(id).subscribe(() => {
          //this.getAirCraftNames();
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

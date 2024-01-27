import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { EquipmentNameService } from '../../service/EquipmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { EquipmentName } from '../../models/EquipmentName';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-equipmentname',
  templateUrl: './new-equipmentname.component.html',
  styleUrls: ['./new-equipmentname.component.sass']
})
export class NewEquipmentNameComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  EquipmentNameForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  public files: any[];
  equipmentNameList:EquipmentName[];
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

  displayedColumns: string[] = [ 'ser', 'departmentName', 'name', 'remarks' , 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService, private confirmService: ConfirmService,private EquipmentNameService: EquipmentNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('equipmentNameId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Equipment Name';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.EquipmentNameService.find(+id).subscribe(
        res => {
          this.EquipmentNameForm.patchValue({          

            equipmentNameId: res.equipmentNameId,
            departmentNameId:res.departmentNameId,
            sparesCategoryId:res.sparesCategoryId,
            name: res.name,
            remarks: res.remarks
          
          });  
        }
      );
    } else {
      this.pageTitle = 'Create Equipment Name';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.EquipmentNameForm.get('departmentNameId').setValue(this.branchId);
      this.onEquipmentNameListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.EquipmentNameForm = this.fb.group({
      equipmentNameId: [0],
      departmentNameId:[],
      sparesCategoryId:[1],
      name:[''],
      remarks: [''],
      isActive: [true]
    
    })
  }
  // onFileChanged(event) {
  //   if (event.target.files.length > 0) {
  //     const file = event.target.files[0];
  //     console.log('dddd')
  //    console.log(file);
  //     this.AirCraftNameForm.patchValue({
  //       photo: file,
  //     });
  //   }
  // }
  onEquipmentNameListByDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.EquipmentNameForm.value['departmentNameId'];
      this.EquipmentNameService.getEquipmentNameListByDepartmentName(departmentNameId).subscribe(res=>{
        this.equipmentNameList=res
        console.log( this.equipmentNameList);
      });
  }
  // getDepartmentName(){
  //   this.EquipmentNameService.getselectedDepartmentNames().subscribe(res=>{
  //     this.departmentName=res
  //     //console.log(this.departmentName);
  //   });
  // }
  GetDepartmentNameById(baseNameId){    
    this.EquipmentNameService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
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
    const id = this.EquipmentNameForm.get('equipmentNameId').value;   
    //console.log(this.EquipmentNameForm.value)
    //const formData = new FormData();
    //for (const key of Object.keys(this.EquipmentNameForm.value)) {
      //const value = this.EquipmentNameForm.value[key];
      //formData.append(key, value);
    //}
    //console.log(formData)
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
         console.log(result)
        if (result) {
          this.EquipmentNameService.update(+id,this.EquipmentNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-equipmentname');
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
      this.EquipmentNameService.submit(this.EquipmentNameForm.value).subscribe(response => {
        console.log(this.EquipmentNameForm)
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
    const id = row.equipmentNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.EquipmentNameService.delete(id).subscribe(() => {
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

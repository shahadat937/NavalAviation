import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { GseItemNameService } from '../../service/GseItemName.service';
import { DepartmentNameService } from '../../service/DepartmentName.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectionModel } from '@angular/cdk/collections';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-gseitemname',
  templateUrl: './new-gseitemname.component.html',
  styleUrls: ['./new-gseitemname.component.sass']
})
export class NewGseItemNameComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  GseItemNameForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  GseItemNameScheduleName: SelectedModel[];
  masterData = MasterData;

  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private DepartmentNameService: DepartmentNameService,private confirmService: ConfirmService,private GseItemNameService: GseItemNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('gseItemNameId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Gse Item Name';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.GseItemNameService.find(+id).subscribe(
        res => {
          this.GseItemNameForm.patchValue({          

            gseItemNameId: res.gseItemNameId,        
            itemName: res.itemName,
            remarks: res.remarks,
            departmentNameId: res.departmentNameId,
            isActive: res.isActive,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Gse Item Name';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.GseItemNameForm.get('departmentNameId').setValue(this.branchId);
      // this.onEquipmentNameListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.GseItemNameForm = this.fb.group({
      gseItemNameId: [0],
      itemName: [''],
      remarks: [''],
      departmentNameId: [],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }

  // getDepartmentName(){
  //   this.DepartmentNameService.getselectedDepertments().subscribe(res=>{
  //     this.departmentName=res
  //     console.log(this.departmentName);
  //   });
  // }

  GetDepartmentNameById(baseNameId){    
    this.DepartmentNameService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log(res)
    }); 
  }

  
  onSubmit() {
    const id = this.GseItemNameForm.get('gseItemNameId').value;   
    console.log(this.GseItemNameForm.value )
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.GseItemNameService.update(+id,this.GseItemNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/gseitemname-list');
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
      this.GseItemNameService.submit(this.GseItemNameForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/gseitemname-list');
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

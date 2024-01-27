import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { DailyAirworthinessFromCategoryService } from '../../service/DailyAirworthinessFromCategory.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { DailyAirworthinessFromCategory } from '../../models/DailyAirworthinessFromCategory';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-dailyairworthinessfromcategory',
  templateUrl: './new-dailyairworthinessfromcategory.component.html',
  styleUrls: ['./new-dailyairworthinessfromcategory.component.sass']
})
export class NewDailyAirworthinessFromCategoryComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  DailyAirworthinessFromCategoryForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  public files: any[];
  dailyAirworthinessFromCategoryList:DailyAirworthinessFromCategory[];
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
  constructor(private snackBar: MatSnackBar,private authService: AuthService, private confirmService: ConfirmService,private DailyAirworthinessFromCategoryService: DailyAirworthinessFromCategoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('dailyAirworthinessFromCategoryId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Daily Airworthiness Form Category';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.DailyAirworthinessFromCategoryService.find(+id).subscribe(
        res => {
          this.DailyAirworthinessFromCategoryForm.patchValue({          

            dailyAirworthinessFromCategoryId: res.dailyAirworthinessFromCategoryId,
            departmentNameId:res.departmentNameId,
            name: res.name,
            remarks: res.remarks
          
          });  
        }
      );
    } else {
      this.pageTitle = 'Create Daily Airworthiness Form Category';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.DailyAirworthinessFromCategoryForm.get('departmentNameId').setValue(this.branchId);
      this.onDailyAirworthinessFromCategoryListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.DailyAirworthinessFromCategoryForm = this.fb.group({
      dailyAirworthinessFromCategoryId: [0],
      departmentNameId:[],
      name:[''],
      remarks: [''],
      isActive: [true]
    
    })
  }
  onDailyAirworthinessFromCategoryListByDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.DailyAirworthinessFromCategoryForm.value['departmentNameId'];
      this.DailyAirworthinessFromCategoryService.getDailyAirworthinessFromCategoryListByDepartmentName(departmentNameId).subscribe(res=>{
        this.dailyAirworthinessFromCategoryList=res
        console.log( this.dailyAirworthinessFromCategoryList);
      });
  }
  GetDepartmentNameById(baseNameId){    
    this.DailyAirworthinessFromCategoryService.getSelectedSchoolName(baseNameId).subscribe(res=>{
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
    const id = this.DailyAirworthinessFromCategoryForm.get('dailyAirworthinessFromCategoryId').value; 
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
         console.log(result)
        if (result) {
          this.DailyAirworthinessFromCategoryService.update(+id,this.DailyAirworthinessFromCategoryForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-dailyairworthinessfromcategory');
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
      this.DailyAirworthinessFromCategoryService.submit(this.DailyAirworthinessFromCategoryForm.value).subscribe(response => {
        console.log(this.DailyAirworthinessFromCategoryForm)
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
    const id = row.dailyAirworthinessFromCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.DailyAirworthinessFromCategoryService.delete(id).subscribe(() => {
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

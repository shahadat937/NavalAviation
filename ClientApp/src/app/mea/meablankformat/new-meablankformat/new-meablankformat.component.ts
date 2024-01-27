import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import {MeaBlankFormatService } from '../../service/MeaBlankFormat.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MeaBlankFormat } from '../../models/MeaBlankFormat';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-meablankformat',
  templateUrl: './new-meablankformat.component.html',
  styleUrls: ['./new-meablankformat.component.sass']
})
export class NewMeaBlankFormatComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  MeaBlankFormatForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  aircraftName: SelectedModel[];
  degitalDocType:SelectedModel[];
  files: any[];
  itemDetailId:any;
  //degitalArchieveList:DegitalArchieve[];
  isShown: boolean = false ;
  isCoHide: boolean = true ;
  masterData = MasterData;
  itemCategoryId:any;
  userRole = Role;

  groupArrays: { departmentName: string; datas: any }[];
  
  traineeId:any;
  role:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'departmentName', 'aircraftName', 'degitalArchieveDocType','name', 'dateOfLastRev', 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService, private confirmService: ConfirmService,private MeaBlankFormatService:MeaBlankFormatService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('meaBlankFormatId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = ' Mea Blank Format';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.MeaBlankFormatService.find(+id).subscribe(
        res => {
          this.MeaBlankFormatForm.patchValue({          

            meaBlankFormatId: res.meaBlankFormatId,
            name:res.name,
            doc:res.doc,
            remarks:res.remarks,
            //menuPosition: res.menuPosition
          
          });  
        }
      );
    } else {
      this.pageTitle = ' Mea Blank Format';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin && this.role != this.userRole.CO){
      this.MeaBlankFormatForm.get('departmentNameId').setValue(this.branchId);
      //this.onDegitalArchieveListByDepartmentNameSelectionChange();    
    }
    // if(this.role == this.userRole.CO){
    //   this.isCoHide = false;
    //   this.MeaBlankFormatForm.get('departmentNameId').setValue(0);
    //   //this.onDegitalArchieveListByDepartmentNameSelectionChange();    
    // }
    //this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    
  }
  intitializeForm() {
    this.MeaBlankFormatForm = this.fb.group({
      meaBlankFormatId: [0],
      name:[],
      doc:[''],
      document:[''],
      remarks:[],
      isActive: [true]
    
    })
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      this.MeaBlankFormatForm.patchValue({
        document: file,
      });
    }
  }
  // onDegitalArchieveListByDepartmentNameSelectionChange(){
  //   this.isShown=true;
  //   var departmentNameId =this.MeaBlankFormatForm.value['departmentNameId'];
  //   console.log(departmentNameId);
  //     this.MeaBlankFormatService.getDegitalArchieveListByDepartmentName(departmentNameId).subscribe(res=>{
  //       this.MeaBlankFormatList=res
  //       console.log( this.MeaBlankFormatList);
  //       // this gives an object with dates as keys
  //     const groups = this.MeaBlankFormatList.reduce((groups, datas) => {
  //       const departmentName = datas.departmentName;
  //       if (!groups[departmentName]) {
  //         groups[departmentName] = [];
  //       }
  //       groups[departmentName].push(datas);
  //       return groups;
  //     }, {});

  //     // Edit: to add it in the array format instead
  //     this.groupArrays = Object.keys(groups).map((departmentName) => {
  //       return {
  //         departmentName,
  //         datas: groups[departmentName],
  //       };
  //     });

  //     console.log(this.groupArrays);   

  //       this.getselecteAircraft();
  //     });
  // }
  
  // getselecteDegitalDocType(){    
  //   this.MeaBlankFormatService.getselecteDegitalDocType().subscribe(res=>{
  //     this.degitalDocType=res
  //     console.log(res)
  //   }); 
  // }
  
  
  // GetDepartmentNameById(baseNameId){    
  //   this.MeaBlankFormatService.getSelectedSchoolName(baseNameId).subscribe(res=>{
  //     this.departmentName=res
  //     console.log(res)
  //   }); 
  // }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.MeaBlankFormatForm.get('meaBlankFormatId').value;   
    console.log(this.MeaBlankFormatForm)
    // this.MeaBlankFormatForm.get("dateOfLastRev").setValue(
    //   new Date(this.MeaBlankFormatForm.get("dateOfLastRev").value).toUTCString()
    // );

    console.log(this.MeaBlankFormatForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.MeaBlankFormatForm.value)) {
      const value = this.MeaBlankFormatForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
         console.log(result)
        if (result) {
          this.MeaBlankFormatService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/mea/meablankformat-list');
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
      this.MeaBlankFormatService.submit(formData).subscribe(response => {
        console.log(this.MeaBlankFormatForm)
        //this.reloadCurrentRoute();
        this.router.navigateByUrl('/mea/meablankformat-list');
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
  // deleteItem(row) {
  //   const id = row.degitalArchieveId; 
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
  //     console.log(result);
  //     if (result) {
  //       this.MeaBlankFormatService.delete(id).subscribe(() => {
  //         this.reloadCurrentRoute();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 2000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })
  // }

}

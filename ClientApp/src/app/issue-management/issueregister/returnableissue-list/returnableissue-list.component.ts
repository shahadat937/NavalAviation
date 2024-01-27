import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { IssueRegisterService } from '../../service/IssueRegister.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { DepartmentNameService } from 'src/app/basic-setup/service/DepartmentName.service';
import { ItemStor } from 'src/app/spares-management/models/ItemStor';
import { ItemDetailService } from 'src/app/spares-management/service/itemDetail.service';
import { style } from '@angular/animations';
import { IssueRegister } from '../../models/IssueRegister';
import { MasterData } from 'src/assets/data/master-data';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-returnableissue-list',
  templateUrl: './returnableissue-list.component.html',
  styleUrls: ['./returnableissue-list.component.sass']
})
export class ReturnableIssueListComponent implements OnInit {
  pageTitle: string;
  destination:string;
  masterData = MasterData;
  btnText:string;
  IssueRegisterForm: FormGroup;
  validationErrors: string[] = [];
  selectedItemDetails:SelectedModel[]; 
  selectedIssueStatuses:SelectedModel[]; 
  selectedDepartmentNames:SelectedModel[];
  selectedSparesCategory:SelectedModel[];
  IssueRegisterList:IssueRegister[];
  isShown: boolean = false ;
  isDynamicFormShown:boolean=false;
  checked:boolean=false;
  message:string;
  titleColor:'#FF0000';
  itemName:string;
  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'partNO', 'itemName', 'issueStatusId','issueQty', 'issueDate','issuedTo', 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private itemDetailService:ItemDetailService,private departmentNameService:DepartmentNameService,private confirmService: ConfirmService,private IssueRegisterService: IssueRegisterService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
    
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.IssueRegisterForm.get('departmentNameId').setValue(this.branchId);
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedSparesCategory();
  }
  intitializeForm() {
    this.IssueRegisterForm = this.fb.group({
      issueRegisterId: [0],
      sparesCategoryId:[],
      departmentNameId:[],
      IssueRegisterList: this.fb.array([this.createIssueRegisterData()]),
    })
  }

  private createIssueRegisterData() {
    return this.fb.group({
      issueRegisterId: [],
      issueStatusId: [],
      itemStoreId: [],
      partNO: [""],
      itemName: [""],
      name:[""],
      pno:[""],
      issueQty: [],
      issueDate: [""],
      returnQty:[],
      returningQty:[],
      // completedDate:[],
      // endInspDate:[],
      // progressBar: [""],
      // completedStatus: [],
      // jobCard: [""],
      // doc: [""],
    });
  }

  getSelectedIssueRegisterList(){
    var departmentNameId =this.IssueRegisterForm.value['departmentNameId'];
    var sparesCategoryId =this.IssueRegisterForm.value['sparesCategoryId'];    
    this.IssueRegisterService.getIssueRegisterForTyList(departmentNameId,sparesCategoryId,2).subscribe(res=>{
      this.IssueRegisterList=res
      console.log(this.IssueRegisterList);
      console.log("Issue Register List");
      this.clearList();
      this.getItemStoreListonClick();
    });
    this.isShown=true;
  }

  getControlLabel(index: number, type: string) {
    return (this.IssueRegisterForm.get("IssueRegisterList") as FormArray).at(index).get(type).value;
  }

  getReturnableItems(index: number, issue: string, returnable: string) {
    
    var issueValue = (this.IssueRegisterForm.get("IssueRegisterList") as FormArray).at(index).get(issue).value;
    var returnValue = (this.IssueRegisterForm.get("IssueRegisterList") as FormArray).at(index).get(returnable).value;

    return issueValue - returnValue;
  }

  clearList() {
    const control = <FormArray>this.IssueRegisterForm.controls["IssueRegisterList"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  getItemStoreListonClick() {
    const control = <FormArray>this.IssueRegisterForm.controls["IssueRegisterList"];
    for (let i = 0; i < this.IssueRegisterList.length; i++) {
      control.push(this.createIssueRegisterData());
      console.log(this.IssueRegisterList)
      console.log(this.IssueRegisterList.length)
      console.log("List & Length")
    }

    this.IssueRegisterForm.patchValue({
      IssueRegisterList: this.IssueRegisterList,
    });
  }

  // getSelectedDepartment(){
  //   this.departmentNameService.getselectedDepertments().subscribe(res=>{
  //     this.selectedDepartmentNames=res
  //    // console.log(this.selectedDepartmentNames);      
  //   });
  // }
  GetDepartmentNameById(baseNameId){    
    this.departmentNameService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentNames=res
      console.log(res)
    }); 
  }
  getselectedSparesCategory(){
    this.IssueRegisterService.getselectedSparesCategoryForReturnableIssue().subscribe(res=>{
      this.selectedSparesCategory=res
      //console.log(this.selectedSparesCategory);      
    });
  }
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  onReturnButtonClick(event, data){
    const id = data.value.id;  
    console.log(data.value);

    this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
      if (result) {
        this.IssueRegisterService.returnIssueRegister(+id, data.value).subscribe(response => {
          this.reloadCurrentRoute();
        //  this.router.navigateByUrl('/spares-management/add-procurement');
          this.snackBar.open('Information Updated Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        }, error => {
          //this.validationErrors = error;
        }
        )
      }
    })
  }

}

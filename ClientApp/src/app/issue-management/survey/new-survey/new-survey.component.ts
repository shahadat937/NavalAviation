import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { SurveyService } from '../../service/Survey.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Survey } from '../../models/Survey';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { ItemDetailService } from 'src/app/spares-management/service/itemDetail.service';
import { IssueRegisterService } from 'src/app/issue-management/service/IssueRegister.service';

@Component({
  selector: 'app-new-survey',
  templateUrl: './new-survey.component.html',
  styleUrls: ['./new-survey.component.sass']
})
export class NewSurveyComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  SurveyForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  itemName: SelectedModel[];
  files: any[];
  itemDetailId:any;
  issueRegisterId:any;
  surveyList:Survey[];
  imcNumber:any;
  isShown: boolean = false ;
  masterData = MasterData;
  itemCategoryId:any;
  userRole = Role;
  
  options = [];
  filteredOptions;
  traineeId:any;
  role:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'departmentName', 'itemName', 'itemCategory','surveyNumber', 'surveyDate', 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private IssueRegisterService: IssueRegisterService, private ItemDetailService: ItemDetailService, private confirmService: ConfirmService,private SurveyService: SurveyService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('surveyId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Survey';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.SurveyService.find(+id).subscribe(
        res => {
          this.SurveyForm.patchValue({          

            surveyId: res.surveyId,
            departmentNameId:res.departmentNameId,
            issueRegisterId:res.issueRegisterId,
            itemDetailId:res.itemDetailId,
            itemCategoryId:res.itemCategoryId,
            surveyQty:res.surveyQty,
            issueQty: res.issueQty,
            surveyNumber: res.surveyNumber,
            surveyDate: res.surveyDate
          
          });  
        }
      );
    } else {
      this.pageTitle = 'Create Survey';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.SurveyForm.get('departmentNameId').setValue(this.branchId);
      this.onSurveyListByDepartmentNameSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.SurveyForm = this.fb.group({
      surveyId: [0],
      departmentNameId:[],
      issueRegisterId:[],
      itemDetailId:[],
      nameOfItem: [""],
      itemCategoryId:[],
      surveyQty:[],
      issueQty:[],
      surveyNumber:[''],
      surveyDate: [''],
      isActive: [true]
    
    })
    //autocomplete for nameOfItem
    this.SurveyForm.get("nameOfItem").valueChanges.subscribe((value) => {
      this.getSelectedItemDetailByPartNo(value);
    });
  }
  
  onSurveyListByDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.SurveyForm.value['departmentNameId'];
      this.SurveyService.getSurveyListByDepartmentName(departmentNameId).subscribe(res=>{
        this.surveyList=res
        console.log( this.surveyList);
        this.getItemNameByDepartmentName();
      });
  }
  onItemNameSelectionChange(){
    //var itemDetailId;
   var issueRegisterId= this.SurveyForm.value['issueRegisterId'];
   console.log(issueRegisterId);
  this.IssueRegisterService.find(issueRegisterId).subscribe((res) => {
        this.itemDetailId = res.itemDetailId; 
        var issueQty = res.issueQty;
        this.SurveyForm.get("itemDetailId").setValue(this.itemDetailId);
        this.SurveyForm.get("issueQty").setValue(issueQty);
        console.log(res);
        console.log("res1111");
          this.ItemDetailService.find(this.itemDetailId).subscribe((res) => {
        var itemCategoryId = res.itemCategoryId; 
        this.imcNumber = res.imcNumber; 
        console.log(res.imcNumber)
        console.log("imcNumber")
        this.SurveyForm.get("itemCategoryId").setValue(itemCategoryId);
       });
       });
     
  }
  //autocomplete for nameOfItem
  onPartNoSelectionChanged(item) {
    console.log(item.value);
    this.itemDetailId = item.value;
    this.issueRegisterId=item.value;
    this.SurveyForm.get("issueRegisterId").setValue(item.value);
    this.SurveyForm.get("nameOfItem").setValue(item.text);
    this.onItemNameSelectionChange();
  }
  //autocomplete for nameOfItem
  getSelectedItemDetailByPartNo(nameOfItem) {
    var departmentNameId = this.SurveyForm.value["departmentNameId"];
    this.SurveyService.getSelectedPartNoByNameByDepartmentId(nameOfItem,departmentNameId).subscribe(
      (response) => {
        this.options = response;
        this.filteredOptions = response;
      }
    );
  }
  getItemNameByDepartmentName(){
    var departmentNameId =this.SurveyForm.value['departmentNameId'];
      this.SurveyService.getItemNameByDepartmentName(departmentNameId).subscribe(res=>{
        this.itemName=res
        //this.itemNameValue=res
        console.log("ooo");
        console.log( this.itemName);
        var itemDetailId =this.SurveyForm.value['itemDetailId'];
        
      });
      
      //var itemDetailId = this.SurveyForm.value["itemDetailId"];
      // this.IssueRegisterService.find(itemDetailId).subscribe((res) => {
      //   //this.itemCategoryId = res.itemCategoryId;
      //   this.SurveyForm.get("demandTypeId").setValue(this.itemCategoryId);
      // });
  }
  // onIMCById(id: number) {
  //   console.log(id);
  //   this.ItemDetailService.find(id).subscribe(res => {
  //     console.log("res");
  //     console.log(res);
  //     //this.bookTitleEnglish = res.bookTitleEnglish;
    
  //   });
  // }
  
  GetDepartmentNameById(baseNameId){    
    this.SurveyService.getSelectedSchoolName(baseNameId).subscribe(res=>{
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
    const id = this.SurveyForm.get('surveyId').value;   
    console.log(this.SurveyForm.value)
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
          this.SurveyService.update(+id,this.SurveyForm.value).subscribe(response => {
            this.router.navigateByUrl('/issue-management/add-survey');
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
      this.SurveyService.submit(this.SurveyForm.value).subscribe(response => {
        console.log(this.SurveyForm)
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
    const id = row.surveyId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.SurveyService.delete(id).subscribe(() => {
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

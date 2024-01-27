import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import {DegitalArchieveService } from '../../service/DegitalArchieve.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { DegitalArchieve } from '../../models/DegitalArchieve';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { ItemDetailService } from 'src/app/spares-management/service/itemDetail.service';
import { IssueRegisterService } from 'src/app/issue-management/service/IssueRegister.service';

@Component({
  selector: 'app-new-degitalarchieve',
  templateUrl: './new-degitalarchieve.component.html',
  styleUrls: ['./new-degitalarchieve.component.sass']
})
export class NewDegitalArchieveComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  DegitalArchieveForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  aircraftName: SelectedModel[];
  degitalDocType:SelectedModel[];
  files: any[];
  itemDetailId:any;
  degitalArchieveList:DegitalArchieve[];
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
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private IssueRegisterService: IssueRegisterService, private ItemDetailService: ItemDetailService, private confirmService: ConfirmService,private DegitalArchieveService: DegitalArchieveService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('degitalArchieveId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = ' Digital Archieve';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.DegitalArchieveService.find(+id).subscribe(
        res => {
          this.DegitalArchieveForm.patchValue({          

            degitalArchieveId: res.degitalArchieveId,
            departmentNameId:res.departmentNameId,
            airCraftNameId:res.airCraftNameId,
            degitalArchieveDocTypeId:res.degitalArchieveDocTypeId,
            name:res.name,
            dateOfLastRev:res.dateOfLastRev,
            doc: res.doc,
            remarks: res.remarks,
            //menuPosition: res.menuPosition
          
          }); 
          this.getselecteAircraft(); 
        }
      );
    } else {
      this.pageTitle = ' Digital Archieve';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin && this.role != this.userRole.CO){
      this.DegitalArchieveForm.get('departmentNameId').setValue(this.branchId);
      this.onDegitalArchieveListByDepartmentNameSelectionChange();    
    }
    if(this.role == this.userRole.CO){
      this.isCoHide = false;
      this.DegitalArchieveForm.get('departmentNameId').setValue(0);
      this.onDegitalArchieveListByDepartmentNameSelectionChange();    
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    
    this.getselecteDegitalDocType();
  }
  intitializeForm() {
    this.DegitalArchieveForm = this.fb.group({
      degitalArchieveId: [0],
      departmentNameId:[],
      airCraftNameId:[],
      degitalArchieveDocTypeId:[],
      name:[''],
      dateOfLastRev:[],
      doc:[''],
      document:[''],
      remarks:[''],
      menuPosition: [''],
      isActive: [true]
    
    })
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      this.DegitalArchieveForm.patchValue({
        document: file,
      });
    }
  }
  onDegitalArchieveListByDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.DegitalArchieveForm.value['departmentNameId'];
    console.log(departmentNameId);
      this.DegitalArchieveService.getDegitalArchieveListByDepartmentName(departmentNameId).subscribe(res=>{
        this.degitalArchieveList=res
        console.log( this.degitalArchieveList);
        // this gives an object with dates as keys
      const groups = this.degitalArchieveList.reduce((groups, datas) => {
        const departmentName = datas.departmentName;
        if (!groups[departmentName]) {
          groups[departmentName] = [];
        }
        groups[departmentName].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          datas: groups[departmentName],
        };
      });

      console.log(this.groupArrays);   

        this.getselecteAircraft();
      });
  }
  getselecteAircraft(){    
    var departmentNameId =this.DegitalArchieveForm.value['departmentNameId'];
    this.DegitalArchieveService.getselecteAircraft(departmentNameId).subscribe(res=>{
      this.aircraftName=res
      console.log(res)
    }); 
  }
  getselecteDegitalDocType(){    
    this.DegitalArchieveService.getselecteDegitalDocType().subscribe(res=>{
      this.degitalDocType=res
      console.log(res)
    }); 
  }
  // onItemNameSelectionChange(){
  //   //var itemDetailId;
  //  var issueRegisterId= this.DegitalArchieveForm.value['issueRegisterId'];
  //  console.log(issueRegisterId);
  // this.IssueRegisterService.find(issueRegisterId).subscribe((res) => {
  //       this.itemDetailId = res.itemDetailId; 
  //       var issueQty = res.issueQty;
  //       this.DegitalArchieveForm.get("itemDetailId").setValue(this.itemDetailId);
  //       this.DegitalArchieveForm.get("issueQty").setValue(issueQty);
  //       console.log(res);
  //         this.ItemDetailService.find(this.itemDetailId).subscribe((res) => {
  //       var itemCategoryId = res.itemCategoryId; 
  //       this.DegitalArchieveForm.get("itemCategoryId").setValue(itemCategoryId);
  //      });
  //      });
     
  // }
  // getItemNameByDepartmentName(){
  //   var departmentNameId =this.DegitalArchieveForm.value['departmentNameId'];
  //     this.DegitalArchieveService.getItemNameByDepartmentName(departmentNameId).subscribe(res=>{
  //       this.itemName=res
  //       //this.itemNameValue=res
  //       console.log("ooo");
  //       console.log( this.itemName);
  //     });
  // }
  
  GetDepartmentNameById(baseNameId){    
    this.DegitalArchieveService.getSelectedSchoolName(baseNameId).subscribe(res=>{
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
    const id = this.DegitalArchieveForm.get('degitalArchieveId').value;   
    console.log(this.DegitalArchieveForm)
    this.DegitalArchieveForm.get("dateOfLastRev").setValue(
      new Date(this.DegitalArchieveForm.get("dateOfLastRev").value).toUTCString()
    );

    console.log(this.DegitalArchieveForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.DegitalArchieveForm.value)) {
      const value = this.DegitalArchieveForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
         console.log('Digital Archive',result)
        if (result) {
          this.DegitalArchieveService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/record-room/add-degitalarchieve');
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
      this.DegitalArchieveService.submit(formData).subscribe(response => {
        console.log(this.DegitalArchieveForm)
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
    const id = row.degitalArchieveId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.DegitalArchieveService.delete(id).subscribe(() => {
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

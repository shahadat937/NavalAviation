import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { RequiredSparesForMaintenanceService } from '../../service/RequiredSparesForMaintenance.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { RequiredSparesForMaintenance } from '../../models/RequiredSparesForMaintenance';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-new-requiredsparesformaintenance',
  templateUrl: './new-requiredsparesformaintenance.component.html',
  styleUrls: ['./new-requiredsparesformaintenance.component.sass']
})
export class NewRequiredSparesForMaintenanceComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  //sparesCategoryId:number;
  RequiredSparesForMaintenanceForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  sparesCategoryValue: SelectedModel[];
  maintenanceTypeValue: SelectedModel[];
  maintenanceCategoryValue: SelectedModel[];
  maintenanceSubCategoryValue: SelectedModel[];
  itemNamevalue: SelectedModel[];
  categoryvalue:any;
  public files: any[];
  requiredSparesForMaintenanceList:RequiredSparesForMaintenance[];
  isShown: boolean = false ;
  showView: boolean = true ;
  addStatus: boolean = false ;
  masterData = MasterData;
  showHideDiv=false;
  userRole = Role;
  name:any;
  totalResultCount:any;

  traineeId:any;
  role:any;
  branchId:any;
  itemDetailId:any;
  sparesCategoryId:any;
  itemType:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  options = [];
  filteredOptions;

  displayedColumns: string[] = [ 'ser', 'departmentName', 'nameOfItem', 'trade', 'presentStock', 'lineStock','nsdStock', 'purchaseQty', 'issuedQty', 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService, private confirmService: ConfirmService,private RequiredSparesForMaintenanceService: RequiredSparesForMaintenanceService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    var viewType = this.route.snapshot.paramMap.get('viewType');
    var departmentNameId = this.route.snapshot.paramMap.get('departmentNameId');
    var sparesCategoryId = this.route.snapshot.paramMap.get('sparesCategoryId');
    var maintenanceTypeId = this.route.snapshot.paramMap.get('maintenanceTypeId');
    var maintenanceCategoryId = this.route.snapshot.paramMap.get('maintenanceCategoryId');
    var maintenanceSubCategoryId = this.route.snapshot.paramMap.get('maintenanceSubCategoryId');


    const id = this.route.snapshot.paramMap.get('requiredSparesForMaintenanceId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Required Spares For Maintenance';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.RequiredSparesForMaintenanceService.find(+id).subscribe(
        res => {
          this.RequiredSparesForMaintenanceForm.patchValue({          

            requiredSparesForMaintenanceId: res.requiredSparesForMaintenanceId,
            departmentNameId:res.departmentNameId,
            sparesCategoryId:res.sparesCategoryId,
            maintenanceTypeId:res.maintenanceTypeId,
            maintenanceCategoryId:res.maintenanceCategoryId,
            maintenanceSubCategoryId:res.maintenanceSubCategoryId,
            itemDetailId:res.itemDetailId,
            remarks: res.remarks
          
          });  
          //this.GetDepartmentNameById(res.departmentNameId);
          this.getselectedMaintenanceTypes();
          this.getselectedMaintenanceCategory();
          this.getselectedMaintenanceSubCategory();
          this.onselecteditemNameandPattNo();
        }
      );
    } else {
      this.pageTitle = 'Create Required Spares For Maintenance';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();

    if(this.role != this.userRole.SuperAdmin && this.role != this.userRole.CO){
      this.RequiredSparesForMaintenanceForm.get('departmentNameId').setValue(this.branchId);
      
      //this.onRequiredSparesForMaintenanceListByDepartmentNameSelectionChange();
      //this.GetDepartmentNameById(this.branchId);
      this.getselectedMaintenanceTypes();
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedSparesCategory();
    // this.onselecteditemNameandPattNo();
    // this.getselectedMaintenanceTypes();
    // this.getselectedMaintenanceCategory();
    // this.getselectedMaintenanceSubCategory();

    if(viewType == '1'){
      this.showView = false;
      console.log(viewType,departmentNameId,sparesCategoryId,maintenanceTypeId,maintenanceCategoryId,maintenanceSubCategoryId)
      this.getRequireSparesList(departmentNameId,sparesCategoryId,maintenanceTypeId,maintenanceCategoryId,maintenanceSubCategoryId);
    }else{
      this.getProcessedData();
    }
  }
  intitializeForm() {
    this.RequiredSparesForMaintenanceForm = this.fb.group({
      requiredSparesForMaintenanceId: [0],
      departmentNameId:[],
      sparesCategoryId:[],
      part: [""],
      maintenanceTypeId:[],
      maintenanceCategoryId:[],
      maintenanceSubCategoryId:[],
      itemDetailId:[],
      remarks:[''],
      isActive: [true]    
    })
    //autocomplete
    this.RequiredSparesForMaintenanceForm.get("part").valueChanges.subscribe((value) => {
      this.getSelectedItemDetailByPartNo(value);
    });
  }
  addMode(){
    this.addStatus = true;
  }
  onStatus(dropdown) {
    if (dropdown.isUserInput) {
      this.itemType = dropdown.source.value;
      console.log(this.itemType);
    }
  }
  inActiveItem(row){
    const id = row.requiredSparesForMaintenanceId; 
          this.confirmService.confirm('Confirm Approved message', 'Are You Sure Approved This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.RequiredSparesForMaintenanceService.approvedRequiredSparesForMaintenance(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.reloadCurrentRoute();
            this.snackBar.open('Information Approved Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    
}
  getRequireSparesList(departmentNameId,sparesCategoryId,maintenanceTypeId,maintenanceCategoryId,maintenanceSubCategoryId){
    this.RequiredSparesForMaintenanceService.findRequirdSparesList(departmentNameId,sparesCategoryId,maintenanceTypeId,maintenanceCategoryId,maintenanceSubCategoryId).subscribe(res=>{
      this.requiredSparesForMaintenanceList=res
      console.log( this.requiredSparesForMaintenanceList);
      this.totalResultCount = res.length;
  
    });
   
  }

  getSelectedItemDetailByPartNo(pno) {
    var departmentNameId =this.RequiredSparesForMaintenanceForm.value['departmentNameId'];
    this.RequiredSparesForMaintenanceService.getSelectedPartNoByNameForSparesByDepartmentId(pno,departmentNameId).subscribe(
      (response) => {
        this.options = response;
        this.filteredOptions = response;
      }
    );
  }

   //autocomplete
   onTraineeSelectionChanged(item) {
    // console.log(item);
    this.itemDetailId = item.value;
    // this.itemCategoryId = item.value;
    this.RequiredSparesForMaintenanceForm.get("itemDetailId").setValue(item.value);
    this.RequiredSparesForMaintenanceForm.get("part").setValue(item.text);
    // this.getItemNameById(this.itemDetailId);
    // this.getPartNoPassItemCategoryIdInDemand(this.itemCategoryId);
    // console.log(item.value);
    // console.log("V");
    // this.itemDetailsService.find(this.itemDetailId).subscribe((res) => {
    //   this.DemandForm.get("itemCategoryId").setValue(res.itemCategoryId);
    //   console.log(res.itemCategoryId);
      
    // });
  }
  

  getProcessedData(){
    var findArr = this.RequiredSparesForMaintenanceForm.value;
    console.log(findArr);

    this.RequiredSparesForMaintenanceService.findRequirdSparesList(
      findArr.departmentNameId == null || findArr.departmentNameId == 'null' ? 0 : findArr.departmentNameId,
      findArr.sparesCategoryId == null ? 0 : findArr.sparesCategoryId,
      findArr.maintenanceTypeId == null ? 0 : findArr.maintenanceTypeId,
      findArr.maintenanceCategoryId == null ? 0 : findArr.maintenanceCategoryId,
      findArr.maintenanceSubCategoryId == null ? 0 : findArr.maintenanceSubCategoryId
    ).subscribe(res=>{
      this.requiredSparesForMaintenanceList=res
      console.log( this.requiredSparesForMaintenanceList);
      console.log("Data 22");
      this.totalResultCount = res.length;
    });
    
  }

  onGetMaintenanceTypeSelection(){
    this.getProcessedData();
    this.getselectedMaintenanceCategory();
  }

  onGetMaintenanceCategorySelection(){
    this.getProcessedData();
    this.getselectedMaintenanceSubCategory();
  }
  onGetMaintenanceSubCategorySelection(){
    this.getProcessedData();
  }
  GetDepartmentNameById(baseNameId){    
    this.RequiredSparesForMaintenanceService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      // this.getselectedMaintenanceTypes();
      this.departmentName=res
      console.log(res)
      console.log("Data 33");
    }); 
  
  }
  getselectedSparesCategory(){    
    this.RequiredSparesForMaintenanceService.getselectedSparesCategory().subscribe(res=>{
      this.sparesCategoryValue=res
      console.log(res)
      console.log("Spares Category")
      
    }); 
  
  }
  
  // getsparesCategoryId() {
  //   //console.log(id);
  //   var sparesCategoryId =this.RequiredSparesForMaintenanceForm.value['sparesCategoryId'];
  //   this.RequiredSparesForMaintenanceService.find(sparesCategoryId).subscribe(res => {
  //     console.log("res Spares Category");
  //     console.log(res);
  //     this.categoryvalue=res
  //     // this.bookTitleEnglish = res.bookTitleEnglish;
  //     // this.bookTitleBangla = res.bookTitleBangla;
  //     // this.countOnlineRequest = res.countOnlineRequest;
    
  //   });
  // }
  onselecteditemNameandPattNo(){   
    var departmentNameId =this.RequiredSparesForMaintenanceForm.value['departmentNameId'];
    var sparesCategoryId =this.RequiredSparesForMaintenanceForm.value['sparesCategoryId'];
    this.RequiredSparesForMaintenanceService.getselecteditemNameandPattNo(departmentNameId,sparesCategoryId).subscribe(res=>{
      // this.onfindRequirdSparesListByDepartmentNameSelectionChange();
      this.itemNamevalue=res
      //this.name = res.name;
      console.log(res)
      console.log("Data 11")
    }); 
    this.getProcessedData()
  }
  getselectedMaintenanceTypes(){    
    var departmentNameId =this.RequiredSparesForMaintenanceForm.value['departmentNameId'];
    this.RequiredSparesForMaintenanceService.getselectedMaintenanceTypes(departmentNameId).subscribe(res=>{      
      this.maintenanceTypeValue=res
      console.log(res)
    }); 
    this.getProcessedData();
  }
  getselectedMaintenanceCategory(){    
    var departmentNameId =this.RequiredSparesForMaintenanceForm.value['departmentNameId'];
    var maintenanceTypeId =this.RequiredSparesForMaintenanceForm.value['maintenanceTypeId'];
    this.RequiredSparesForMaintenanceService.getselectedMaintenanceCategoryByDeptAndType(departmentNameId,maintenanceTypeId).subscribe(res=>{      
      this.maintenanceCategoryValue=res
      console.log(res)
    }); 
  }
  getselectedMaintenanceSubCategory(){   
    console.log("check") 
    var departmentNameId =this.RequiredSparesForMaintenanceForm.value['departmentNameId'];
    var maintenanceCategoryId =this.RequiredSparesForMaintenanceForm.value['maintenanceCategoryId'];
    this.RequiredSparesForMaintenanceService.getselectedMaintenanceSubCategoryByDeptAndType(departmentNameId,maintenanceCategoryId).subscribe(res=>{
      this.maintenanceSubCategoryValue=res
      console.log(res)
    }); 
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print-routine").innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-action{
                      display: none;
                    }
        
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
                    }
                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Inventory History List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    const id = this.RequiredSparesForMaintenanceForm.get('requiredSparesForMaintenanceId').value;   
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
          this.RequiredSparesForMaintenanceService.update(+id,this.RequiredSparesForMaintenanceForm.value).subscribe(response => {
            this.router.navigateByUrl('/maintenence-planning/add-requiredsparesformaintenance');
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
      this.RequiredSparesForMaintenanceService.submit(this.RequiredSparesForMaintenanceForm.value).subscribe(response => {
        console.log(this.RequiredSparesForMaintenanceForm)
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
  // findSubmit() {
  //   //const id = this.ItemDetailForm.get('itemDetailId').value;   
  //   var findArr = this.RequiredSparesForMaintenanceForm.value;
  //   console.log(findArr)
  //   this.RequiredSparesForMaintenanceService.findRequirdSparesList(findArr.departmentNameId == null ? 0 : findArr.departmentNameId,findArr.sparesCategoryId == null ? 0 : findArr.sparesCategoryId).subscribe(res=>{
  //     this.requiredSparesForMaintenanceList=res
  //     console.log("availQty");
  //     console.log(this.requiredSparesForMaintenanceList)
  //   }); 

    
  
 
  // }

  deleteItem(row) {
    const id = row.requiredSparesForMaintenanceId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.RequiredSparesForMaintenanceService.delete(id).subscribe(() => {
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

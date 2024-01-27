import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { StockTransferNsdService } from '../../service/StockTransferNsd.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { StockTransferNsd } from '../../models/StockTransferNsd';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { ItemDetailService } from 'src/app/spares-management/service/itemDetail.service';
import { ItemStorService } from '../../service/ItemStor.service';

@Component({
  selector: 'app-new-stocktransfernsd',
  templateUrl: './new-stocktransfernsd.component.html',
  styleUrls: ['./new-stocktransfernsd.component.sass']
})
export class NewStockTransferNsdComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  StockTransferNsdForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  itemName: SelectedModel[];
  demandAuthorityValue:SelectedModel[];
  selectedNsdQty:SelectedModel[];
  itemValue: string;
  files: any[];
  itemDetailId:any;
  itemStorId:any;
  issueQty:any;
  toolsLocationId:any;
  availableQty:any;
  nsdQty:any;
  stockTransferNsdList:StockTransferNsd[];
  isShown: boolean = false ;
  coView: boolean = false ;
  isFormShown: boolean = true ;
  masterData = MasterData;
  itemCategoryId:any;
  userRole = Role;
  
  traineeId:any;
  role:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'departmentName', 'itemName', 'demandAuthority','nsdQty','transferQty','stockAdjustmentDate', 'status',  'actions'];
  displayedColumnsForCo: string[] = [ 'ser', 'departmentName', 'itemName', 'demandAuthority','nsdQty','transferQty','stockAdjustmentDate', 'status'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private ItemStorService: ItemStorService, private ItemDetailService: ItemDetailService, private confirmService: ConfirmService,private StockTransferNsdService: StockTransferNsdService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('stockTransferNsdId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit Stock Transfer from NSD';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.StockTransferNsdService.find(+id).subscribe(
        res => {
          this.StockTransferNsdForm.patchValue({          

            stockTransferNsdId: res.stockTransferNsdId,
            departmentNameId:res.departmentNameId,
            itemStorId:res.itemStorId,
            itemDetailId:res.itemDetailId,
            toolsLocationId:res.toolsLocationId,
            issuedQty:res.issuedQty,
            nsdQty: res.nsdQty,
            availableQty: res.availableQty,
            transferQty: res.transferQty,
            demandAuthorityId: res.demandAuthorityId,
            stockAdjustmentDate: res.stockAdjustmentDate,
            doc: res.doc,
            completeStatus: res.completeStatus,
            verificationCompletStatus: res.verificationCompletStatus,
            status: res.status,
            remarks:res.remarks
          
          });  
        }
      );
    } else {
      this.pageTitle = 'Create Stock Transfer from NSD';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin && this.role != this.userRole.CO){
      this.StockTransferNsdForm.get('departmentNameId').setValue(this.branchId);
      this.onStockTransferNsdListByDepartmentNameSelectionChange();
    }
    if(this.role == this.userRole.CO){
      this.isFormShown = false;
      this.isShown = true;
      this.coView = true;
      this.pendingListForCo();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedDemandAuthority();
  }

  intitializeForm() {
    this.StockTransferNsdForm = this.fb.group({
      stockTransferNsdId: [0],
      departmentNameId:[],
      itemStorId:[],
      itemDetailId:[],
      toolsLocationId:[],
      //issuedQty:[],
      nsdQty:[],
      availableQty:[''],
      transferQty: [''],
      demandAuthorityId: [''],
      stockAdjustmentDate: [],
      //verificationCompletStatus: [],
      doc: [''],
      document:[''],
      completeStatus: [0],
      status: [0],
      remarks:[],
      isActive: [true]
    
    })
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      this.StockTransferNsdForm.patchValue({
        document: file,
      });
    }
  }
  inActiveItem(row){
    const id = row.stockTransferNsdId; 
          this.confirmService.confirm('Confirm Approved message', 'Are You Sure Approved This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.StockTransferNsdService.approvedStockTransferNsd(id).subscribe(() => {
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
  onStockTransferNsdListByDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.StockTransferNsdForm.value['departmentNameId'];
      this.StockTransferNsdService.getStockTransferNsdListByDepartmentName(departmentNameId,0).subscribe(res=>{
        this.stockTransferNsdList=res
        console.log( this.stockTransferNsdList);
        this.getItemNameByDepartmentName();
      });
  }
  pendingListForCo(){
    this.StockTransferNsdService.getStockTransferNsdListByDepartmentName(0,0).subscribe(res=>{
      this.stockTransferNsdList=res
      console.log( this.stockTransferNsdList);
      // this.getItemNameByDepartmentName();
    });
  }
  onItemNameSelectionChange(){
   var itemStorId= this.StockTransferNsdForm.value['itemStorId'];
   console.log(itemStorId);
  this.ItemStorService.find(itemStorId).subscribe((res) => {
    this.itemDetailId=res.itemDetailId;
    this.toolsLocationId=res.toolsLocationId;
    this.availableQty=res.availableQty;
    //this.nsdQty=res.nsdQty;
    //this.getNsdQtyById(this.itemStorId);
    console.log( "itemDetailId");
    console.log( this.itemDetailId,this.toolsLocationId,this.availableQty);
         this.StockTransferNsdForm.get("itemDetailId").setValue(this.itemDetailId);
         this.StockTransferNsdForm.get("toolsLocationId").setValue(this.toolsLocationId);
         this.StockTransferNsdForm.get("availableQty").setValue(this.availableQty);
         
  
       });
     
  }
  getItemNameByDepartmentName(){
    var departmentNameId =this.StockTransferNsdForm.value['departmentNameId'];
      this.StockTransferNsdService.getSelectedItemDetail(departmentNameId).subscribe(res=>{
        this.itemName=res
        //this.itemNameValue=res
        console.log("ooo");
        console.log( this.itemName);
        //this.getNsdQtyById(this.itemStorId);
      });
  }
  
  GetDepartmentNameById(baseNameId){    
    this.StockTransferNsdService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log(res)
    }); 
  }
  getselectedDemandAuthority(){    
    this.StockTransferNsdService.getselectedDemandAuthority().subscribe(res=>{
      this.demandAuthorityValue=res
      console.log(res)
    }); 
  }
  getNsdQtyById(id: number) {
    console.log(id);
    this.StockTransferNsdService.getNsdQtyById(id).subscribe((res) => {
      this.selectedNsdQty = res;
      console.log(this.selectedNsdQty);
      this.itemValue = this.selectedNsdQty[0].value;
      this.StockTransferNsdForm.get("nsdQty").setValue(this.itemValue);
      console.log(this.itemValue);
    });
  }
  onPartNoSelectionChange(dropdown) {
    if (dropdown.isUserInput) {
      console.log(dropdown.source.value);
      this.getNsdQtyById(dropdown.source.value);
      //this.getPartNoByDepartmentNameId(dropdown.source.value);
    }
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.StockTransferNsdForm.get('stockTransferNsdId').value; 
    console.log(this.StockTransferNsdForm);
    this.StockTransferNsdForm.get("stockAdjustmentDate").setValue( new Date(this.StockTransferNsdForm.get("stockAdjustmentDate").value).toUTCString());
    console.log(this.StockTransferNsdForm.value);
    const formData = new FormData();
    for (const key of Object.keys(this.StockTransferNsdForm.value)) {
      const value = this.StockTransferNsdForm.value[key];
      formData.append(key, value);
    }
    console.log(formData)
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
         console.log(result)
        if (result) {
          this.StockTransferNsdService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/spares-management/add-stocktransfernsd');
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
      this.StockTransferNsdService.submit(formData).subscribe(response => {
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
    const id = row.stockTransferNsdId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.StockTransferNsdService.delete(id).subscribe(() => {
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
  
  ChangeNsdTransfarStatus(row,status) {
    const id = row.stockTransferNsdId; 
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.StockTransferNsdService.ChangeStockStatus(id,status).subscribe(() => {
          this.reloadCurrentRoute();
          this.snackBar.open('Information Updated Successfully ', '', {
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

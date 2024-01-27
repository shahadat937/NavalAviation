import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemStorService } from '../../service/ItemStor.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { ItemStor } from '../../models/ItemStor';
import { MasterData } from 'src/assets/data/master-data';
import { AcceptanceService } from '../../service/Acceptance.service';
import { Acceptance } from '../../models/Acceptance';
import { DemandService } from '../../service/Demand.service';
import { MatTableDataSource } from '@angular/material/table';
import { ProcurementService } from '../../service/Procurement.service';
import { Procurement } from '../../models/Procurement';

@Component({
  selector: 'app-new-itemstor-main-equ',
  templateUrl: './new-itemstor-main-equ.component.html',
  styleUrls: ['./new-itemstor-main-equ.component.sass']
})
export class NewItemStorMainEquComponent implements OnInit {
  pageTitle: String;
  destination: String;
  btnText:String;
  masterData = MasterData;
  ItemStorForm: FormGroup;
  validationErrors: string[] = [];
  selectedItemCategory:SelectedModel[]; 
  selectedDeno:SelectedModel[]; 
  selectedAcctStore:SelectedModel[]; 
  selectedServiceLifeType:SelectedModel[]; 
  selectedEndLifeType:SelectedModel[]; 
  selectedOverhaulingTypes:SelectedModel[]; 
  selectedDepartmentNames:SelectedModel[]; 
  selectedPartNo:SelectedModel[]; 
  acceptanceByDepartmentAndCategory:Acceptance;
  isShown: boolean = false ;
  procurementData: Procurement[];
  acceptanceData: Acceptance[];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'partNo', 'itemSerNo','warrantyStartDate', 'warrantyEndDate','itemReceivedDate', 'actions'];
  dataSource: MatTableDataSource<ItemStor> = new MatTableDataSource();
  
  sftColumns: string[] = ['sl','itemDetail', 'sftQty','storeQty','demandDate', 'deliveryDate', 'outerLatterNo'];
  procurementColumns: string[] = ['sl','tenderNumber','dateOfDelivery', 'dateOfTenderFloat', 'cstTec', 'qty'];


  constructor(private snackBar: MatSnackBar,private procurementService: ProcurementService,private demandService: DemandService,private acceptanceService:AcceptanceService,private confirmService: ConfirmService,private ItemStorService: ItemStorService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('itemStorId'); 
    if (id) {
      this.pageTitle = 'Edit Item Store - Main Equipment';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ItemStorService.find(+id).subscribe(
        res => {
          this.ItemStorForm.patchValue({          
            itemStorId: res.itemStorId,
            acceptanceId: res.acceptanceId,
            procurementId: res.procurementId,
            demandId:res.demandId,
            denoId: res.denoId,
            departmentNameId: res.departmentNameId,
            itemCategoryId: res.itemCategoryId,
            serviceLifeTypeId: res.serviceLifeTypeId,
            sparesCategoryId: res.sparesCategoryId,
            endLifeTypeId: res.endLifeTypeId,
            acctStoreId: res.acctStoreId,
            overhaulingTypeId: res.overhaulingTypeId,
            retirementTypeId: res.retirementTypeId,
            itemDetailId: res.itemDetailId,
            itemSerNo: res.itemSerNo,
            icmNo: res.icmNo,
            shelfLife: res.shelfLife,
            endShalfLife: res.endShalfLife,
            warrantyStartDate: res.warrantyStartDate,
            warrantyEndDate: res.warrantyEndDate,
            itemReceivedDate: res.itemReceivedDate,
            totalReceivedQty: res.totalReceivedQty,
            issuedQty: res.issuedQty,
            demandQty: res.demandQty,
            demandDate: res.demandDate,
            letterOuterNo: res.letterOuterNo,
            refPoNo: res.refPoNo,
            tenderNumber: res.tenderNumber,
            dateOfTenderFloat: res.dateOfTenderFloat,
            tenderopeningDate: res.tenderopeningDate,
            tenderPublishDate: res.tenderPublishDate,
            tenderNotice: res.tenderNotice,
            location: res.location,
            serviceLife: res.serviceLife,
            endLifeTime: res.endLifeTime,
            accessories: res.accessories,
            stockRegisterPageNo: res.stockRegisterPageNo,
            retirmentLife: res.retirmentLife,
            remarks: res.remarks,
            arcDoc: res.arcDoc,
            cofcDoc: res.cofcDoc,
            otherDoc: res.otherDoc,
            oemDoc: res.oemDoc,
            status: res.status,
            isActive: res.isActive
          });  
          this.getselectedAcceptenceOnUpdate(res.departmentNameId);
          this.getAcceptanceData();    
        }
      );
    } else {
      this.pageTitle = 'Create Item Store - Main Equipment';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    this.getselectedItemCategory();
    this.getselectedDeno();
    this.getselectedAcctStore();
    this.getselectedServiceLifeType();
    this.getselectedEndLifeType();
    this.getselectedOverhaulingTypes();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getItemStors();
  }
  intitializeForm() {
    this.ItemStorForm = this.fb.group({
      itemStorId: [0],
      acceptanceId: [],
      procurementId: [],
      demandId:[],
      denoId: [],
      departmentNameId: [],
      itemCategoryId:[this.masterData.itemcategory.mainEquipment],
      serviceLifeTypeId:[],
      sparesCategoryId:[],
      endLifeTypeId: [],
      acctStoreId: [],
      overhaulingTypeId:[],
      retirementTypeId: [],
      itemDetailId:[],
      itemSerNo:[],
      icmNo:[],
      shelfLife:[],
      endShalfLife:[],
      warrantyStartDate:[],
      warrantyEndDate:[],
      itemReceivedDate:[],
      totalReceivedQty:[],
      availableQty:[],
      issuedQty:[],
      demandQty:[],
      demandDate:[],
      letterOuterNo:[],
      refPoNo:[],
      tenderNumber:[],
      dateOfTenderFloat:[],
      tenderopeningDate:[],
      tenderPublishDate:[],
      tenderNotice:[],
      location:[],
      qtyEntryType:[''],
      serviceLife:[],
      endLifeTime:[],
      accessories:[],
      stockRegisterPageNo:[],
      retirmentLife:[],
      remarks:[],
      arcDoc:[],
      cofcDoc:[],
      otherDoc:[],
      oemDoc:[],
      status:[],
      isActive: [true]
    
    })
  }
  getselectedAcceptence(){
    var departmentNameId = this.ItemStorForm.value['departmentNameId'];
    this.ItemStorService.partnoFromAcceptanceByDepartmentName(departmentNameId, this.masterData.sparescategory.spares).subscribe(res=>{
      this.selectedPartNo=res
      console.log(this.selectedPartNo);      
    });
  }
  getselectedAcceptenceOnUpdate(id){
    this.ItemStorService.partnoFromAcceptanceForUpdateByDepartmentName(id, this.masterData.sparescategory.spares).subscribe(res=>{
      this.selectedPartNo=res;
      console.log(this.selectedPartNo)
    });
  }
  getAcceptanceData(){    
    var acceptanceId = this.ItemStorForm.value['acceptanceId'];
    console.log(acceptanceId);
    this.ItemStorService.getacceptanceById(acceptanceId).subscribe(res=>{
      this.acceptanceData=res;        
    });
    this.acceptanceService.find(acceptanceId).subscribe(res=>{
      this.acceptanceByDepartmentAndCategory=res
      this.ItemStorForm.get('demandId').setValue(res.demandId);
      this.ItemStorForm.get('itemDetailId').setValue(res.itemDetailId);
      this.ItemStorForm.get('procurementId').setValue(res.procurementId);
      this.ItemStorForm.get('sparesCategoryId').setValue(res.sparesCategoryId);    
      console.log("acceptance")
      console.log(res.sftQty);  
      
      
      this.procurementService.GetselectedProcurementById(res.procurementId).subscribe(res=>{
        this.procurementData=res;        
      });
      this.demandService.find(res.demandId).subscribe(res=>{
        this.ItemStorForm.get('denoId').setValue(res.denoId);
        this.ItemStorForm.get('demandQty').setValue(res.demandQty);
        this.ItemStorForm.get('demandDate').setValue(res.demandDate);
        this.ItemStorForm.get('letterOuterNo').setValue(res.letterOuterNo);
        this.ItemStorForm.get('refPoNo').setValue(res.refPoNo);
      });
      this.procurementService.find(res.procurementId).subscribe(res=>{
        this.ItemStorForm.get('tenderNumber').setValue(res.tenderNumber);
        this.ItemStorForm.get('dateOfTenderFloat').setValue(res.dateOfTenderFloat);
        this.ItemStorForm.get('tenderopeningDate').setValue(res.tenderopeningDate);
        this.ItemStorForm.get('tenderPublishDate').setValue(res.tenderPublishDate);
      });   
      this.isShown=true;
    });

  }
  // getselectedDepartmentNames(){
  //   this.ItemStorService.getselectedDepartmentNames().subscribe(res=>{
  //     this.selectedDepartmentNames=res
  //     console.log(this.selectedDepartmentNames);      
  //   });
  // }
  GetDepartmentNameById(baseNameId){    
    this.ItemStorService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentNames=res
      console.log(res)
    }); 
  }
  getselectedItemCategory(){
    this.ItemStorService.getSelectedItemCategory(this.masterData.sparescategory.spares).subscribe(res=>{
      this.selectedItemCategory=res
      console.log(this.selectedItemCategory);      
    });
  }
  getselectedDeno(){
    this.ItemStorService.getselectedDeno().subscribe(res=>{
      this.selectedDeno=res
      console.log(this.selectedDeno);      
    });
  }
  getselectedAcctStore(){
    this.ItemStorService.getselectedAcctStore().subscribe(res=>{
      this.selectedAcctStore=res
      console.log(this.selectedAcctStore);      
    });
  }
  getselectedServiceLifeType(){
    this.ItemStorService.getselectedServiceLifeType().subscribe(res=>{
      this.selectedServiceLifeType=res
      console.log(this.selectedServiceLifeType);      
    });
  }
  getselectedEndLifeType(){
    this.ItemStorService.getselectedEndLifeType().subscribe(res=>{
      this.selectedEndLifeType=res
      console.log(this.selectedEndLifeType);      
    });
  }
  getselectedOverhaulingTypes(){
    this.ItemStorService.getselectedOverhaulingTypes().subscribe(res=>{
      this.selectedOverhaulingTypes=res
      console.log(this.selectedOverhaulingTypes);      
    });
  }


  getItemStors() {
    this.isLoading = true;
    this.ItemStorService.getItemStors(this.paging.pageIndex, this.paging.pageSize,this.searchText, this.masterData.itemcategory.mainEquipment).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getItemStors();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getItemStors();
  }

  deleteItem(row) {
    const id = row.itemStorId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ItemStorService.delete(id).subscribe(() => {
          this.getItemStors();
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

  onSubmit() {
    //availableQty  this.AcceptanceForm.get('sparesCategoryId').setValue(this.sparesCategoryId);
    //this.ItemStorForm.value['departmentNameId'];
    const id = this.ItemStorForm.get('itemStorId').value;  
    console.log(this.ItemStorForm.value) 
    //this.ItemStorForm.get('sparesCategoryId').setValue(this.sparesCategoryId)
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.ItemStorService.update(+id,this.ItemStorForm.value).subscribe(response => {
            this.router.navigateByUrl('/spares-management/add-itemstor-main-equ');
            this.getItemStors();
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
      this.ItemStorService.submit(this.ItemStorForm.value).subscribe(response => {
        this.router.navigateByUrl('/spares-management/add-itemstor-main-equ');
        this.getItemStors();
        this.intitializeForm();
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

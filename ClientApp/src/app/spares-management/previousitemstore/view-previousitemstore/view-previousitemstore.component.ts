import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { PreviousItemStore } from '../../models/PreviousItemStore';
import { PreviousItemStoreService } from '../../service/PreviousItemStore.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-previousitemstore',
  templateUrl: './view-previousitemstore.component.html',
  styleUrls: ['./view-previousitemstore.component.sass']
})
export class ViewPreviousItemStoreComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: PreviousItemStore[] = [];
  isLoading = false;
  previousItemStoreId: number;
  departmentNameId: number;
  itemDetailId:number;
  toolsBoxNameId:number;
  toolsLocationId:number;
  toolsTypeId:number;
  denoId:number;
  itemCategoryId:number;
  sparesCategoryId:number;
  serviceLifeTypeId:number;
  endLifeTypeId:number;
  acctStoreId:number;
  overhaulingTypeId:number;
  retirementTypeId:number;
  itemSerNo:string;
  icmNo:string;
  shelfLife:string;
  endShalfLife:string;
  warrantyStartDate:Date;
  warrantyEndDate:Date;
  itemReceivedDate:Date;
  totalReceivedQty:number;
  issuedQty:number;
  availableQty:number;
  location:string;
  serviceLife:string;
  endLifeTime:string;
  accessories:string;
  stockRegisterPageNo:string;
  retirmentLife:string;
  demandQty:string;
  demandDate:Date;
  letterOuterNo:string;
  refPoNo:string;
  tenderNumber:string;
  dateOfTenderFloat:Date;
  tenderopeningDate:Date;
  tenderPublishDate:Date;
  tenderNotice:string;
  calibrationDate:Date;
  nextCalibrationDate:Date;
  remarks:string;
  departmentName:string;
  pattNo:string;
  itemDetail:string;
  toolsBoxName:string;
  toolsLocation:string;
  toolsType:string;
  deno:string;
  itemCategory:string;
  servisLifeType:string;
  sparesCategory:string;
  endLifeType:string;
  acctStore:string;
  overhawlingType:string;
  retirmentType:string;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private PreviousItemStoreService: PreviousItemStoreService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('previousItemStoreId'); 
    this.PreviousItemStoreService.find(+id).subscribe( res => {
      console.log(res);
      this.previousItemStoreId= res.previousItemStoreId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.pattNo=res.pattNo,
      this.itemDetail=res.itemDetail,
      this.toolsBoxName=res.toolsBoxName,
      this.toolsLocation=res.toolsLocation,
      this.toolsType=res.toolsType,
      this.deno=res.deno,
      this.itemCategory=res.itemCategory,
      this.servisLifeType=res.servisLifeType,
      this.sparesCategory=res.sparesCategory,
      this.endLifeType=res.endLifeType,
      this.acctStore=res.acctStore,
      this.overhawlingType=res.overhawlingType,
      this.retirmentType=res.retirmentType,
      this.itemSerNo=res.itemSerNo,
      this.icmNo=res.icmNo,
      this.shelfLife=res.shelfLife,
      this.endShalfLife=res.endShalfLife,
      this.warrantyStartDate=res.warrantyStartDate,
      this.warrantyEndDate=res.warrantyEndDate,
      this.itemReceivedDate=res.itemReceivedDate,
      this.totalReceivedQty=res.totalReceivedQty,
      this.issuedQty=res.issuedQty,
      this.availableQty=res.availableQty,
      this.location=res.location,
      this.serviceLife=res.serviceLife,
      this.endLifeTime=res.endLifeTime,
      this.accessories=res.accessories,
      this.stockRegisterPageNo=res.stockRegisterPageNo,
      this.retirmentLife=res.retirmentLife,
      this.demandQty=res.demandQty,
      this.demandDate=res.demandDate,
      this.letterOuterNo=res.letterOuterNo,
      this.refPoNo=res.refPoNo,
      this.tenderNumber=res.tenderNumber,
      this.dateOfTenderFloat=res.dateOfTenderFloat,
      this.tenderopeningDate=res.tenderopeningDate,
      this.tenderPublishDate=res.tenderPublishDate,
      this.tenderNotice=res.tenderNotice,
      this.calibrationDate=res.calibrationDate,
      this.nextCalibrationDate=res.nextCalibrationDate,
      this.remarks=res.remarks
      
    })
  }
}

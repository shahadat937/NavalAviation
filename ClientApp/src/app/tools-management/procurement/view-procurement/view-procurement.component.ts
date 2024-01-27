import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Procurement } from '../../models/Procurement';
import { ProcurementService } from '../../service/Procurement.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-procurement',
  templateUrl: './view-procurement.component.html',
  styleUrls: ['./view-procurement.component.sass']
})
export class ViewProcurementComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Procurement[] = [];
  isLoading = false;
  procurementId: number;
  departmentNameId: number;
  departmentName:string;
  itemDetail:string;
  itemName:string;
  qty:string;
  dateOfTenderFloat:Date;
  tenderNumber:string;
  tenderSpecification:string;
  tenderopeningDate:Date;
  cstTecId:string;
  cstTec:string;
  tenderNotice:string;
  workOrder:string;
  workOrderDate:Date;
  supplierId:string;
  supplier:string;
  dateOfDelivery:Date;
  procurementDocument:string;
  remarks:string;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private ProcurementService: ProcurementService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('procurementId'); 
    this.ProcurementService.find(+id).subscribe( res => {
      console.log(res);
      this.procurementId= res.procurementId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.itemDetail=res.itemDetail,
      this.itemName=res.itemName,
      this.qty=res.qty,
      this.dateOfTenderFloat=res.dateOfTenderFloat,
      this.tenderNumber=res.tenderNumber,
      this.tenderSpecification=res.tenderSpecification,
      this.tenderopeningDate=res.tenderopeningDate,
      this.cstTec=res.cstTec,
      this.tenderNotice=res.tenderNotice,
      this.workOrder=res.workOrder,
      this.workOrderDate=res.workOrderDate,
      this.supplier=res.supplier,
      this.dateOfDelivery=res.dateOfDelivery,
      this.procurementDocument=res.procurementDocument,
      this.remarks=res.remarks
      
    })
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
    this.reloadCurrentRoute();
  }
  
}

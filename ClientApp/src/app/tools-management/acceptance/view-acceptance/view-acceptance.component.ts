import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Acceptance } from '../../models/Acceptance';
import { AcceptanceService } from '../../service/Acceptance.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-acceptance',
  templateUrl: './view-acceptance.component.html',
  styleUrls: ['./view-acceptance.component.sass']
})
export class ViewAcceptanceComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Acceptance[] = [];
  isLoading = false;
  acceptanceId: number;
  departmentNameId: number;
  departmentName:string;
  itemDetail:string;
  itemName:string;
  qty:number;
  itemSerNo:string;
  model:string;
  brand:string;
  workOrderNo:string;
  deliveryDate:Date;
  sftQty:number;
  warrantyFrom:Date;
  sftDate:Date;
  warrantyTo:Date;
  conditionOfItemId:string;
  condition:string;
  purchasePrice:string;
  acceptanceDocument:string;
  remarks:string;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private AcceptanceService: AcceptanceService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('acceptanceId'); 
    this.AcceptanceService.find(+id).subscribe( res => {
      console.log(res);
      this.acceptanceId= res.acceptanceId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.itemDetail=res.itemDetail,
      this.itemName=res.itemName,
      this.qty=res.qty,
      this.itemSerNo=res.itemSerNo,
      this.model=res.model,
      this.brand=res.brand,
      this.workOrderNo=res.workOrderNo,
      this.deliveryDate=res.deliveryDate,
      this.sftQty=res.sftQty,
      this.warrantyFrom=res.warrantyFrom,
      this.sftDate=res.sftDate,
      this.warrantyTo=res.warrantyTo,
      this.condition=res.condition,
      this.purchasePrice=res.purchasePrice,
      this.acceptanceDocument=res.acceptanceDocument,
      this.remarks=res.remarks
      
    })
  }
}

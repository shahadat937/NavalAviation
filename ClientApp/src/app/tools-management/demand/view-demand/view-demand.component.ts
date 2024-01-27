import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Demand } from '../../models/Demand';
import { DemandService } from '../../service/Demand.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-demand',
  templateUrl: './view-demand.component.html',
  styleUrls: ['./view-demand.component.sass']
})
export class ViewDemandComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Demand[] = [];
  isLoading = false;
  demandId: number;
  departmentNameId: number;
  departmentName:string;
  partNo:string;
  itemName:string;
  demandTypeId:string;
  demandType:string;
  conditionOfItemId:string;
  conditionOfItem:string;
  denoId:string;
  deno:string;
  demandQty:string;
  demandDate:Date;
  occasionOfDemandId:string;
  occasionOfDemand:string;
  fiscalYearId:string;
  fiscalYear:string;
  authorityId:string;
  authority:string;
  tradeId:string;
  tread:string;
  itemCategoryId:string;
  itemCategory:string;
  demandStatusId:string;
  demandStatus:string;
  demandNo:string;
  manufactureId:string;
  manufacture:string;
  refPrice:string;
  demandLetterNo:string;
  specDoc:string;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private DemandService: DemandService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('demandId'); 
    this.DemandService.find(+id).subscribe( res => {
      console.log(res);
      this.demandId= res.demandId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.partNo=res.partNo,
      this.itemName=res.itemName,
      this.demandType=res.demandType,
      this.conditionOfItem=res.conditionOfItem,
      this.deno=res.deno,
      this.demandQty=res.demandQty,
      this.occasionOfDemand=res.occasionOfDemand,
      this.fiscalYear=res.fiscalYear,
      this.authority=res.authority,
      this.tread=res.tread,
      this.itemCategory=res.itemCategory,
      this.demandDate=res.demandDate,
      this.demandStatus=res.demandStatus,
      this.demandNo=res.demandNo,
      this.manufacture=res.manufacture,
      this.refPrice=res.refPrice,
      this.demandLetterNo=res.demandLetterNo,
      this.specDoc=res.specDoc
      
    })
  }
}

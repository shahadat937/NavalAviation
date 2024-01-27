import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemStor } from '../../models/ItemStor';
import { ItemStorService } from '../../service/ItemStor.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-itemstor',
  templateUrl: './view-itemstor.component.html',
  styleUrls: ['./view-itemstor.component.sass']
})
export class ViewItemStorComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ItemStor[] = [];
  isLoading = false;
  itemStorId: number;
  departmentNameId: number;
  departmentName:string;
  partNo:string;
  nameOfItem:string;
  itemSerNo:string;
  denoId:number;
  totalReceivedQty:number;
  sparesCategoryId:string;
  conditionOfItemId:string;
  toolsLocationId:string;
  icmNo:string;
  manufacturingDate:Date;
  lifeLimitItemId:number;
  warrantyEndDate:Date;
  otherDoc:string;
  deno:string;
  sparesCategory:string;
  condition:string;
  toolsLocation:string;
  lifeLimitItem:string;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private ItemStorService: ItemStorService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('itemStorId'); 
    this.ItemStorService.find(+id).subscribe( res => {
      console.log(res);
      this.itemStorId= res.itemStorId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.partNo=res.partNo,
      this.nameOfItem=res.nameOfItem,
      this.itemSerNo=res.itemSerNo,
      this.deno=res.deno,
      this.totalReceivedQty=res.totalReceivedQty,
      this.sparesCategory=res.sparesCategory,
      this.condition=res.condition,
      this.toolsLocation=res.toolsLocation,
      this.icmNo=res.icmNo,
      this.manufacturingDate=res.manufacturingDate,
      this.lifeLimitItem=res.lifeLimitItem,
      this.warrantyEndDate=res.warrantyEndDate,
      this.otherDoc=res.otherDoc
      
    })
  }
}

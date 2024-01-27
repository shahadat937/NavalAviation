import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Demand } from '../../../spares-management/models/Demand';
import { DemandService } from '../../../spares-management/service/Demand.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';

@Component({
  selector: 'app-procurement-list',
  templateUrl: './procurement-list.component.html',
  styleUrls: ['./procurement-list.component.sass']
})
export class procurementListComponent implements OnInit {

  masterData = MasterData;
  //ELEMENT_DATA: Demand[] = [];
  isLoading = false;
  RemainProcurement:string = 'All';
  RemainProcurementQtyList:any;
  CountRemainProcurement:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  procurementColumns: string[] = ['sl','tenderNumber','dateOfDelivery', 'dateOfTenderFloat', 'cstTec', 'qty', 'sftQty'];
  
  
  constructor(private snackBar: MatSnackBar,private dashboardService: DashboardService,private DemandService: DemandService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getRemainProcurementQty();
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.RemainProcurementQtyList();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.RemainProcurementQtyList();
  } 
  getRemainProcurementQty(){
    this.dashboardService.getRemainProcurementQty(0).subscribe(response => {   
      this.RemainProcurementQtyList=response;
      this.CountRemainProcurement=response.length;
      console.log(this.RemainProcurementQtyList)
    })
  }
  RemainProcurementQty(id, name){  
    this.RemainProcurement = name;
    this.dashboardService.getRemainProcurementQty(id).subscribe(response => {
      this.RemainProcurementQtyList = response; 
      this.CountRemainProcurement = response.length;
    }) 
  }
  

  deleteItem(row) {
    const id = row.demandId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.DemandService.delete(id).subscribe(() => {
          this.RemainProcurementQtyList();
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

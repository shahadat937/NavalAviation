import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
 

@Component({
  selector: 'app-pendingprocurement',
  templateUrl: './pendingprocurement-list.component.html',
  styleUrls: ['./pendingprocurement-list.component.sass']
})
export class PendingProcurementListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;

  pendingProcurementList:any;
  CountpendingProcurement:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  ProcurementName:string;

  displayedColumns: string[] = [ 'ser', 'itemType', 'deptName','itemDetail','itemName','tenderNumber', 'dateOfTenderFloat', 'dateOfDelivery', 'qty', 'isActive'];
  
  constructor(private snackBar: MatSnackBar, private dashboardService: DashboardService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.inActiveItem(0, 'All');
  }
  inActiveItem(id, name){  
    this.ProcurementName = name;
    this.dashboardService.getPendingProcurements(id).subscribe(response => {
      this.pendingProcurementList = response; 
      this.CountpendingProcurement = response.length;
    }) 
  }

  
}

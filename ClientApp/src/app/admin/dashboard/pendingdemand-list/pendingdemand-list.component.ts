import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
 

@Component({
  selector: 'app-pendingdemand',
  templateUrl: './pendingdemand-list.component.html',
  styleUrls: ['./pendingdemand-list.component.sass']
})
export class PendingDemandListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;

  pendingDemandList:any;
  CountpendingDemand:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  demandName:string;

  displayedColumns: string[] = [ 'ser', 'sparesCategory', 'name', 'demandDate','partNo', 'demandQty','deno', 'isActive'];
  
  constructor(private snackBar: MatSnackBar, private dashboardService: DashboardService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.inActiveItem(0, 'All');
  }
  inActiveItem(id, name){  
    this.demandName = name;
    this.dashboardService.getPendingDemands(id).subscribe(response => {
      this.pendingDemandList = response; 
      this.CountpendingDemand = response.length;
    }) 
  }
  
}

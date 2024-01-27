import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
 

@Component({
  selector: 'app-pendingacceptance',
  templateUrl: './pendingacceptance-list.component.html',
  styleUrls: ['./pendingacceptance-list.component.sass']
})
export class PendingAcceptanceListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;

  pendingAcceptanceList:any;
  CountpendingAcceptance:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  AcceptanceName:string;

  displayedColumns: string[] = [ 'ser', 'itemType', 'deptName', 'partNo', 'sftQty','demandDate', 'deliveryDate', 'letterOuterNo', 'isActive'];
  
  constructor(private snackBar: MatSnackBar, private dashboardService: DashboardService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.inActiveItem(0, 'All');
  }
  inActiveItem(id, name){  
    this.AcceptanceName = name;
    this.dashboardService.getPendingAcceptances(id).subscribe(response => {
      this.pendingAcceptanceList = response; 
      this.CountpendingAcceptance = response.length;
    }) 
  }
}

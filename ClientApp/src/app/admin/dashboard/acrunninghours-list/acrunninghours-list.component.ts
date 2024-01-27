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
  selector: 'app-acrunninghours-list',
  templateUrl: './acrunninghours-list.component.html',
  styleUrls: ['./acrunninghours-list.component.sass']
})
export class ACRunningHoursListComponent implements OnInit {

  masterData = MasterData;
  //ELEMENT_DATA: Demand[] = [];
  isLoading = false;
  FlyingTimeByDeptName:string = 'All';
  FlyingTimeByAricraftList:any;
  CountFlyingTimeByAricraft:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedColumns: string[] = [ 'ser', 'deptName','airCraftName', 'flyTime'];
  //displayedColumns: string[] = [ 'ser','departmentName','demandDate','itemDetail','demandQty', 'deno',/*'demandLetterNo','specDoc',*/'isActive', 'actions'];
  //dataSource: MatTableDataSource<Demand> = new MatTableDataSource();

  //selection = new SelectionModel<Demand>(true, []);
  
  constructor(private snackBar: MatSnackBar,private dashboardService: DashboardService,private DemandService: DemandService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getFlyingTimeByAricraft();
  }
 
  
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.FlyingTimeByAricraftList();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.FlyingTimeByAricraftList();
  } 
  getFlyingTimeByAricraft(){
    this.dashboardService.getFlyingTimeByAricraft(0).subscribe(response => {   
      this.FlyingTimeByAricraftList=response;
      this.CountFlyingTimeByAricraft = response.length;
      console.log(this.FlyingTimeByAricraftList)
    })
  }

  FlyingTimeByDept(id, name){  
    this.FlyingTimeByDeptName = name;
    this.dashboardService.getFlyingTimeByAricraft(id).subscribe(response => {
      this.FlyingTimeByAricraftList = response; 
      this.CountFlyingTimeByAricraft = response.length;
    }) 
  }
  

  deleteItem(row) {
    const id = row.demandId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.DemandService.delete(id).subscribe(() => {
          this.FlyingTimeByAricraftList();
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

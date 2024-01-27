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
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-acflyingprogram-list',
  templateUrl: './acflyingprogram-list.component.html',
  styleUrls: ['./acflyingprogram-list.component.sass']
})
export class acflyingprogramListComponent implements OnInit {

  masterData = MasterData;
  //ELEMENT_DATA: Demand[] = [];
  isLoading = false;
  FlyingByDeptName:string = 'All';
  AricraftFlyingList:any;
  CountAricraftFlying:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedFlyingColumns: string[] = [ 'ser', 'airCraftName','date', 'crew', 'callSign','mon','startUp','dur','endurance','fuel','opaOff','remarks'];
  
  
  constructor(private snackBar: MatSnackBar,private datepipe: DatePipe,private dashboardService: DashboardService,private DemandService: DemandService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getAricraftFlying();
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.AricraftFlyingList();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.AricraftFlyingList();
  } 
  getAricraftFlying(){
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.dashboardService.getAricraftFlying(currentDateTime,0).subscribe(response => {   
      this.AricraftFlyingList=response;
      this.CountAricraftFlying = response.length;
      console.log(this.AricraftFlyingList)
    })
  }

  FlyingByDept(id, name){  
    this.FlyingByDeptName = name;
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.dashboardService.getAricraftFlying(currentDateTime,id).subscribe(response => {   
      this.AricraftFlyingList=response;
      this.CountAricraftFlying = response.length;
    }) 
  }
  

  deleteItem(row) {
    const id = row.demandId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.DemandService.delete(id).subscribe(() => {
          this.AricraftFlyingList();
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

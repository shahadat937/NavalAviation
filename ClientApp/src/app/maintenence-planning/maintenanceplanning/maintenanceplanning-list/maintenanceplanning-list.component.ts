import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MaintenancePlanning } from '../../models/MaintenancePlanning';
import { MaintenancePlanningService } from '../../service/MaintenancePlanning.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-maintenanceplanning',
  templateUrl: './maintenanceplanning-list.component.html',
  styleUrls: ['./maintenanceplanning-list.component.sass']
})
export class MaintenancePlanningListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MaintenancePlanning[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'departmentName','airCraftName', 'categoryType', 'category', 'subCategory', 'mpStatus',  'actions'];
  dataSource: MatTableDataSource<MaintenancePlanning> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private MaintenancePlanningService: MaintenancePlanningService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMaintenancePlannings();
  }
 
  getMaintenancePlannings() {
    this.isLoading = true;
    this.MaintenancePlanningService.getMaintenancePlannings(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMaintenancePlannings();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMaintenancePlannings();
  }

  deleteItem(row) {
    const id = row.maintenancePlanningId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MaintenancePlanningService.delete(id).subscribe(() => {
          this.getMaintenancePlannings();
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

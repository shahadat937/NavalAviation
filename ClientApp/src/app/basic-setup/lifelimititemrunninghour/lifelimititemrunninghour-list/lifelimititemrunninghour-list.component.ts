import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { LifeLimitItemRunningHour } from '../../models/LifeLimitItemRunningHour';
import { LifeLimitItemRunningHourService } from '../../service/LifeLimitItemRunningHour.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-lifelimititemrunninghour',
  templateUrl: './lifelimititemrunninghour-list.component.html',
  styleUrls: ['./lifelimititemrunninghour-list.component.sass']
})
export class LifeLimitItemRunningHourListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: LifeLimitItemRunningHour[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'lifeLimitItem', 'maintenanceCategory', 'slNo', 'flightDate', 'departmentName', 'remarks', 'actions'];
  dataSource: MatTableDataSource<LifeLimitItemRunningHour> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private LifeLimitItemRunningHourService: LifeLimitItemRunningHourService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMaintananceCategories();
  }
 
  getMaintananceCategories() {
    this.isLoading = true;
    this.LifeLimitItemRunningHourService.getLifeLimitItemRunningHours(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMaintananceCategories();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMaintananceCategories();
  }

  deleteItem(row) {
    const id = row.lifeLimitItemRunningHourId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      console.log(result);
      if (result) {
        this.LifeLimitItemRunningHourService.delete(id).subscribe(() => {
          this.getMaintananceCategories();
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

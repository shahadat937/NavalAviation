import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { GseMaintenance } from '../../models/GseMaintenance';
import { GseMaintenanceService } from '../../service/GseMaintenance.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-gsemaintenance',
  templateUrl: './gsemaintenance-list.component.html',
  styleUrls: ['./gsemaintenance-list.component.sass']
})
export class GseMaintenanceListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: GseMaintenance[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'gseItemName', 'gseScheduleWorkType', 'gseMaintenanceScheduleName', 'date', 'departmentName', 'remarks', 'actions'];
  dataSource: MatTableDataSource<GseMaintenance> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private GseMaintenanceService: GseMaintenanceService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMaintananceCategories();
  }
 
  getMaintananceCategories() {
    this.isLoading = true;
    this.GseMaintenanceService.getGseMaintenances(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
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
    const id = row.gseMaintenanceId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      console.log(result);
      if (result) {
        this.GseMaintenanceService.delete(id).subscribe(() => {
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

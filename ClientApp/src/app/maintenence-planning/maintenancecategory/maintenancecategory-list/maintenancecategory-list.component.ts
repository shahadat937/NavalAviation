import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MaintenanceCategory } from '../../models/MaintenanceCategory';
import { MaintenanceCategoryService } from '../../service/MaintenanceCategory.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-maintenancecategory',
  templateUrl: './maintenancecategory-list.component.html',
  styleUrls: ['./maintenancecategory-list.component.sass']
})
export class MaintenanceCategoryListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MaintenanceCategory[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'categoryName', 'remarks','departmentName','maintenanceType', 'isActive', 'actions'];
  dataSource: MatTableDataSource<MaintenanceCategory> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private MaintenanceCategoryService: MaintenanceCategoryService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMaintenanceCategorys();
  }
 
  getMaintenanceCategorys() {
    this.isLoading = true;
    this.MaintenanceCategoryService.getMaintenanceCategorys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMaintenanceCategorys();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMaintenanceCategorys();
  }

  deleteItem(row) {
    const id = row.maintenanceCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MaintenanceCategoryService.delete(id).subscribe(() => {
          this.getMaintenanceCategorys();
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

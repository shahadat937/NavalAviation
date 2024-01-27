import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MaintenanceSubCategory } from '../../models/maintenanceSubCategory';
import { MaintenanceSubCategoryService } from '../../service/maintenanceSubCategory.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-maintenancesubcategory',
  templateUrl: './maintenancesubcategory-list.component.html',
  styleUrls: ['./maintenancesubcategory-list.component.sass']
})
export class MaintenanceSubCategoryListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MaintenanceSubCategory[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'maintenanceCategory', 'subCategoryName','allowedExtension', 'departmentName', 'remarks', 'actions'];
  dataSource: MatTableDataSource<MaintenanceSubCategory> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private MaintenanceSubCategoryService: MaintenanceSubCategoryService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMaintenanceSubCategorys();
  }
 
  getMaintenanceSubCategorys() {
    this.isLoading = true;
    this.MaintenanceSubCategoryService.getMaintenanceSubCategorys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMaintenanceSubCategorys();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMaintenanceSubCategorys();
  }

  deleteItem(row) {
    const id = row.maintenanceSubCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MaintenanceSubCategoryService.delete(id).subscribe(() => {
          this.getMaintenanceSubCategorys();
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

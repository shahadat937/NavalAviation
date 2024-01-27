import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Store } from '../../models/store';
import { StoreService } from '../../service/store.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-store',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.sass']
})
export class StoreListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Store[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<Store> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private StoreService: StoreService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getStores();
  }
 
  getStores() {
    this.isLoading = true;
    this.StoreService.getStores(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getStores();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getStores();
  }

  deleteItem(row) {
    const id = row.storeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.StoreService.delete(id).subscribe(() => {
          this.getStores();
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

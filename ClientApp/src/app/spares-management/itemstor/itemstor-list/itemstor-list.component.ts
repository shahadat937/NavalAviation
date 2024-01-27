import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemStor } from '../../models/ItemStor';
import { ItemStorService } from '../../service/ItemStor.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-itemstor',
  templateUrl: './itemstor-list.component.html',
  styleUrls: ['./itemstor-list.component.sass']
})
export class ItemStorListComponent implements OnInit {

  // masterData = MasterData;
  // ELEMENT_DATA: ItemStor[] = [];
  // isLoading = false;
  
  // paging = {
  //   pageIndex: this.masterData.paging.pageIndex,
  //   pageSize: this.masterData.paging.pageSize,
  //   length: 1
  // }
  // searchText="";

  // displayedColumns: string[] = [ 'ser', 'itemCategoryId', 'itemSerNo','warrantyStartDate', 'warrantyEndDate','itemReceivedDate', 'actions'];
  // dataSource: MatTableDataSource<ItemStor> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private ItemStorService: ItemStorService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getItemStors();
  }
 
  getItemStors() {
    //this.isLoading = true;
    // this.ItemStorService.getItemStors(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
    //   this.dataSource.data = response.items; 
    //   this.paging.length = response.totalItemsCount    
    //   this.isLoading = false;
    // })
  }

  // pageChanged(event: PageEvent) {
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getItemStors();
  // }
  
  // applyFilter(searchText: any){ 
  //   this.searchText = searchText;
  //   this.getItemStors();
  // }

  // deleteItem(row) {
  //   const id = row.itemStorId; 
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
  //     console.log(result);
  //     if (result) {
  //       this.ItemStorService.delete(id).subscribe(() => {
  //         this.getItemStors();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 2000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })
  // }
}

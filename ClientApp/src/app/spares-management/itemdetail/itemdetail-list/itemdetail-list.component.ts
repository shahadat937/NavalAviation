import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemDetail } from '../../models/itemDetail';
import { ItemDetailService } from '../../service/itemDetail.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-itemdetail',
  templateUrl: './itemdetail-list.component.html',
  styleUrls: ['./itemdetail-list.component.sass']
})
export class ItemDetailListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ItemDetail[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser','departmentName', 'partNo', 'imcNumber','nameOfItem', 'alternatiovePrartNo', 'actions'];
  dataSource: MatTableDataSource<ItemDetail> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private ItemDetailService: ItemDetailService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    //this.getItemDetails();
    this.getItemDetailsForSpares();
  }
 
  getItemDetails() {
    this.isLoading = true;
    this.ItemDetailService.getItemDetails(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      console.log(this.dataSource.data);
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  getItemDetailsForSpares() {
    this.isLoading = true;
    this.ItemDetailService.getItemDetailsForTools(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.masterData.sparescategory.spares).subscribe(response => {
      this.dataSource.data = response.items; 
      console.log(this.dataSource.data);
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    //this.getItemDetails();
    this.getItemDetailsForSpares();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    //this.getItemDetails();
    this.getItemDetailsForSpares();
  }

  deleteItem(row) {
    const id = row.itemDetailId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ItemDetailService.delete(id).subscribe(() => {
          //this.getItemDetails();
          this.getItemDetailsForSpares();
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

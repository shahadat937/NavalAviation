import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemCategory } from '../../models/ItemCategory';
import { ItemCategoryService } from '../../service/ItemCategory.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-itemcategory-list',
  templateUrl: './itemcategory-list.component.html',
  styleUrls: ['./itemcategory-list.component.sass'] 
})
export class ItemCategoryListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ItemCategory[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'actions'];
  dataSource: MatTableDataSource<ItemCategory> = new MatTableDataSource();

  selection = new SelectionModel<ItemCategory>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ItemCategoryService: ItemCategoryService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getItemCategorys();
  }
 
  getItemCategorys() {
    this.isLoading = true;
    this.ItemCategoryService.getItemCategorys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getItemCategorys();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getItemCategorys();
  } 

  deleteItem(row) {
    const id = row.itemCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ItemCategoryService.delete(id).subscribe(() => {
          this.getItemCategorys();
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

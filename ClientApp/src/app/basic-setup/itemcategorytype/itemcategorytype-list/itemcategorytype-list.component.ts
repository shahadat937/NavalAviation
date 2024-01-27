import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemCategoryType } from '../../models/ItemCategoryType';
import { ItemCategoryTypeService } from '../../service/ItemCategoryType.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-itemcategorytype-list',
  templateUrl: './itemcategorytype-list.component.html',
  styleUrls: ['./itemcategorytype-list.component.sass']
})
export class ItemCategoryTypeListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ItemCategoryType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks','isActive', 'actions'];
  dataSource: MatTableDataSource<ItemCategoryType> = new MatTableDataSource();

  selection = new SelectionModel<ItemCategoryType>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ItemCategoryTypeService:ItemCategoryTypeService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getItemCategoryTypes();
  }
 
  getItemCategoryTypes() {
    this.isLoading = true;
    this.ItemCategoryTypeService.getItemCategoryTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getItemCategoryTypes();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getItemCategoryTypes();
  } 

  deleteItem(row) {
    const id = row.itemCategoryTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ItemCategoryTypeService.delete(id).subscribe(() => {
          this.getItemCategoryTypes();
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

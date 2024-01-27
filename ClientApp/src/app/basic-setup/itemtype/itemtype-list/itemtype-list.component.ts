import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemType } from '../../models/ItemType';
import { SelectionModel } from '@angular/cdk/collections';
import { ItemTypeService } from '../../service/ItemType.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-itemtype-list',
  templateUrl: './itemtype-list.component.html',
  styleUrls: ['./itemtype-list.component.sass']
})
export class ItemTypeListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ItemType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks','status','isActive', 'actions'];
  dataSource: MatTableDataSource<ItemType> = new MatTableDataSource();

  selection = new SelectionModel<ItemType>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ItemTypeService: ItemTypeService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getItemTypes();
  }
 
  getItemTypes() {
    this.isLoading = true;
    this.ItemTypeService.getItemTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getItemTypes();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getItemTypes();
  } 

  deleteItem(row) {
    const id = row.itemTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ItemTypeService.delete(id).subscribe(() => {
          this.getItemTypes();
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

import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ConditionOfItem } from '../../models/ConditionOfItem';
import { SelectionModel } from '@angular/cdk/collections';
import { ConditionOfItemService } from '../../service/ConditionOfItem.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-conditionofitem-list',
  templateUrl: './conditionofitem-list.component.html',
  styleUrls: ['./conditionofitem-list.component.sass']
})
export class ConditionOfItemListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ConditionOfItem[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<ConditionOfItem> = new MatTableDataSource();

  selection = new SelectionModel<ConditionOfItem>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ConditionOfItemService: ConditionOfItemService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getConditionOfItems();
  }
 
  getConditionOfItems() {
    this.isLoading = true;
    this.ConditionOfItemService.getConditionOfItems(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getConditionOfItems();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getConditionOfItems();
  } 

  deleteItem(row) {
    const id = row.conditionOfItemId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ConditionOfItemService.delete(id).subscribe(() => {
          this.getConditionOfItems();
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

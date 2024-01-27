import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ItemStatus } from '../../models/ItemStatus';
import { ItemStatusService } from '../../service/ItemStatus.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-itemstatus-list',
  templateUrl: './itemstatus-list.component.html',
  styleUrls: ['./itemstatus-list.component.sass']
})
export class ItemStatusListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ItemStatus[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<ItemStatus> = new MatTableDataSource();

  selection = new SelectionModel<ItemStatus>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ItemStatusService: ItemStatusService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getItemStatuss();
  }
 
  getItemStatuss() {
    this.isLoading = true;
    this.ItemStatusService.getItemStatuss(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getItemStatuss();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getItemStatuss();
  } 

  deleteItem(row) {
    const id = row.itemStatusId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ItemStatusService.delete(id).subscribe(() => {
          this.getItemStatuss();
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

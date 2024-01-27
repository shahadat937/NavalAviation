import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ToolsBoxName } from '../../models/ToolsBoxName';
import { ToolsBoxNameService } from '../../service/ToolsBoxName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-toolsboxname-list',
  templateUrl: './toolsboxname-list.component.html',
  styleUrls: ['./toolsboxname-list.component.sass']
})
export class ToolsBoxNameListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ToolsBoxName[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<ToolsBoxName> = new MatTableDataSource();

  selection = new SelectionModel<ToolsBoxName>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ToolsBoxNameService: ToolsBoxNameService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getToolsBoxNames();
  }
 
  getToolsBoxNames() {
    this.isLoading = true;
    this.ToolsBoxNameService.getToolsBoxNames(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getToolsBoxNames();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getToolsBoxNames();
  } 

  deleteItem(row) {
    const id = row.toolsBoxNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ToolsBoxNameService.delete(id).subscribe(() => {
          this.getToolsBoxNames();
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

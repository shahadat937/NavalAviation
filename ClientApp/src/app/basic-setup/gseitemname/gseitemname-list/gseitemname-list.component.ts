import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { GseItemName } from '../../models/GseItemName';
import { GseItemNameService } from '../../service/GseItemName.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-gseitemname',
  templateUrl: './gseitemname-list.component.html',
  styleUrls: ['./gseitemname-list.component.sass']
})
export class GseItemNameListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: GseItemName[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'itemName', 'departmentName', 'remarks', 'actions'];
  dataSource: MatTableDataSource<GseItemName> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private GseItemNameService: GseItemNameService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getGseItemNames();
  }
 
  getGseItemNames() {
    this.isLoading = true;
    this.GseItemNameService.getGseItemNames(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getGseItemNames();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getGseItemNames();
  }

  deleteItem(row) {
    const id = row.gseItemNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      console.log(result);
      if (result) {
        this.GseItemNameService.delete(id).subscribe(() => {
          this.getGseItemNames();
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

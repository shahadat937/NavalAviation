import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Authority } from '../../models/authority';
import { AuthorityService } from '../../service/authority.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-authority',
  templateUrl: './authority-list.component.html',
  styleUrls: ['./authority-list.component.sass']
})
export class AuthorityListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Authority[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<Authority> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private AuthorityService: AuthorityService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getAuthoritys();
  }
 
  getAuthoritys() {
    this.isLoading = true;
    this.AuthorityService.getAuthoritys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getAuthoritys();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getAuthoritys();
  }

  deleteItem(row) {
    const id = row.authorityId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.AuthorityService.delete(id).subscribe(() => {
          this.getAuthoritys();
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

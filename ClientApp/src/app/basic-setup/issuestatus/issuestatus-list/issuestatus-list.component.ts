import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { IssueStatus } from '../../models/IssueStatus';
import { IssueStatusService } from '../../service/IssueStatus.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-issuestatus',
  templateUrl: './issuestatus-list.component.html',
  styleUrls: ['./issuestatus-list.component.sass']
})
export class IssueStatusListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: IssueStatus[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<IssueStatus> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private IssueStatusService: IssueStatusService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getIssueStatuses();
  }
 
  getIssueStatuses() {
    this.isLoading = true;
    this.IssueStatusService.getIssueStatuses(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getIssueStatuses();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getIssueStatuses();
  }

  deleteItem(row) {
    const id = row.issueStatusId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.IssueStatusService.delete(id).subscribe(() => {
          this.getIssueStatuses();
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

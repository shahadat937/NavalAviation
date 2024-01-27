import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ReminderType } from '../../models/ReminderType';
import { ReminderTypeService } from '../../service/ReminderType.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-remindertype',
  templateUrl: './remindertype-list.component.html',
  styleUrls: ['./remindertype-list.component.sass']
})
export class ReminderTypeListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ReminderType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<ReminderType> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private ReminderTypeService: ReminderTypeService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getremindertypes();
  }
 
  getremindertypes() {
    this.isLoading = true;
    this.ReminderTypeService.getremindertype(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getremindertypes();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getremindertypes();
  }

  deleteItem(row) {
    const id = row.reminderTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      console.log(result);
      if (result) {
        this.ReminderTypeService.delete(id).subscribe(() => {
          this.getremindertypes();
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

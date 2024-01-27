import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CallibrationState } from '../../models/CallibrationState';
import { CallibrationStateService } from '../../service/CallibrationState.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-callibrationstate',
  templateUrl: './callibrationstate-list.component.html',
  styleUrls: ['./callibrationstate-list.component.sass']
})
export class CallibrationStateListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: CallibrationState[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'itemName', 'trade', 'lastDateofCalibrated','nextDueDate', 'presentState', 'remarks', 'actions'];
  dataSource: MatTableDataSource<CallibrationState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private CallibrationStateService: CallibrationStateService, private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getCallibrationStates();
  }
 
  getCallibrationStates() {
    this.isLoading = true;
    this.CallibrationStateService.getCallibrationStates(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCallibrationStates();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCallibrationStates();
  }

  deleteItem(row) {
    const id = row.callibrationStateId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.CallibrationStateService.delete(id).subscribe(() => {
          this.getCallibrationStates();
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

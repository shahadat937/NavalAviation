import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MeaSquadronState } from '../../models/MeaSquadronState';
import { MeaSquadronStateService } from '../../service/MeaSquadronState.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-measquadronstate',
  templateUrl: './measquadronstate-list.component.html',
  styleUrls: ['./measquadronstate-list.component.sass']
})
export class MeaSquadronStateListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MeaSquadronState[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'workOrderReceived', 'workOrderDate', 'workshopName','presentState', 'remarks', 'actions'];
  dataSource: MatTableDataSource<MeaSquadronState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private MeaSquadronStateService: MeaSquadronStateService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMeaSquadronStates();
  }
 
  getMeaSquadronStates() {
    this.isLoading = true;
    this.MeaSquadronStateService.getMeaSquadronStates(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMeaSquadronStates();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMeaSquadronStates();
  }

  deleteItem(row) {
    const id = row.meaSquadronStateId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MeaSquadronStateService.delete(id).subscribe(() => {
          this.getMeaSquadronStates();
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

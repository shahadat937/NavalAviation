import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Trade } from '../../models/Trade';
import { TradeService } from '../../service/Trade.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-trade',
  templateUrl: './trade-list.component.html',
  styleUrls: ['./trade-list.component.sass']
})
export class TradeListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Trade[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<Trade> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private TradeService: TradeService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getTrades();
  }
 
  getTrades() {
    this.isLoading = true;
    this.TradeService.getTrade(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTrades();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTrades();
  }

  deleteItem(row) {
    const id = row.tradeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      console.log(result);
      if (result) {
        this.TradeService.delete(id).subscribe(() => {
          this.getTrades();
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

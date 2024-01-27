import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FiscalYear } from '../../models/FiscalYear';
import { FiscalYearService } from '../../service/FiscalYear.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-fiscalYear-list',
  templateUrl: './fiscalYear-list.component.html',
  styleUrls: ['./fiscalYear-list.component.sass']
})
export class FiscalYearListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: FiscalYear[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'fiscalYearName', 'shortName', 'actions'];
  dataSource: MatTableDataSource<FiscalYear> = new MatTableDataSource();

  selection = new SelectionModel<FiscalYear>(true, []);
  
  constructor(private snackBar: MatSnackBar,private FiscalYearService: FiscalYearService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getFiscalYears();
  }
 
  getFiscalYears() {
    this.isLoading = true;
    this.FiscalYearService.getFiscalYears(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getFiscalYears();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getFiscalYears();
  } 

  deleteItem(row) {
    const id = row.fiscalYearId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.FiscalYearService.delete(id).subscribe(() => {
          this.getFiscalYears();
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

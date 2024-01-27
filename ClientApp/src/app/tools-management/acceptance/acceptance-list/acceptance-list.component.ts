import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Acceptance } from '../../models/Acceptance';
import { AcceptanceService } from '../../../spares-management/service/Acceptance.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap/tooltip/tooltip.module';
 

@Component({
  selector: 'app-acceptance',
  templateUrl: './acceptance-list.component.html',
  styleUrls: ['./acceptance-list.component.sass']
})
export class AcceptanceListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Acceptance[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'itemDetail', 'sftQty','demandDate', 'deliveryDate', 'outerLatterNo', 'actions'];
  dataSource: MatTableDataSource<Acceptance> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private AcceptanceService: AcceptanceService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getAcceptances();
  }
 
  getAcceptances() {
    this.isLoading = true;
    this.AcceptanceService.getAcceptances(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.masterData.sparescategory.tools).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getAcceptances();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getAcceptances();
  }

  deleteItem(row) {
    const id = row.acceptanceId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.AcceptanceService.delete(id).subscribe(() => {
          this.getAcceptances();
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

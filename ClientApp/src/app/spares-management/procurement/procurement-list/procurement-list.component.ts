import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Procurement } from '../../models/Procurement';
import { ProcurementService } from '../../service/Procurement.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-procurement',
  templateUrl: './procurement-list.component.html',
  styleUrls: ['./procurement-list.component.sass']
})
export class ProcurementListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Procurement[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'itemDetail','itemName','tenderNumber', 'dateOfTenderFloat', 'dateOfDelivery', 'qty','actions'];
  dataSource: MatTableDataSource<Procurement> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private ProcurementService: ProcurementService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getProcurements();
  }
 
  getProcurements() {
    this.isLoading = true;
    this.ProcurementService.getProcurements(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.masterData.sparescategory.spares).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getProcurements();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getProcurements();
  }

  deleteItem(row) {
    const id = row.procurementId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      console.log(result);
      if (result) {
        this.ProcurementService.delete(id).subscribe(() => {
          this.getProcurements();
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

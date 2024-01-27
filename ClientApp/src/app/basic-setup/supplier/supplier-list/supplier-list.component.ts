import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Supplier } from '../../models/Supplier';
import { SupplierService } from '../../service/Supplier.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-supplier-list',
  templateUrl: './supplier-list.component.html',
  styleUrls: ['./supplier-list.component.sass']
})
export class SupplierListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Supplier[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'companyName', 'presentAddress','phoneNumber','emailAddress','contractPersonName','contractPersonNumber', 'actions'];
  dataSource: MatTableDataSource<Supplier> = new MatTableDataSource();

  selection = new SelectionModel<Supplier>(true, []);
  
  constructor(private snackBar: MatSnackBar,private SupplierService: SupplierService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getSuppliers();
  }
 
  getSuppliers() {
    this.isLoading = true;
    this.SupplierService.getSuppliers(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getSuppliers();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSuppliers();
  } 

  deleteItem(row) {
    const id = row.supplierId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.SupplierService.delete(id).subscribe(() => {
          this.getSuppliers();
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

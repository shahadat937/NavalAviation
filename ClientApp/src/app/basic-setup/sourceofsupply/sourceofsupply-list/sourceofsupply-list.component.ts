import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SourceOfSupply } from '../../models/SourceOfSupply';
import { SourceOfSupplyService } from '../../service/SourceOfSupply.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-sourceofsupply-list',
  templateUrl: './sourceofsupply-list.component.html',
  styleUrls: ['./sourceofsupply-list.component.sass']
})
export class SourceOfSupplyListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: SourceOfSupply[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<SourceOfSupply> = new MatTableDataSource();

  selection = new SelectionModel<SourceOfSupply>(true, []);
  
  constructor(private snackBar: MatSnackBar,private SourceOfSupplyService: SourceOfSupplyService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getSourceOfSupplys();
  }
 
  getSourceOfSupplys() {
    this.isLoading = true;
    this.SourceOfSupplyService.getSourceOfSupplys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getSourceOfSupplys();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSourceOfSupplys();
  } 

  deleteItem(row) {
    const id = row.sourceOfSupplyId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.SourceOfSupplyService.delete(id).subscribe(() => {
          this.getSourceOfSupplys();
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

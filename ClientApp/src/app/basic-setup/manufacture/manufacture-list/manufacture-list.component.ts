import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Manufacture } from '../../models/Manufacture';
import { ManufactureService } from '../../service/Manufacture.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-manufacture-list',
  templateUrl: './manufacture-list.component.html',
  styleUrls: ['./manufacture-list.component.sass']
})
export class ManufactureListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: Manufacture[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<Manufacture> = new MatTableDataSource();

  selection = new SelectionModel<Manufacture>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ManufactureService: ManufactureService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getManufactures();
  }
 
  getManufactures() {
    this.isLoading = true;
    this.ManufactureService.getManufactures(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getManufactures();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getManufactures();
  } 

  deleteItem(row) {
    const id = row.manufactureId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ManufactureService.delete(id).subscribe(() => {
          this.getManufactures();
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

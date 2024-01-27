import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ServiceLifeType } from '../../models/ServiceLifeType';
import { ServiceLifeTypeService } from '../../service/ServiceLifeType.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-servicelifetype-list',
  templateUrl: './servicelifetype-list.component.html',
  styleUrls: ['./servicelifetype-list.component.sass']
})
export class ServiceLifeTypeListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: ServiceLifeType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<ServiceLifeType> = new MatTableDataSource();

  selection = new SelectionModel<ServiceLifeType>(true, []);
  
  constructor(private snackBar: MatSnackBar,private ServiceLifeTypeService: ServiceLifeTypeService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getServiceLifeTypes();
  }
 
  getServiceLifeTypes() {
    this.isLoading = true;
    this.ServiceLifeTypeService.getServiceLifeTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getServiceLifeTypes();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getServiceLifeTypes();
  } 

  deleteItem(row) {
    const id = row.serviceLifeTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ServiceLifeTypeService.delete(id).subscribe(() => {
          this.getServiceLifeTypes();
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

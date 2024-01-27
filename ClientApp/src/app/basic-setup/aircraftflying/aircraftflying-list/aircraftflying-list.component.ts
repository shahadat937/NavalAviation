import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AirCraftFlying } from '../../models/AirCraftFlying';
import { AirCraftFlyingService } from '../../service/AirCraftFlying.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-aircraftflying-list',
  templateUrl: './aircraftflying-list.component.html',
  styleUrls: ['./aircraftflying-list.component.sass']
})
export class AirCraftFlyingListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: AirCraftFlying[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = ['ser', 'departmentName', 'date',  'actions'];
  dataSource: MatTableDataSource<AirCraftFlying> = new MatTableDataSource();

  selection = new SelectionModel<AirCraftFlying>(true, []);

  constructor(private snackBar: MatSnackBar, private AirCraftFlyingService: AirCraftFlyingService, private router: Router, private confirmService: ConfirmService) { }

  ngOnInit() {
    this.getAirCraftFlyings();
  }

  getAirCraftFlyings() {
    this.isLoading = true;
    this.AirCraftFlyingService.getAirCraftFlyings(this.paging.pageIndex, this.paging.pageSize, this.searchText).subscribe(response => {

      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getAirCraftFlyings();
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getAirCraftFlyings();
  }

  deleteItem(row) {
    const id = row.airCraftFlyingId;
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.AirCraftFlyingService.delete(id).subscribe(() => {
          this.getAirCraftFlyings();
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

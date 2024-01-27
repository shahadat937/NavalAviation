import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { PreviousItemStore } from "../../../spares-management/models/PreviousItemStore";
import { PreviousItemStoreService } from "../../../spares-management/service/PreviousItemStore.service";
import { Router } from "@angular/router";
import { ConfirmService } from "src/app/core/service/confirm.service";
import { MasterData } from "src/assets/data/master-data";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: "app-previousitemstore",
  templateUrl: "./previousitemstore-list.component.html",
  styleUrls: ["./previousitemstore-list.component.sass"],
})
export class PreviousItemStoreListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: PreviousItemStore[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "departmentName",
    "itemDetail",
    "itemSerNo",
    "itemCategory",
    "deno",
    "actions",
  ];
  dataSource: MatTableDataSource<PreviousItemStore> = new MatTableDataSource();

  constructor(
    private snackBar: MatSnackBar,
    private PreviousItemStoreService: PreviousItemStoreService,
    private router: Router,
    private confirmService: ConfirmService
  ) {}

  ngOnInit() {
    this.getPreviousItemStores();
  }

  getPreviousItemStores() {
    this.isLoading = true;
    this.PreviousItemStoreService.getPreviousItemStores(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;
    });
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    this.getPreviousItemStores();
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getPreviousItemStores();
  }

  deleteItem(row) {
    const id = row.previousItemStoreId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        console.log(result);
        if (result) {
          this.PreviousItemStoreService.delete(id).subscribe(() => {
            this.getPreviousItemStores();
            this.snackBar.open("Information Deleted Successfully ", "", {
              duration: 2000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-danger",
            });
          });
        }
      });
  }
}

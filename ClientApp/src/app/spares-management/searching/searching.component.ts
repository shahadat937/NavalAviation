import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ItemDetailService } from "../service/itemDetail.service";
import { DemandService } from "../service/Demand.service";
import { ConfirmService } from "src/app/core/service/confirm.service";
import { MasterData } from "src/assets/data/master-data";
import { MatSnackBar } from "@angular/material/snack-bar";
import { AuthService } from "src/app/core/service/auth.service";
import { Role } from "src/app/core/models/role";
import { SelectedModel } from "src/app/core/models/selectedModel";

@Component({
  selector: "app-searching",
  templateUrl: "./searching.component.html",
  styleUrls: ["./searching.component.sass"],
})
export class SearchingComponent implements OnInit {
  masterData = MasterData;
  // ELEMENT_DATA: ItemDetail[] = [];
  isLoading = false;

  selectedDepartmentName: SelectedModel[];

  itemDetailByDepartmentId: any[];
  groupArrays: { departmentName: string; datas: any }[];
  userRole = Role;
  SearchForm: FormGroup;
  itemCount: any = 0;
  searchText: any = '';
  departmentNameId: any = 0;
  nameOfItem: any;
  traineeId: any;
  itemDetailId: number;
  itemCategoryId: number;
  role: any;
  branchId: any;
  showHideDiv = false;
  isShown = false;

  options = [];
  filteredOptions;

  displayedColumns: string[] = [
    "ser",
    "partNo",
    "nameOfItem",
    "trade",
    "minimumStock",
    "purchaseQty",
    "presentStock",
    "issuedQty",
  ];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };

  // dataSource: MatTableDataSource<ItemDetail> = new MatTableDataSource();

  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder,
    private DemandService: DemandService,
    private ItemDetailService: ItemDetailService,
    private confirmService: ConfirmService
  ) {}

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    this.intitializeForm();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);

    if (
      this.role == this.userRole.CO ||
      this.role == this.userRole.SuperAdmin
    ) {
      
      this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
      // this.getselectedPresentStocks(0,this.searchText);
    } else {
      this.SearchForm.get('departmentNameId').setValue(this.branchId);
      this.onDepartmentSelectionChange();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    //this.getItemDetails();
    // this.getItemDetailsForSpares();
  }

  intitializeForm() {
    this.SearchForm = this.fb.group({
      departmentNameId: [],
      itemDetailId: [],
      part: [""],
    });
    //autocomplete
    this.SearchForm.get("part").valueChanges.subscribe((value) => {
      this.getSelectedTraineeByPno(value);
    });
  }

  onDepartmentSelectionChange() {
    // this.isShown = true;
    var departmentNameId = this.SearchForm.value["departmentNameId"];
    this.getPartNoByDepartmentNameId(departmentNameId);
    // this.getDemandsList(departmentNameId, 0);
  }

  getPartNoByDepartmentNameId(id: number) {
    this.ItemDetailService.getPartNoForSparesByDepartmentNameId(id,this.masterData.sparescategory.spares).subscribe((res) => {
      this.filteredOptions = res;
      // this.filteredOptions=this.filteredOptions.filter(x=>x.sparesCategoryId==1)
       console.log("part no list");
      console.log(this.filteredOptions);
    });
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
    // console.log(item);
    this.itemDetailId = item.value;
    this.itemCategoryId = item.value;
    this.SearchForm.get("itemDetailId").setValue(item.value);
    this.SearchForm.get("part").setValue(item.text);
    console.log(item.value);
    console.log("V");
    this.getsearchingByItemDetailId(this.itemDetailId);
  }
  getSelectedTraineeByPno(pno) {
    var departmentNameId = this.SearchForm.value["departmentNameId"];
    this.DemandService.getSelectedPartNoForSpareParameterRequest(pno,departmentNameId,this.masterData.sparescategory.spares).subscribe(
      (response) => {
        this.options = response;
        this.filteredOptions = response;
      }
    );
  }

  GetDepartmentNameById(baseNameId) {
    this.ItemDetailService.getSelectedSchoolName(baseNameId).subscribe(
      (res) => {
        this.selectedDepartmentName = res;
        console.log(res);
      }
    );
  }

  getsearchingByItemDetailId(itemDetailId) {
    this.isShown=true;
    this.ItemDetailService.getsearchingByItemDetailId(itemDetailId).subscribe((res) => {
      this.itemDetailByDepartmentId = res;
      this.nameOfItem = res[0].nameofitem;
      this.itemCount = res.length;
      console.log(this.itemDetailByDepartmentId);

      // this gives an object with dates as keys
      // const groups = this.itemDetailByDepartmentId.reduce((groups, datas) => {
      //   const departmentName = datas.departmentName;
      //   if (!groups[departmentName]) {
      //     groups[departmentName] = [];
      //   }
      //   groups[departmentName].push(datas);
      //   return groups;
      // }, {});

      // // Edit: to add it in the array format instead
      // this.groupArrays = Object.keys(groups).map((departmentName) => {
      //   return {
      //     departmentName,
      //     datas: groups[departmentName],
      //   };
      // });

      // console.log(this.groupArrays);
    });
  }

  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print-routine").innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-action{
                      display: none;
                    }
        
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
                    }
                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Inventory History List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  applyDropdown() {
    // var departmentNameId = 0;
    //var departmentId = this.DemandForm.get("departmentNameId").value;
    if ( this.role == this.userRole.CO || this.role == this.userRole.SuperAdmin ) {
      var departmentId = this.departmentNameId;
    } else {
      var departmentId = this.branchId;
    }
    console.log(departmentId);
    // this.getselectedPresentStocks(this.departmentNameId,this.searchText);
    //this.getDemandsList(departmentId);
  }
  // onDepartmentSelectionChange(){
  //   console.log(this.departmentNameId);
  //   this.getselectedPresentStocks(this.departmentNameId,this.searchText);
  // }
  // applyFilter(searchText: any){
  //   this.searchText = searchText;
  //   //this.getItemDetails();
  //   this.getItemDetailsForSpares();
  // }

  // deleteItem(row) {
  //   const id = row.itemDetailId;
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
  //     console.log(result);
  //     if (result) {
  //       this.ItemDetailService.delete(id).subscribe(() => {
  //         //this.getItemDetails();
  //         this.getItemDetailsForSpares();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 2000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })
  // }
}

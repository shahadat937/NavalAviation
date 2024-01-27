import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { DemandService } from "../../../spares-management/service/Demand.service";
import { ItemDetailService } from "../../../spares-management/service/itemDetail.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ConfirmService } from "../../../core/service/confirm.service";
import { MasterData } from "src/assets/data/master-data";
import { Demand } from "../../models/Demand";
import { MatTableDataSource } from "@angular/material/table";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";
import { AcceptanceService } from "../../service/Acceptance.service";

@Component({
  selector: "app-acceptancebypattno-list",
  templateUrl: "./acceptancebypattno-list.component.html",
  styleUrls: ["./acceptancebypattno-list.component.sass"],
})
export class AcceptanceByPattnoComponent implements OnInit {
  pageTitle: string;
  destination: string;
  btnText: string;
  DemandForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel: SelectedModel[];
  selectedAuthority: SelectedModel[];
  selectedItemDetails: SelectedModel[];
  selectedDeno: SelectedModel[];
  selectedDemandStaus: SelectedModel[];
  selectedTrade: SelectedModel[];
  groupArrays: { departmentName: string; datas: any }[];
  selectedItemCategory: SelectedModel[];
  selectedSupplierValue: SelectedModel[];
  selectedFiscalYear: SelectedModel[];
  selectedItemType: SelectedModel[];
  selectedOccasionOfDemand: SelectedModel[];
  selectedDemandAuthority: SelectedModel[];
  selectedDepartmentName: SelectedModel[];
  selectedConditionOfItem: SelectedModel[];
  selectedTypeOfDemandValue: SelectedModel[];
  selectedManufacture: SelectedModel[];
  selectedPartNo: SelectedModel[];
  selectedItemName: SelectedModel[];
  itemValue: string;
  itemCount: any = 0;
  itemDetailId: number;
  itemCategoryId: number;
  sparesCategoryId: 1;
  options = [];
  filteredOptions;
  isShown: boolean = false;
  isConditionShown: boolean = false;
  masterData = MasterData;
  acceptanceListbyPattno: any[];
  pattNo:any;
  itemName:any;
  isLoading = false;
  status: any;
  showHideDiv = false;
  userRole = Role;

  traineeId: any;
  role: any;
  branchId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  displayedColumns: string[] = [
    "ser",
    "itemDetail",
    "itemName",
    "conditionOfItem",
    "deno",
    "demandQty",
    "demandNo",
    "demandDate",
    "refPrice",
    "actions",
  ];
  dataSource: MatTableDataSource<Demand> = new MatTableDataSource();
  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private itemDetailsService: ItemDetailService,
    private acceptanceService: AcceptanceService,
    private confirmService: ConfirmService,
    private DemandService: DemandService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("demandId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.DemandForm.get("departmentNameId").setValue(this.branchId);
      this.onDepartmentSelectionChange();
    }
 
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);

  }
  intitializeForm() {
    this.DemandForm = this.fb.group({      
      part: [""],
      itemDetailId: [""],
      departmentNameId: [""],     
    });
    //autocomplete
    this.DemandForm.get("part").valueChanges.subscribe((value) => {
      this.getSelectedTraineeByPno(value);
    });
  }

  getPartNoPassItemCategoryIdInDemand(itemDetailId: number) {
    this.DemandService.getPartNoPassItemCategoryIdInDemand(
      itemDetailId
    ).subscribe((res) => {
      this.selectedItemDetails = res;
      console.log(this.filteredOptions);
    });
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
    console.log(item);
    this.DemandForm.get("itemDetailId").setValue(item.value);
    this.DemandForm.get("part").setValue(item.text);

    this.acceptanceService.getAcceptanceListByPattNo(item.value).subscribe((res) => {
      this.acceptanceListbyPattno = res;
      this.pattNo = res[0].partNo;
      this.itemName = res[0].nameOfItem;
      console.log(this.pattNo, this.itemName);
      console.log(this.acceptanceListbyPattno);
      this.itemCount = res.length;
    });
    
  }
  
  getSelectedTraineeByPno(pno) {
    var departmentNameId = this.DemandForm.value["departmentNameId"];
    this.DemandService.getSelectedPartNoForSpareParameterRequest(pno,departmentNameId,1).subscribe(
      (response) => {
        this.options = response;
        this.filteredOptions = response;
      }
    );
  }
  GetDepartmentNameById(baseNameId) {
    this.DemandService.getSelectedSchoolName(baseNameId).subscribe((res) => {
      this.selectedDepartmentName = res;
      console.log(res);
    });
  }
  
  getPartNoByDepartmentNameId(id: number) {
    this.itemDetailsService.getPartNoByDepartmentNameId(id).subscribe((res) => {
      this.filteredOptions = res;
      console.log(this.filteredOptions);
    });
  }
  onDepartmentSelectionChange() {
    this.isShown = true;
    var departmentNameId = this.DemandForm.value["departmentNameId"];
    this.getPartNoByDepartmentNameId(departmentNameId);
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
                    
                    .table.table.tbl-by-group.db-li-s-in tr .fa-file-pdf tbl-pdf {
                    display:none;
                  }
                  .table.table.tbl-by-group.db-li-s-in tr .btn-tbl-edit {
                    display:none;
                  }
                  .table.table.tbl-by-group.db-li-s-in tr .btn-tbl-delete {
                    display:none;
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
          <h3>Acceptance List By Patt No</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  
}

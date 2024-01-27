import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { ProcurementService } from "../../service/Procurement.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { DepartmentNameService } from "../../../basic-setup/service/DepartmentName.service";
import { DemandService } from "../../../tools-management/service/Demand.service";
import { Demand } from "../../models/Demand";
import { MasterData } from "src/assets/data/master-data";
import { MatTableDataSource } from "@angular/material/table";
import { Procurement } from "../../models/Procurement";
import { DatePipe } from "@angular/common";
import { Role } from "src/app/core/models/role";
import { AuthService } from "src/app/core/service/auth.service";

@Component({
  selector: "app-new-procurement",
  templateUrl: "./new-procurement.component.html",
  styleUrls: ["./new-procurement.component.sass"],
})
export class NewProcurementComponent implements OnInit {
  pageTitle: string;
  masterData = MasterData;
  destination: string;
  btnText: string;
  ProcurementForm: FormGroup;
  validationErrors: string[] = [];
  itemDetail: SelectedModel[];
  procurementStatus: SelectedModel[];
  SupplierM: SelectedModel[];
  Supplier: SelectedModel[];
  SupplierA: SelectedModel[];
  partOfShipment: SelectedModel[];
  selectedItemDetails: SelectedModel[];
  departmentName: SelectedModel[];
  groupArrays: { departmentName: string; datas: any }[];
  principalName: SelectedModel[];
  selectManufacture: SelectedModel[];
  cstTec: SelectedModel[];
  selectedPartNo: SelectedModel[];
  isShown: boolean = false;
  demandData: Demand[];
  itemDetailId: number;
  demandTypeId:number;
  itemCategoryId: number;
  sparesCategoryId: number;
  isLoading = false;
  searchText = "";
  cstTecYes: any;
  currentDateTime: any;

  showHideDiv = false;

  itemCount: any = 0;

  userRole = Role;

  traineeId: any;
  role: any;
  branchId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };

  displayedDepColumns: string[] = [
    "ser",
    "itemDetail",
    "itemName",
    "qty",
    "dateOfDelivery",
    "supplier",
    "actions",
  ];
  dataSource: MatTableDataSource<Procurement> = new MatTableDataSource();
  displayedColumns: string[] = [
    "sl",
    "itemName",
    "deno",
    "demandQty",
    "conditionOfItem",
    "authority",
    "occasionOfDemand",
    "manufacture",
  ];

  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private datepipe: DatePipe,
    private DemandService: DemandService,
    private DepartmentNameService: DepartmentNameService,
    private confirmService: ConfirmService,
    private ProcurementService: ProcurementService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    const id = this.route.snapshot.paramMap.get("procurementId");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    if (id) {
      this.pageTitle = "Edit Procurement";
      this.destination = "Edit";
      this.btnText = "Update";
      this.ProcurementService.find(+id).subscribe((res) => {
        this.ProcurementForm.patchValue({
          procurementId: res.procurementId,
          demandId: res.demandId,
          demandTypeId:res.demandTypeId,
          itemDetailId: res.itemDetailId,
          itemCategoryId: res.itemCategoryId,
          //procurementStatusId: res.procurementStatusId,
          //principalNameId: res.principalNameId,
          //manufactureId:res.manufactureId,
          cstTecId: res.cstTecId,
          //localAgentId: res.localAgentId,
          supplierId: res.supplierId,
          //supplierAId:res.supplierAId,
          //supplierMId:res.supplierMId,
          partOfShipmentId: res.partOfShipmentId,
          departmentNameId: res.departmentNameId,
          sparesCategoryId: res.sparesCategoryId,
          tenderNumber: res.tenderNumber,
          dateOfTenderFloat: res.dateOfTenderFloat,
          tenderopeningDate: res.tenderopeningDate,
          workOrderDate: res.workOrderDate,
          //tenderPublishDate: res.tenderPublishDate,
          tenderNotice: res.tenderNotice,
          tenderSpecification: res.tenderSpecification,
          financialApproval: res.financialApproval,
          workOrder: res.workOrder,
          dateOfDelivery: res.dateOfDelivery,
          unitPrice: res.unitPrice,
          qty: res.qty,
          remarks: res.remarks,
          procurementDocument: res.procurementDocument,
          //status: res.status,
          //menuPosition: res.menuPosition,
          isActive: res.isActive,
        });
        this.getselectedDemandsOnUpdate(res.departmentNameId);
        this.getDemandData();
        //this.getPartNoPassItemCategoryIdInProcurement(this.itemDetailId);
        //this.getselectedDemands();
      });
    } else {
      this.pageTitle = "Create  Procurement";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();
    if (this.role != this.userRole.SuperAdmin) {
      this.ProcurementForm.get("departmentNameId").setValue(this.branchId);
      this.getselectedDemands();
    }

    if (this.role == this.userRole.CO) {
      this.isShown = true;
      this.getProcurementsList(0);
    }
  }
  intitializeForm() {
    this.ProcurementForm = this.fb.group({
      procurementId: [0],
      demandId: [],
      demandTypeId:[],
      itemDetailId: [],
      itemCategoryId: [],
      //procurementStatusId: [],
      principalNameId: [""],
      manufactureId: [""],
      cstTecId: [],
      //localAgentId: [],
      supplierId: [""],
      //supplierAId:[],
      //supplierMId:[],
      //partOfShipmentId: [],
      departmentNameId: [],
      sparesCategoryId: [],
      tenderNumber: [""],
      workOrderDate: [],
      dateOfTenderFloat: [],
      procurementCompleteStatus: [0],
      tenderopeningDate: [],
      //tenderPublishDate: [],
      tenderNotice: [""],
      notice: [""],
      tenderSpecification: [""],
      doc: [""],
      financialApproval: [""],
      approval: [""],
      workOrder: [""],
      order: [""],
      dateOfDelivery: [],
      unitPrice: [""],
      qty: [""],
      sftQty: [0],
      remarks: [""],
      procurementDocument: [""],
      prDoc: [""],
      //status: [],
      // menuPosition: [],
      isActive: [true],
    });
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.getselectedItemDetails();
    this.getselectedPrincipalNames();
    this.getselectedManufacture();
    this.getselectedSupplier();
    // this.getselectedSupplierA();
    this.getselectedPartOfShipments();
    // this.getselectedSupplierM();
    this.getselectedCstTecs();
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.ProcurementForm.patchValue({
        doc: file,
      });
    }
  }
  onFileNChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.ProcurementForm.patchValue({
        notice: file,
      });
    }
  }
  onFileFChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.ProcurementForm.patchValue({
        prDoc: file,
      });
    }
  }
  // onFileWChanged(event) {
  //   if (event.target.files.length > 0) {
  //     const file = event.target.files[0];
  //    //console.log(file);
  //     this.ProcurementForm.patchValue({
  //       order: file,
  //     });
  //   }
  // }

  inActiveItem(row){
    const id = row.procurementId; 
          this.confirmService.confirm('Confirm Approved message', 'Are You Sure Approved This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.ProcurementService.approvedProcurement(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.getProcurementsList(row.departmentNameId);
            this.snackBar.open('Information Approved Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    
}
  GetDepartmentNameById(baseNameId) {
    this.DepartmentNameService.getSelectedSchoolName(baseNameId).subscribe(
      (res) => {
        this.departmentName = res;
        console.log(res);
      }
    );
  }

  applyDropdown(searchText: any, departmentNameId: any) {
    this.searchText = searchText;
    //var departmentId = departmentNameId;
    //var departmentId = this.DemandForm.get("departmentNameId").value;
    console.log(searchText, departmentNameId);
    this.getProcurementsList(departmentNameId);
    //this.getDemandsList(departmentId);
  }

  getselectedItemDetails() {
    this.ProcurementService.getselectedItemDetails().subscribe((res) => {
      this.itemDetail = res;
    });
  }

  getselectedPrincipalNames() {
    this.ProcurementService.getselectedPrincipalNames().subscribe((res) => {
      this.principalName = res;
    });
  }
  getselectedManufacture() {
    this.ProcurementService.getselectedManufacture().subscribe((res) => {
      this.selectManufacture = res;
    });
  }
  // getselectedLocalAgents(){
  //   this.ProcurementService.getselectedLocalAgents().subscribe(res=>{
  //     this.localAgent=res;
  //   });
  // }
  getselectedSupplier() {
    this.ProcurementService.getselectedSupplier().subscribe((res) => {
      this.Supplier = res;
    });
  }
  reloadSuppliers() {
    console.log("reloading");
    this.getselectedSupplier();
  }
  // getselectedSupplierA(){
  //   this.ProcurementService.getselectedSupplierA().subscribe(res=>{
  //     this.SupplierA=res;
  //   });
  // }
  // getselectedSupplierM(){
  //   this.ProcurementService.getselectedSupplierM().subscribe(res=>{
  //     this.SupplierM=res;
  //   });
  // }
  getselectedPartOfShipments() {
    this.ProcurementService.getselectedPartOfShipments().subscribe((res) => {
      this.partOfShipment = res;
    });
  }

  getselectedDemands() {
    var departmentNameId = this.ProcurementForm.value["departmentNameId"];
    this.isShown = true;
    this.ProcurementService.getselectedDemands(
      departmentNameId,
      this.masterData.sparescategory.tools
    ).subscribe((res) => {
      this.selectedPartNo = res;
    });
    this.getProcurementsList(departmentNameId);
  }

  getselectedDemandsOnUpdate(id) {
    this.ProcurementService.getselectedDemandsOnUpdate(
      id,
      this.masterData.sparescategory.tools
    ).subscribe((res) => {
      this.selectedPartNo = res;
      //console.log(this.selectedPartNo)
    });
  }

  getselectedCstTecs() {
    this.ProcurementService.getselectedCstTecs().subscribe((res) => {
      this.cstTec = res;
    });
  }
  getPartNoPassItemCategoryIdInProcurement(itemDetailId: number) {
    this.ProcurementService.getPartNoPassItemCategoryIdInProcurement(
      itemDetailId
    ).subscribe((res) => {
      this.selectedPartNo = res;
      //console.log(this.filteredOptions);
    });
  }

  getDemandData() {
    var demandId = this.ProcurementForm.value["demandId"];
    console.log(demandId);
    this.isShown = true;
    this.DemandService.GetselectedDemandById(demandId).subscribe((res) => {
      this.demandData = res;
      var demandId = this.ProcurementForm.value["demandId"];
      this.getPartNoPassItemCategoryIdInProcurement(demandId);
      console.log(demandId);
      console.log("demand result " + this.demandData);
    });

    this.DemandService.find(demandId).subscribe((res) => {
      this.itemDetailId = res.itemDetailId;
      this.demandTypeId=res.demandTypeId;
      this.sparesCategoryId = res.sparesCategoryId;
      this.ProcurementForm.get("demandTypeId").setValue(this.demandTypeId);
      this.ProcurementForm.get("itemDetailId").setValue(this.itemDetailId);
      this.ProcurementForm.get("sparesCategoryId").setValue(
        this.sparesCategoryId
      );
      this.ProcurementForm.get("itemCategoryId").setValue(res.itemCategoryId);
    });
  }
  getDateColor(dateFrom: any) {
    //Date dateTime11 = Convert.ToDateTime(dateFrom);
    this.currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    var date1 = new Date(dateFrom);
    var date2 = new Date(this.currentDateTime);
    if (date2 >= date1) {
      return "red";
    } else {
      return "black";
    }
  }
  oncstTecYes(dropdown) {
    if (dropdown.isUserInput) {
      //this.getProcurementsList(dropdown.source.value);
      this.cstTecYes = dropdown.source.value;
      console.log(this.cstTecYes);
    }
  }
  getProcurementsList(departmentId) {
    this.isLoading = true;
    this.ProcurementService.getProcurementListByDepartmentNameId(
      this.paging.pageIndex,
      100000,
      this.searchText,
      this.masterData.sparescategory.tools,
      departmentId
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      this.itemCount = response.items.length;
      //console.log("dddddd");
      console.log(this.dataSource.data);
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;

      // this gives an object with dates as keys
      const groups = this.dataSource.data.reduce((groups, datas) => {
        const departmentName = datas.departmentName;
        if (!groups[departmentName]) {
          groups[departmentName] = [];
        }
        groups[departmentName].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          datas: groups[departmentName],
        };
      });

      console.log(this.groupArrays);
    });
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    var departmentId = this.ProcurementForm.get("departmentNameId").value;
    console.log(departmentId);
    this.getProcurementsList(departmentId);
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
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
            body{  
              width: 99%;
            }
            
            label { 
              font-weight: 400;
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
            }
                      
            .table.table.tbl-by-group.db-li-s-in tr .fa-file-pdf tbl-pdf {
              display:none;
              padding: 0px 5px;
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
          <h3>AUnder Procurement List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    const id = this.ProcurementForm.get("procurementId").value;
    console.log(this.ProcurementForm.value);
    this.ProcurementForm.get("dateOfTenderFloat").setValue(
      new Date(
        this.ProcurementForm.get("dateOfTenderFloat").value
      ).toUTCString()
    );
    this.ProcurementForm.get("tenderopeningDate").setValue(
      new Date(
        this.ProcurementForm.get("tenderopeningDate").value
      ).toUTCString()
    );
    this.ProcurementForm.get("workOrderDate").setValue(
      new Date(this.ProcurementForm.get("workOrderDate").value).toUTCString()
    );
    this.ProcurementForm.get("dateOfDelivery").setValue(
      new Date(this.ProcurementForm.get("dateOfDelivery").value).toUTCString()
    );

    console.log(this.ProcurementForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.ProcurementForm.value)) {
      const value = this.ProcurementForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item")
        .subscribe((result) => {
          if (result) {
            this.ProcurementService.update(+id, formData).subscribe(
              (response) => {
                this.router.navigateByUrl("/tools-management/add-procurement");
                this.snackBar.open("Information Updated Successfully ", "", {
                  duration: 2000,
                  verticalPosition: "bottom",
                  horizontalPosition: "right",
                  panelClass: "snackbar-success",
                });
              },
              (error) => {
                this.validationErrors = error;
              }
            );
          }
        });
    } else {
      this.ProcurementService.submit(formData).subscribe(
        (response) => {
          //this.router.navigateByUrl('/tools-management/procurement-list');
          this.reloadCurrentRoute();
          this.snackBar.open("Information Inserted Successfully ", "", {
            duration: 2000,
            verticalPosition: "bottom",
            horizontalPosition: "right",
            panelClass: "snackbar-success",
          });
        },
        (error) => {
          this.validationErrors = error;
        }
      );
    }
  }
  deleteItem(row) {
    const id = row.procurementId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        console.log(result);
        if (result) {
          this.ProcurementService.delete(id).subscribe(() => {
            //this.getProcurements();
            this.reloadCurrentRoute();
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


// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { MatSnackBar } from '@angular/material/snack-bar';
// import { ActivatedRoute, Router } from '@angular/router';
// import { ProcurementService } from '../../service/Procurement.service';
// import { ConfirmService } from '../../../core/service/confirm.service';
// import { SelectedModel } from 'src/app/core/models/selectedModel';
// import { DepartmentNameService } from '../../../basic-setup/service/DepartmentName.service';
// import { DemandService } from '../../../spares-management/service/Demand.service';
// import { Demand } from '../../models/Demand';
// import { MasterData } from 'src/assets/data/master-data';
// import { MatTableDataSource } from '@angular/material/table';
// import { Procurement } from '../../models/Procurement';
// import { Role } from 'src/app/core/models/role';
// import { AuthService } from 'src/app/core/service/auth.service';

// @Component({
//   selector: 'app-new-procurement',
//   templateUrl: './new-procurement.component.html',
//   styleUrls: ['./new-procurement.component.sass']
// })
// export class NewProcurementComponent implements OnInit {
//   pageTitle: string;
//   masterData = MasterData;
//   destination:string;
//   btnText:string;
//   ProcurementForm: FormGroup;
//   validationErrors: string[] = [];
//   itemDetail: SelectedModel[];
//   procurementStatus: SelectedModel[];
//   principalName: SelectedModel[];
//   selectManufacture: SelectedModel[];
//   Supplier: SelectedModel[];
//   partOfShipment: SelectedModel[];
//   departmentName: SelectedModel[];
//   cstTec: SelectedModel[];
//   selectedPartNo: SelectedModel[];
//   isShown: boolean = false ;
//   demandData: Demand[];
//   itemDetailId: number;
//   sparesCategoryId: number;
//   isLoading = false;
//   cstTecYes:any;
  
  
//   userRole = Role;
  
//   traineeId:any;
//   role:any;
//   branchId:any;
  
//   searchText="";
//   paging = {
//     pageIndex: this.masterData.paging.pageIndex,
//     pageSize: this.masterData.paging.pageSize,
//     length: 1
//   }

//   displayedDepColumns: string[] = [ 'ser', 'itemDetail','itemName','qty','dateOfDelivery', 'supplier', 'actions'];
//   dataSource: MatTableDataSource<Procurement> = new MatTableDataSource();
//   displayedColumns: string[] = ['sl','itemName','deno', 'demandQty', 'conditionOfItem','authority', 'occasionOfDemand', 'manufacture'];

//   constructor(private snackBar: MatSnackBar,private authService: AuthService,private DemandService:DemandService,private DepartmentNameService: DepartmentNameService,private confirmService: ConfirmService,private ProcurementService: ProcurementService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

//   ngOnInit(): void {
//     const id = this.route.snapshot.paramMap.get('procurementId'); 
    
//     this.role = this.authService.currentUserValue.role.trim();
//     this.traineeId =  this.authService.currentUserValue.traineeId.trim();
//     this.branchId =  this.authService.currentUserValue.branchId.trim();
//     console.log(this.role, this.traineeId,  this.branchId)

//     if (id) {
//       this.pageTitle = 'Edit Procurement';
//       this.destination = "Edit";
//       this.btnText = 'Update';
//       this.ProcurementService.find(+id).subscribe(
//         res => {
//           this.ProcurementForm.patchValue({          
//             procurementId: res.procurementId,
//             demandId: res.demandId,
//             itemDetailId: res.itemDetailId,
//             procurementStatusId: res.procurementStatusId,
//             //principalNameId: res.principalNameId,
//             //principalNameId: res.principalNameId,
//             //manufactureId:res.manufactureId,
//             cstTecId:res.cstTecId,
//             //localAgentId: res.localAgentId,
//             supplierId: res.supplierId,
//             //supplierAId:res.supplierAId,
//             //supplierMId:res.supplierMId,
//             //partOfShipmentId: res.partOfShipmentId,
//             sparesCategoryId: res.sparesCategoryId,
//             departmentNameId: res.departmentNameId,
//             tenderNumber: res.tenderNumber,
//             dateOfTenderFloat: res.dateOfTenderFloat,
//             tenderopeningDate: res.tenderopeningDate,
//             tenderPublishDate: res.tenderPublishDate,
//             tenderNotice: res.tenderNotice,
//             tenderSpecification: res.tenderSpecification,
//             financialApproval: res.financialApproval,
//             workOrder: res.workOrder,
//             dateOfDelivery: res.dateOfDelivery,
//             unitPrice: res.unitPrice,
//             qty: res.qty,
//             remarks: res.remarks,
//             procurementDocument: res.procurementDocument,
//             status: res.status,
//             menuPosition: res.menuPosition,
//             isActive: res.isActive
//           }); 
//           this.getselectedDemandsOnUpdate(res.departmentNameId);
//           this.getDemandData();
//         }
//       );
//     } else {
//       this.pageTitle = 'Create  Procurement';
//       this.destination = "Add";
//       this.btnText = 'Save';
//     }
//     this.intitializeForm();
//     if(this.role != this.userRole.SuperAdmin){
//       this.ProcurementForm.get('departmentNameId').setValue(this.branchId);
//       this.getselectedDemands();
//     }
//   }
//   intitializeForm() {
//     this.ProcurementForm = this.fb.group({
      
//       procurementId: [0],
//       demandId: [],
//       itemDetailId: [],
//       //procurementStatusId: [],
//       principalNameId: [''],
//       manufactureId:[''],
//       cstTecId: [],
//       //localAgentId: [],
//       supplierId:[''],
//       //supplierAId:[],
//       //supplierMId:[],
//       //partOfShipmentId: [],
//       sparesCategoryId: [],
//       departmentNameId: [],
//       tenderNumber: [''],
//       dateOfTenderFloat: [],
//       tenderopeningDate: [],
//       //tenderPublishDate: [],
//       tenderNotice: [''],
//       notice:[''],
//       procurementCompleteStatus:[0],
//       tenderSpecification: [''],
//       doc:[''],
//       financialApproval: [''],
//       approval:[''],
//       workOrder: [''],
//       order:[''],
//       dateOfDelivery: [],
//       unitPrice: [''],
//       qty: [''],
//       remarks: [''],
//       procurementDocument: [''],
//       prDoc:[''],
//      // status: [],
//       //menuPosition: [],
//       isActive: [true]
//     })
//     this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
//     this.getselectedItemDetails();
//     this.getselectedSupplier();
//     this.getselectedPrincipalNames();
//     this.getselectedManufacture();
//     this.getselectedPartOfShipments();
//     //this.getselectedDemands();
//     this.getselectedCstTecs();
//   }

//   onFileChanged(event) {
//     if (event.target.files.length > 0) {
//       const file = event.target.files[0];
//       this.ProcurementForm.patchValue({
//         doc: file,
//       });
//     }
//   }
//   onFileNChanged(event) {
//     if (event.target.files.length > 0) {
//       const file = event.target.files[0];
//       this.ProcurementForm.patchValue({
//         notice: file,
//       });
//     }
//   }
//   onFileFChanged(event) {
//     if (event.target.files.length > 0) {
//       const file = event.target.files[0];
//       this.ProcurementForm.patchValue({
//         prDoc: file,
//       });
//     }
//   }
//   // getselectedDepertments(){
//   //   this.DepartmentNameService.getselectedDepertments().subscribe(res=>{
//   //     this.departmentName=res;
//   //   });    
//   // }
//   oncstTecYes(dropdown){

//     if(dropdown.isUserInput) {
//       //this.getProcurementsList(dropdown.source.value);
//       this.cstTecYes=dropdown.source.value;
//       console.log(this.cstTecYes)
//     }
//   }
//   getselectedManufacture(){
//     this.ProcurementService.getselectedManufacture().subscribe(res=>{
//       this.selectManufacture=res;
//     }); 
//   }
//   getselectedPrincipalNames(){
//     this.ProcurementService.getselectedPrincipalNames().subscribe(res=>{
//       this.principalName=res;
//     });  
//   }
//   GetDepartmentNameById(baseNameId){    
//     this.DepartmentNameService.getSelectedSchoolName(baseNameId).subscribe(res=>{
//       this.departmentName=res
//       console.log(res)
//     }); 
//   }

//   getselectedItemDetails(){
//     this.ProcurementService.getselectedItemDetails().subscribe(res=>{
//       this.itemDetail=res;
//     });    
//   }

//   // getselectedPrincipalNames(){
//   //   this.ProcurementService.getselectedPrincipalNames().subscribe(res=>{
//   //     this.principalName=res;
//   //   });  
//   // }
//   // getselectedProcurementStatus(){
//   //   this.ProcurementService.getselectedProcurementStatus().subscribe(res=>{
//   //     this.procurementStatus=res;
//   //   }); 
//   // }
//   // getselectedLocalAgents(){
//   //   this.ProcurementService.getselectedLocalAgents().subscribe(res=>{
//   //     this.localAgent=res;
//   //   }); 
//   // }
//   getselectedSupplier(){
//     this.ProcurementService.getselectedSupplier().subscribe(res=>{
//       this.Supplier=res;
//     }); 
//   }
//   // getselectedSupplierA(){
//   //   this.ProcurementService.getselectedSupplierA().subscribe(res=>{
//   //     this.SupplierA=res;
//   //   }); 
//   // }
//   // getselectedSupplierM(){
//   //   this.ProcurementService.getselectedSupplierM().subscribe(res=>{
//   //     this.SupplierM=res;
//   //   }); 
//   // }
//   getselectedPartOfShipments(){
//     this.ProcurementService.getselectedPartOfShipments().subscribe(res=>{
//       this.partOfShipment=res;
//     }); 
//   }

//   getselectedDemands(){
//     var departmentNameId = this.ProcurementForm.value['departmentNameId'];
//     this.isShown=true;
//     //this.getProcurementsList(departmentNameId);
//     this.ProcurementService.getselectedDemands(departmentNameId, this.masterData.sparescategory.tools).subscribe(res=>{
//       this.selectedPartNo=res;
//     });
//     this.getProcurementsList(departmentNameId);
//   }

//   getselectedDemandsOnUpdate(id){
//     this.ProcurementService.getselectedDemandsOnUpdate(id, this.masterData.sparescategory.tools).subscribe(res=>{
//       this.selectedPartNo=res;
//       console.log(this.selectedPartNo)
//     });
//   }

//   getselectedCstTecs(){
//     this.ProcurementService.getselectedCstTecs().subscribe(res=>{
//       this.cstTec=res;
//     }); 
//   }

//   getDemandData(){
//     var demandId = this.ProcurementForm.value['demandId'];
//     console.log(demandId);
//     this.isShown=true;
//     this.DemandService.GetselectedDemandById(demandId).subscribe(res=>{
//       this.demandData=res;
      
//       console.log("demand result "+this.demandData)
//     });

//     this.DemandService.find(demandId).subscribe(res=>{
//       this.itemDetailId=res.itemDetailId;
//       this.sparesCategoryId=res.sparesCategoryId;
//       this.ProcurementForm.get('itemDetailId').setValue(this.itemDetailId);
//       this.ProcurementForm.get('sparesCategoryId').setValue(this.sparesCategoryId);
//     });
    
//   }
//   // onDepartmentNameSelectionChange(dropdown){
//   //   this.isShown=true;
//   //   if(dropdown.isUserInput) {
//   //     this.getProcurementsList(dropdown.source.value);
    
//   //   }
//   // }
//   getProcurementsList(departmentId) {
//     this.isLoading = true;
//     this.ProcurementService.getProcurementListByDepartmentNameId(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.masterData.sparescategory.spares,departmentId).subscribe(response => {
      
//       this.dataSource.data = response.items;
//       //console.log("dddddd");
//       console.log(this.dataSource.data )
//       this.paging.length = response.totalItemsCount    
//       this.isLoading = false;
//     })
//   }
  
//   applyFilter(searchText: any){ 
//     this.searchText = searchText;
//     var departmentId=this.ProcurementForm.get('departmentNameId').value;
//     console.log(departmentId);
//     this.getProcurementsList(departmentId);
//   }

//   reloadCurrentRoute() {
//     let currentUrl = this.router.url;
//     this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
//         this.router.navigate([currentUrl]);
//     });
//   }
  
//   onSubmit() {
//     const id = this.ProcurementForm.get('procurementId').value;   
//     //console.log(this.ProcurementForm.value)
//     this.ProcurementForm.get('dateOfTenderFloat').setValue((new Date(this.ProcurementForm.get('dateOfTenderFloat').value)).toUTCString()) ;
//     this.ProcurementForm.get('tenderopeningDate').setValue((new Date(this.ProcurementForm.get('tenderopeningDate').value)).toUTCString()) ;
//     this.ProcurementForm.get('dateOfDelivery').setValue((new Date(this.ProcurementForm.get('dateOfDelivery').value)).toUTCString()) ;
//     this.ProcurementForm.get('dateOfDelivery').setValue((new Date(this.ProcurementForm.get('dateOfDelivery').value)).toUTCString()) ;
//     console.log('mmmmm')
//     console.log(this.ProcurementForm.value)

//     const formData = new FormData();
//     for (const key of Object.keys(this.ProcurementForm.value)) {
//       const value = this.ProcurementForm.value[key];
//       formData.append(key, value);
//     }
//     if (id) {
//       this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
//         if (result) {
//           this.ProcurementService.update(+id,formData).subscribe(response => {
//             this.router.navigateByUrl('/tools-management/add-procurement');
//             this.snackBar.open('Information Updated Successfully ', '', {
//               duration: 2000,
//               verticalPosition: 'bottom',
//               horizontalPosition: 'right',
//               panelClass: 'snackbar-success'
//             });
//           }, error => {
//             this.validationErrors = error;
//           })
//         }
//       })
//     } else {
//       this.ProcurementService.submit(formData).subscribe(response => {
//         //this.router.navigateByUrl('/tools-management/procurement-list');
//         this.reloadCurrentRoute();
//         this.snackBar.open('Information Inserted Successfully ', '', {
//           duration: 2000,
//           verticalPosition: 'bottom',
//           horizontalPosition: 'right',
//           panelClass: 'snackbar-success'
//         });
//       }, error => {
//         this.validationErrors = error;
//       })
//     }
 
//   }
//   deleteItem(row) {
//     const id = row.procurementId; 
//     this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
//       console.log(result);
//       if (result) {
//         this.ProcurementService.delete(id).subscribe(() => {
//           //this.getProcurements();
//           this.reloadCurrentRoute();
//           this.snackBar.open('Information Deleted Successfully ', '', {
//             duration: 2000,
//             verticalPosition: 'bottom',
//             horizontalPosition: 'right',
//             panelClass: 'snackbar-danger'
//           });
//         })
//       }
//     })
//   }

// }

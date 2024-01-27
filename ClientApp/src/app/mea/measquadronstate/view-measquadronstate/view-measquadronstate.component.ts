import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MeaSquadronState } from '../../models/MeaSquadronState';
import { MeaSquadronStateService } from '../../service/MeaSquadronState.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-measquadronstate',
  templateUrl: './view-measquadronstate.component.html',
  styleUrls: ['./view-measquadronstate.component.sass']
})
export class ViewMeaSquadronStateComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MeaSquadronState[] = [];
  isLoading = false;
  meaSquadronStateId: number;
  departmentNameId: number;
  departmentName:string;
  pattNo:string;
  itemName:string;
  trad:string;
  itemCondition:string;
  tradeId:string;
  workOrderNo:string;
  dateofSubmition:Date;
  dateOfDiscrepancy:Date;
  modelNo:string;
  serNo:string;
  registrationNo:string;
  deliveryDate:Date;
  totalhouratDelivey:string;
  totalHouratOccation:string;
  qty:number;
  ataCode:string;
  itemDetailId:number;
  dateofInstall:Date;
  conditionOfItemId:number;
  totalLandingCycles:string;
  totalAcHour:string;
  resonForRemoval:string;
  description:any;
  workShop:string;
  showHideDiv = false;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private MeaSquadronStateService: MeaSquadronStateService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('meaSquadronStateId'); 
    this.MeaSquadronStateService.find(+id).subscribe( res => {
      console.log(res);
      console.log("Mea Squadron");
      this.meaSquadronStateId= res.meaSquadronStateId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.pattNo=res.pattNo,
      this.itemName=res.itemName,
      this.trad=res.trad,
      this.workOrderNo=res.workOrderNo,
      this.dateofSubmition=res.dateofSubmition,
      this.dateOfDiscrepancy=res.dateOfDiscrepancy,
      this.modelNo=res.modelNo,
      this.serNo=res.serNo,
      this.registrationNo=res.registrationNo,
      this.deliveryDate=res.deliveryDate,
      this.totalhouratDelivey=res.totalhouratDelivey,
      this.totalHouratOccation=res.totalHouratOccation,
      this.qty=res.qty,
      this.ataCode=res.ataCode,
      this.dateofInstall=res.dateofInstall,
      this.itemCondition=res.itemCondition,
      this.totalLandingCycles=res.totalLandingCycles,
      this.totalAcHour=res.totalAcHour,
      this.resonForRemoval=res.resonForRemoval,
      this.description=res.description,
      this.workShop=res.workShop
      
    })
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
                      text-align:left;
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
          <h3>User Work Requisition Details</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
}

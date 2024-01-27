import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
//import { AirCraftFlying } from '../../models/AirCraftFlying';
//import { AirCraftFlyingService } from '../../service/AirCraftFlying.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/core/models/role';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-flgwg-dashboard',
  templateUrl: './flgwg-dashboard.component.html',
  styleUrls: ['./flgwg-dashboard.component.sass']
})
export class FLGWGDashboardComponent implements OnInit {

  masterData = MasterData;
  //ELEMENT_DATA: AirCraftFlying[] = [];
  isLoading = false;
  AricraftFlyingScheduleList:any;
  CountAricraftFlyingSchedule:any;
  role:any;
  userRole = Role;
  AirCraftFlyingForm: FormGroup;
  selectedDepartmentName: SelectedModel[];
  departmentNameValue:any;
  departmentName:any;
  btnText: string;
  isShown: boolean = false ;
  time:any;

  // role: any;
  traineeId: any;
  branchId: any;
  showHideDiv = false;
  popup = false;
  barcodeId : any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  airCraftName:any;
  crew:any;
  mon:any;
  startupPlanned:any;
  startUp:any;
  endurance:any;
  duration:any;
  fuel:any;
  opaOff:any;
  remarks:any;
  startUpStatus:any;
  date:any;

  displayedColumns: string[] = [ 'airCraftName','crew','mon',  'startUp',  'endurance', 'fuel','opaOff', 'endurance'];
  //dataSource: MatTableDataSource<AirCraftFlying> = new MatTableDataSource();

  //selection = new SelectionModel<AirCraftFlying>(true, []);

  constructor(private snackBar: MatSnackBar,private datepipe: DatePipe,private authService: AuthService, private fb: FormBuilder, private dashboardService: DashboardService,  private router: Router, private confirmService: ConfirmService) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    this.intitializeForm();
    this.AirCraftFlyingForm.get('dateFrom').setValue(new Date);
    this.AirCraftFlyingForm.get('dateTo').setValue(new Date);

    if (
      this.role == this.userRole.CO ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAricraftFlyingSchedule(0);
      
    } else {
      this.getAricraftFlyingSchedule(this.branchId);
      this.AirCraftFlyingForm.get('departmentNameId').setValue(this.branchId);
      
    }

    console.log(this.AirCraftFlyingForm.value);
    // this.getAricraftFlyingSchedule();
    
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.btnText = 'Submit';

    // let dateFormat = require('dateformat');
    var current = new Date();
    this.time = current.getHours() + ":" + current.getMinutes();
    // dateFormat(this.time, "dddd, mmmm dS, yyyy, h:MM:ss TT");
    console.log("eeeeeeeeee");
    console.log(this.time);
    // console.log(
    //   this.time.toLocaleString('en-US', { hour: 'numeric', hour12: true })
    // );  
  }

  intitializeForm() {
    this.AirCraftFlyingForm = this.fb.group({
      departmentNameId: [],
      dateFrom: [''],
      dateTo:['']

    })
  }



  onDepartmentNameSelectionChange(dropdown){
    this.isShown=true;
    if(dropdown.isUserInput) {
      console.log(dropdown.source.value.text);
      this.departmentNameValue=dropdown.source.value.text
      this.departmentName=dropdown.source.value.value;
      
    }
  }

  getAricraftFlyingSchedule(branchId){
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    
    this.dashboardService.getAricraftFlyingSchedule(currentDateTime,currentDateTime,branchId).subscribe(response => {   
      this.AricraftFlyingScheduleList=response;
      this.CountAricraftFlyingSchedule = response.length;
      console.log(this.AricraftFlyingScheduleList)
      console.log(this.CountAricraftFlyingSchedule)
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.dashboardService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      console.log(res)
    }); 
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    // this.getAricraftFlyingSchedule();
    if (
      this.role == this.userRole.CO ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAricraftFlyingSchedule(0);
    } else {
      this.getAricraftFlyingSchedule(this.branchId);
    }
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    // this.getAricraftFlyingSchedule();
    if (
      this.role == this.userRole.CO ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getAricraftFlyingSchedule(0);
    } else {
      this.getAricraftFlyingSchedule(this.branchId);
    }
  }
  onSubmit(){
    var departmentNameId =this.AirCraftFlyingForm.value['departmentNameId'];
    var dateFrom=this.AirCraftFlyingForm.value['dateFrom'];
    var dateTo=this.AirCraftFlyingForm.value['dateTo'];
    
    let newDateFrom = new Date(dateFrom);
    let newDateTo = new Date(dateTo);
    let checkdateFrom = this.datepipe.transform((newDateFrom), 'MM/dd/yyyy');
    let checkdateTo = this.datepipe.transform((newDateTo), 'MM/dd/yyyy');
    console.log(departmentNameId)
    console.log(checkdateFrom,checkdateTo)
    this.dashboardService.getAricraftFlyingSchedule(checkdateFrom,checkdateTo,departmentNameId).subscribe(response => {   
      this.AricraftFlyingScheduleList=response;
      console.log("after")
      console.log(this.AricraftFlyingScheduleList)
    })
      
  }
  getPopup(data){
    this.popup = true;
   // this.barcodeId = itemStoreId;
    console.log("popup apairs")
    console.log(data);
    this.airCraftName=data.airCraftName;
    this.crew =data.crew;
    this.mon =data.mon;
    this.startupPlanned = data.startupPlanned;
    this.startUp =data.startUp;
    this.endurance =data.endurance;
    this.duration =data.duration;
    this.fuel=data.fuel;
    this.opaOff=data.opaOff;
    this.remarks=data.remarks;
    this.startUpStatus =data.startUpStatus;
    this.date=data.date;
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
          <h3>Flying Schedule List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
}

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
import { ProcurementService } from 'src/app/spares-management/service/Procurement.service';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-logisticsissues-list',
  templateUrl: './logisticsissues-list.component.html',
  styleUrls: ['./logisticsissues-list.component.sass']
})
export class logisticsIssuesListComponent implements OnInit {

  masterData = MasterData;
  //ELEMENT_DATA: AirCraftFlying[] = [];
  isLoading = false;
  ProcurementList:any;
  itemCount:any;
  CountAricraftFlyingSchedule:any;
  
  role: any;
  traineeId: any;
  branchId: any;

  userRole = Role;
  AirCraftFlyingForm: FormGroup;
  selectedDepartmentName: SelectedModel[];
  departmentNameValue:any;
  departmentName:any;
  btnText: string;
  isShown: boolean = false ;

  groupArrays: { departmentName: string; datas: any }[];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = [ 'airCraftName','crew','mon',  'startUp',  'endurance', 'fuel','opaOff', 'endurance'];
  //dataSource: MatTableDataSource<AirCraftFlying> = new MatTableDataSource();

  //selection = new SelectionModel<AirCraftFlying>(true, []);

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private ProcurementService: ProcurementService,private datepipe: DatePipe, private fb: FormBuilder, private dashboardService: DashboardService,  private router: Router, private confirmService: ConfirmService) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId);

    // this.getAricraftFlyingSchedule();
    this.intitializeForm();
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    this.btnText = 'Submit';

    //this.getAircraftStatusCount();
    if (
      this.role == this.userRole.HR ||
      this.role == this.userRole.CO ||
      this.role == this.userRole.FLGWG ||
      this.role == this.userRole.SuperAdmin
    ) {
      this.getProcurementsList(0);
    } else {
      this.getProcurementsList(this.branchId);
    }
    
  }

  intitializeForm() {
    this.AirCraftFlyingForm = this.fb.group({
      departmentNameId: [],
      date: [''],
      dateFrom: [''],
      dateTo:['']

    })
  }
  onDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId = this.AirCraftFlyingForm.value['departmentNameId'];
    
    console.log('hit',departmentNameId);

    this.getProcurementsList(departmentNameId);


    // if(dropdown.isUserInput) {
    //   console.log(dropdown.source.value.text);
    //   this.departmentNameValue=dropdown.source.value.text
    //   this.departmentName=dropdown.source.value.value;
      
    // }
  }

  // getAricraftFlyingSchedule(){
  //   let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
  //   this.dashboardService.getAricraftFlyingSchedule(currentDateTime,currentDateTime,0).subscribe(response => {   
  //     this.ProcurementList=response;
  //     this.CountAricraftFlyingSchedule = response.length;
  //     console.log(this.ProcurementList)
  //     console.log(this.CountAricraftFlyingSchedule)
  //   })
  // }
  GetDepartmentNameById(baseNameId){    
    this.dashboardService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      console.log(res)
    }); 
  }

  getProcurementsList(departmentId) {
    this.isLoading = true;
    this.ProcurementService.getProcurementListByDepartmentNameId( this.paging.pageIndex, 100000, this.searchText, this.masterData.sparescategory.spares, departmentId ).subscribe((response) => {
      this.ProcurementList = response.items;
      this.itemCount = response.items.length;
      //console.log("dddddd");
      console.log(this.ProcurementList);
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;

      // this gives an object with dates as keys
      const groups = this.ProcurementList.reduce((groups, datas) => {
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

  // getDelayedNo(model){
  //   console.log(model.procurementId);
  // }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    // this.getAricraftFlyingSchedule();
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    // this.getAricraftFlyingSchedule();
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
    console.log(checkdateFrom)
    console.log(checkdateTo)
    
      
  }
}

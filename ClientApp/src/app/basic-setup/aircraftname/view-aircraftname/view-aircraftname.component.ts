import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AirCraftName } from '../../models/airCraftName';
import { AirCraftNameService } from '../../service/airCraftName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-aircraftname',
  templateUrl: './view-aircraftname.component.html',
  styleUrls: ['./view-aircraftname.component.sass']
})
export class ViewAirCraftNameComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: AirCraftName[] = [];
  isLoading = false;
  airCraftNameId: number;
  departmentNameId: number;
  departmentName:string;
  name:string;
  image:string;
  overallLength: string;
  wingSpan: string;
  height: string;
  maxRange:string;
  endurance: string;
  maxTakeoffAndLandingWt: string;
  basicOperatingWt: string;
  cruisingSpeed:string;
  fuelCapacity: string;
  crew: string;
  madeBy: string;
  manufacturer: string;
  manufacturerMobile: string;
  email: string;
  remarks: string;
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private AirCraftNameService: AirCraftNameService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('airCraftNameId'); 
    this.AirCraftNameService.find(+id).subscribe( res => {
      console.log(res);
      this.airCraftNameId= res.airCraftNameId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.name = res.name,
      this.image = res.image,
      this.overallLength= res.overallLength,
      this.wingSpan= res.wingSpan,
      this.height=res.height,
      this.maxRange = res.maxRange,
      this.endurance= res.endurance,
      this.maxTakeoffAndLandingWt= res.maxTakeoffAndLandingWt,
      this.basicOperatingWt=res.basicOperatingWt,
      this.cruisingSpeed = res.cruisingSpeed,
      this.fuelCapacity= res.fuelCapacity,
      this.crew= res.crew,
      this.madeBy=res.madeBy,
      this.manufacturer=res.manufacturer,
      this.manufacturerMobile=res.manufacturerMobile,
      this.email=res.email,
      this.remarks=res.remarks
      
    })
  }
}

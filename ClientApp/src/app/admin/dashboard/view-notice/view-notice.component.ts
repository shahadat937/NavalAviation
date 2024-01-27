import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NoticeBoard } from '../../../basic-setup/models/NoticeBoard';
import { NoticeBoardService } from '../../../basic-setup/service/NoticeBoard.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-notice',
  templateUrl: './view-notice.component.html',
  styleUrls: ['./view-notice.component.sass']
})
export class ViewNoticeComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: NoticeBoard[] = [];
  isLoading = false;

  noticeBoardId: number;
  departmentNameId: number;
  departmentName:string;
  date:Date;
  event:string;
  orderBy:string;
  remarks:string;
  noticeDocument:string;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private NoticeBoardService: NoticeBoardService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('noticeBoardId'); 
    this.NoticeBoardService.find(+id).subscribe( res => {
      console.log(res);
      this.noticeBoardId= res.noticeBoardId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.date=res.date,
      this.event=res.event,
      this.orderBy=res.orderBy,
      this.remarks=res.remarks,
      this.noticeDocument=res.noticeDocument
    })
  }
}

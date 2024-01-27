import { Directive, OnInit,AfterViewInit , Component, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router,ActivatedRoute } from '@angular/router';
import { ItemStorService } from '../service/ItemStor.service';
import { QuaggaJSResultObject } from '@ericblade/quagga2';
import { BarcodeScannerLivestreamComponent } from "ngx-barcode-scanner";
import { ConfirmService } from 'src/app/core/service/confirm.service';
@Component({
  selector: "app-barcode-result",
  templateUrl: "./barcode-result.component.html",
  styleUrls: ["./barcode-result.component.sass"],
})

export class BarcodeResultComponent implements OnInit {

  BarcodeValueForm: FormGroup;

  barcodeResult:any = 0;

  isDataNull:boolean = false;


  constructor(private snackBar: MatSnackBar,private itemStorService: ItemStorService,private confirmService: ConfirmService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit() {
      this.intitializeForm();
  }

  intitializeForm() {
    this.BarcodeValueForm = this.fb.group({
      codeValue: []    
    })
  }
  onSubmit(){
    var resultValue = this.BarcodeValueForm.value;
    console.log(resultValue.codeValue);

    this.itemStorService.findResult(resultValue.codeValue).subscribe(res=>{
      if(res != null && res != undefined){
        this.isDataNull = true;
        this.barcodeResult=res[0];
      }else{
        this.isDataNull = true;
      }
      

      console.log(res);
      console.log(this.isDataNull);
    }); 
  }

}

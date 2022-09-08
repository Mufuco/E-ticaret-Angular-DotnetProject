import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Product } from 'src/app/contracts/product';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends BaseComponent implements OnInit {
  

  constructor(spinner: NgxSpinnerService, private httpClientService:HttpClientService) { 
    super(spinner);
  }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.BallAtom);
    this.httpClientService.get<Product[]>({
      controller: "Product"
    }).subscribe(data => console.log(data));

    //this.httpClientService.Post({
    //controller: "Product"
    //},{

      //name:"kalem",
     // stock:100,
     // price:15
   // }).subscribe();

   //this.httpClientService.Put({
    //controller: "Product",
   //},{
   // id:"3629b2bb-14de-440f-8164-c89f88f4d86f",
   // name:"Selamlarrr",
   // stock:232,
   // price:2323

   //}).subscribe()
    
  this.httpClientService.Delete({
    controller: "Product"
   },
 "3629b2bb-14de-440f-8164-c89f88f4d86f").subscribe()
  }
}

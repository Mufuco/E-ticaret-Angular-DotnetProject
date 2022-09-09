import { Injectable } from '@angular/core';
import { Create_Product } from 'src/app/contracts/create_product';
import { HttpClientService } from '../http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private htppClientService: HttpClientService) { }

  create(product:Create_Product, succesCallBack?: any){
    this.htppClientService.Post({
      controller:"Product"
    },product).subscribe(result =>{succesCallBack();} );


  }
}

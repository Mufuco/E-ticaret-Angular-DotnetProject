import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Product } from 'src/app/contracts/create_product';
import { AlertiyfService, MessageType, Position } from 'src/app/services/admin/alertiyf.service';
import { FileUploadOptions } from 'src/app/services/common/file-upload/file-upload.component';
import { ProductService } from 'src/app/services/common/models/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent extends BaseComponent implements OnInit {


  constructor(spinner:NgxSpinnerService, private productService: ProductService, private alertify:AlertiyfService) {super(spinner) }

  ngOnInit(): void {}
  @Output() createdProduct : EventEmitter<Create_Product> = new EventEmitter();

   @Output() fileUploadOptions:Partial<FileUploadOptions>={
    action:"Upload",
    controller:"Product",
    explanation:"Resimleri sürükleyin veya seçin",
    isAdminPage:true,
    accept:".png, .jpg, .jpeg,Json"

   };

   create(name: HTMLInputElement, stock: HTMLInputElement, price: HTMLInputElement) {
    this.showSpinner(SpinnerType.BallAtom);
    const create_product: Create_Product = new Create_Product();
    create_product.name = name.value;
    create_product.stock = parseInt(stock.value);
    create_product.price = parseFloat(price.value);

    if(name.value)

    this.productService.create(create_product, () => {
      this.hideSpinner(SpinnerType.BallAtom);
      this.alertify.message("Ürün başariyla eklenmiştir.", {
        dismissOthers: true,
        messageType: MessageType.success,
        position: Position.TopRight
      });
      this.createdProduct.emit(create_product);
    }, errorMessage => {
      this.alertify.message(errorMessage, {
          dismissOthers: true,
          messageType: MessageType.error,
          position: Position.TopRight
        });
    });
  }
}


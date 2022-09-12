import { HttpErrorResponse } from '@angular/common/http';
import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DeletedialogComponent, DeleteState } from 'src/app/dialogs/deletedialog/deletedialog.component';
import { AlertiyfService, MessageType, Position } from 'src/app/services/admin/alertiyf.service';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ProductService } from 'src/app/services/common/models/product.service';

declare var $ : any;

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(
    private elementRef: ElementRef,
    private _renderer: Renderer2,
    private httpClientService: HttpClientService,
     public dialog: MatDialog,
     private alertifyService:AlertiyfService) 
    
   {
    const img =_renderer.createElement("img");
    img.setAttribute("src","../../../../../assets/Delete.png");
    img.setAttribute("style","cursor:pointer");
    _renderer.appendChild(elementRef.nativeElement, img);
    
   }
   @Input() id: string;
   @Output() callback:EventEmitter<any>= new EventEmitter();
   @Input() controller:string;

  @HostListener("click")
   async onclick(){
    this.openDialog(async ()=>{
      const td:HTMLTableCellElement=this.elementRef.nativeElement;
      this.httpClientService.Delete({
        controller:this.controller,

      }, this.id).subscribe(data=>{
         $(td.parentElement).fadeOut(1000,()=>{
      this.callback.emit();
    this.alertifyService.message("Silme işlemi başarılı!",{
    dismissOthers:true,
    messageType:MessageType.success,
    position:Position.BottomRight
  })
    });

      },(errorResponse:HttpErrorResponse)=>{
        this.alertifyService.message("Silme işlemi başarısız!",{
    dismissOthers:true,
    messageType:MessageType.error,
    position:Position.BottomRight
  })
      });
   
    
      
    });
    
   }


  openDialog(afterClosed:any,): void {
    const dialogRef = this.dialog.open( DeletedialogComponent,
 {
      width: '250px',
      data: DeleteState.Yes,

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(result==DeleteState.Yes){
      afterClosed();
      }

    });
  }

}

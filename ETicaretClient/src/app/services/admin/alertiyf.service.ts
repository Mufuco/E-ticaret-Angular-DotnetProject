import { Injectable } from '@angular/core';
declare var alertify:any;

@Injectable({
  providedIn: 'root'
})
export class AlertiyfService {

  constructor() { }
  //message(message: string, messageType: MessageType,position:Position, delay:number=3,dismissOthers:boolean=false){
    message(message: string,options:Partial<AlertifyOptions>){
    const msj=alertify[options.messageType](message)
    alertify.set('notifier', 'delay', options.delay)
    alertify.set('notifier', 'position',options.position)
    if(options.dismissOthers)
    msj.dismissOthers();
  }
  dismiss(){
    alertify.dismiss();
  }

}
export class AlertifyOptions {
  messageType: MessageType=MessageType.Message;
  position: Position=Position.Bottomright;
  delay: number=3;
  dismissOthers:boolean=false;

}
export enum MessageType{
  Error= "error",
  Message= "message",
  Notify= "notify",
  Succes= "succes",
  Warning= "warning",
}
export enum Position{
  TopCenter="top-center",
  TopRight= "top-right",
  TopLeft= "top-left",
  Bottomright= "bottom-right",
  Bottomleft= "bottom-left",
  Bottomcenter= "bottom-center"
}

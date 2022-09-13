import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BaseDialog } from '../base/base-dialog';
import { FileUploadDialogsComponent } from '../file-upload-dialogs/file-upload-dialogs.component';

@Component({
  selector: 'app-deletedialog',
  templateUrl: './deletedialog.component.html',
  styleUrls: ['./deletedialog.component.scss']
})
export class DeletedialogComponent extends BaseDialog<DeletedialogComponent>{
  constructor(
  dialogRef: MatDialogRef<DeletedialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FileUploadDialogsComponent,
  ) {
    super(dialogRef);
  }

}

export enum DeleteState{
  Yes,
  No
}
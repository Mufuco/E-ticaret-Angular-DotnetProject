import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BaseDialog } from '../base/base-dialog';

@Component({
  selector: 'app-file-upload-dialogs',
  templateUrl: './file-upload-dialogs.component.html',
  styleUrls: ['./file-upload-dialogs.component.scss']
})
export class FileUploadDialogsComponent extends BaseDialog<FileUploadDialogsComponent> {

  constructor(
    dialogRef: MatDialogRef<FileUploadDialogsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FileUploadDialogState) {
    super(dialogRef)
  }

}

export enum FileUploadDialogState {
  Yes, No
}
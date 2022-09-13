import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeletedialogComponent } from '../deletedialog/deletedialog.component';
import { FileUploadDialogsComponent } from '../file-upload-dialogs/file-upload-dialogs.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [DeletedialogComponent,
  FileUploadDialogsComponent,
],
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule
  ]
})
export class DialogsModule { }

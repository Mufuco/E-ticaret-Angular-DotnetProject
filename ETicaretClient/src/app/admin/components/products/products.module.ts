import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from '../products/products.component';
import { RouterModule } from '@angular/router';
import {MatSidenav, MatSidenavModule} from '@angular/material/sidenav';
import { CreateComponent } from './create/create.component';
import { ListComponent } from './list/list.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { DeleteDirective } from 'src/app/directives/admin/delete.directive';
import {MatDialogModule} from '@angular/material/dialog';
import { DeletedialogComponent } from 'src/app/dialogs/deletedialog/deletedialog.component';
import { FileUploadModule } from 'src/app/services/common/file-upload/file-upload.module';
import { DialogModule } from '@angular/cdk/dialog';
import { FileUploadComponent } from 'src/app/services/common/file-upload/file-upload.component';
import { DialogsModule } from 'src/app/dialogs/dialogs/dialogs.module';



@NgModule({
  declarations: [
    ProductsComponent,
    CreateComponent,
    ListComponent,
    DeleteDirective,
    
    
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([ {path:"",component:ProductsComponent}]),
    MatSidenavModule,MatFormFieldModule,MatInputModule,MatButtonModule,MatTableModule,MatPaginatorModule,MatDialogModule,
    FileUploadModule,DialogsModule
    
  ]
})
export class ProductsModule { }

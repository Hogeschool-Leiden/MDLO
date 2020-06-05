import { NgModule } from '@angular/core';

import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';

const MaterialModules: any[] = [
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule,
  MatCheckboxModule,
  MatSnackBarModule,
  MatSelectModule
]

@NgModule({
  imports: [...MaterialModules],
  exports: [...MaterialModules]

})
export class MaterialModule { }

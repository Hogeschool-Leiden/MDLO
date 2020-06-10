import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';


const MaterialModules: any[] = [

  MatSnackBarModule,
  MatButtonModule

]

@NgModule({
  imports: [...MaterialModules],
  exports: [...MaterialModules]

})
export class MaterialModule { }

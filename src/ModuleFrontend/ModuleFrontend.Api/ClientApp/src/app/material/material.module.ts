import { NgModule } from '@angular/core';

import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

const MaterialModules: any[] = [
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule
]

@NgModule({
  imports: [...MaterialModules],
  exports: [...MaterialModules]

})
export class MaterialModule { }

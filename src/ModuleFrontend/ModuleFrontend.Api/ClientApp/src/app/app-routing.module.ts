import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ModuleOverzichtComponent } from './pages/module-overzicht/module-overzicht.component';
import { ModuleAanmakenComponent } from './pages/module-aanmaken/module-aanmaken.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'modules', component: ModuleOverzichtComponent, pathMatch: 'full' },
  { path: 'module-aanmaken', component: ModuleAanmakenComponent, pathMatch: 'full' },
]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

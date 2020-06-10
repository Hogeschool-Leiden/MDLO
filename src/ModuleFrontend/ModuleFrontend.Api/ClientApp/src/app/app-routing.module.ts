import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ModuleAanmakenComponent } from './pages/module-aanmaken/module-aanmaken.component';
import { ModulesInladenComponent } from './pages/modules-inladen/modules-inladen.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'module-aanmaken', component: ModuleAanmakenComponent, pathMatch: 'full' },
  { path: 'modules-inladen', component: ModulesInladenComponent, pathMatch: 'full' },


]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatSliderModule} from "@angular/material/slider";
import {MatButtonModule} from "@angular/material/button";
import {CompetenciesComponent} from './competencies/competencies.component';
import {ModulesComponent} from './modules/modules.component';
import {AdminComponent} from './admin/admin.component';
import {CompetenceMatrixComponent} from './competencies/competence-matrix/competence-matrix.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatSelectModule} from "@angular/material/select";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatTableModule} from "@angular/material/table";
import {MatListModule} from "@angular/material/list";
import {MatInputModule} from "@angular/material/input";
import {MatSortModule} from "@angular/material/sort";
import {AuditLogComponent} from './admin/audit-log/audit-log.component';
import { ModulePopupComponent } from './modules/module-popup/module-popup.component';
import {MatDialogModule} from "@angular/material/dialog";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CompetenciesComponent,
    ModulesComponent,
    AdminComponent,
    CompetenceMatrixComponent,
    AuditLogComponent,
    ModulePopupComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'admin', component: AdminComponent, pathMatch: 'full'},
      {path: 'competencies', component: CompetenciesComponent, pathMatch: 'full'},
      {path: 'modules', component: ModulesComponent, pathMatch: 'full'},
      {path: 'audit-log', component: AuditLogComponent, pathMatch: 'full'}
    ]),
    BrowserAnimationsModule,
    MatSliderModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatGridListModule,
    MatTableModule,
    MatListModule,
    MatInputModule,
    MatSortModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}

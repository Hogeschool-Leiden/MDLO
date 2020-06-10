import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { AppRoutingModule } from './app-routing.module';
import { ModuleEditorComponent } from './components/module-editor/module-editor.component';
import { ModuleAanmakenComponent } from './pages/module-aanmaken/module-aanmaken.component';
import { ModuleSanitizePipe } from './pipes/module-sanitize.pipe';
import { ModulesInladenComponent } from './pages/modules-inladen/modules-inladen.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ModuleEditorComponent,
    ModuleAanmakenComponent,
    ModuleSanitizePipe,
    ModulesInladenComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [ModuleSanitizePipe],
  bootstrap: [AppComponent]
})
export class AppModule {
}

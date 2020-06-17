import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { StoresComponent } from './components/stores/stores.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { StoreItemComponent } from './components/store-item/store-item.component';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StoresComponent,
    FooterComponent,
    StoreItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

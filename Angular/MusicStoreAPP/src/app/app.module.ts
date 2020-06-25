import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { StoresComponent } from './components/stores/stores.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { StoreItemComponent } from './components/store-item/store-item.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { InstrumentsComponent } from './components/instruments/instruments.component';
import { InstrumentItemComponent } from './components/instrument-item/instrument-item.component';
import { InstrumentEditComponent } from './components/instrument-edit/instrument-edit.component';
import { AddStoreComponent } from './components/add-store/add-store.component';
import { AddInstrumentComponent } from './components/add-instrument/add-instrument.component';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StoresComponent,
    FooterComponent,
    StoreItemComponent,
    CarouselComponent,
    InstrumentsComponent,
    InstrumentItemComponent,
    InstrumentEditComponent,
    AddStoreComponent,
    AddInstrumentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

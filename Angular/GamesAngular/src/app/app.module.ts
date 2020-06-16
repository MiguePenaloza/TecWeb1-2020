import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import {FormsModule} from '@angular/forms'

import { AppComponent } from './app.component';
import { GamesComponent } from './components/games/games.component';
import { GameItemComponent } from './components/game-item/game-item.component';
import { AddGameComponent } from './components/add-game/add-game.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { FooterComponent } from './components/layout/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    GamesComponent,
    GameItemComponent,
    AddGameComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

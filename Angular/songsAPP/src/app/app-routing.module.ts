import { EditSongComponent } from './components/edit-song/edit-song.component';
import { SongsComponent } from './components/songs/songs.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path:'', component:SongsComponent},
  {path:'songs/:songId', component:EditSongComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

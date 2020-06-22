import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StoresComponent } from './components/stores/stores.component';
import { InstrumentsComponent } from './components/instruments/instruments.component';



const routes: Routes = [
  {path:'', component: StoresComponent},
  {path:'stores/:storeId', component:InstrumentsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

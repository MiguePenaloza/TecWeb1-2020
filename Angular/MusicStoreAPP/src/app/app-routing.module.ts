import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StoresComponent } from './components/stores/stores.component';
import { StoreUnitComponent } from './components/store-unit/store-unit.component';


const routes: Routes = [
  {path:'', component: StoresComponent},
  {path:'stores/:storeId', component:StoreUnitComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

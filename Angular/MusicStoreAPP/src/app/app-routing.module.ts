import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StoresComponent } from './components/stores/stores.component';


const routes: Routes = [
  {path:'', component: StoresComponent}
  // {path:'todos/:todoId', component:EditTodoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

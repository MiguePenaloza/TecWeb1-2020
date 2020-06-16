import { EditBookComponent } from './components/edit-book/edit-book.component';
import { AboutComponent } from './components/pages/about/about.component';
import { BooksComponent } from './components/books/books.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path:'', component:BooksComponent},
  {path:'about', component:AboutComponent},
  {path:'books/:bookId', component:EditBookComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

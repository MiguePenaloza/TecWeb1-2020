import { Injectable } from '@angular/core';
import {HttpHeaders, HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Book } from 'src/app/models/Book';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class BookService {

  booksUrl:string = "https://localhost:44350/api/books";

  constructor(private http:HttpClient) { }

  getBooks():Observable<Book[]> {
    return this.http.get<Book[]>(this.booksUrl);
  }

  getBook(book:string):Observable<Book> {
    return this.http.get<Book>(`${this.booksUrl}/${book}`);
  }

  deleteBook(book:Book): Observable<Book> {
    return this.http.delete<Book>(`${this.booksUrl}/${book.id}`,httpOptions);
  }

  addBook(bookAdd:Book): Observable<Book> {
    console.log(bookAdd);
    return this.http.post<Book>(this.booksUrl, bookAdd, httpOptions);
  }

  updateBook(book:Book):Observable<Book> {
    return this.http.put<Book>(`${this.booksUrl}/${book.id}`,book,httpOptions);
  }
}

import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/models/Book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  booksList:Book[];

  constructor(private bookService:BookService) { }

  ngOnInit(): void {
    this.bookService.getBooks().subscribe( b => {
      this.booksList = b;
    })
  }

  deleteBook(bookToDelete: Book): void {
    this.booksList = this.booksList.filter( b => b.id != bookToDelete.id);
    this.bookService.deleteBook(bookToDelete).subscribe( r => {
      console.log(r);
    });
  }

  addAndSend(book:Book) {
    this.bookService.addBook(book).subscribe(b => {
      this.booksList.push(b);
    })
  }

}

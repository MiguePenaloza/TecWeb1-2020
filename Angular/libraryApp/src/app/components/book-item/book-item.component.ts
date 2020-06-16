import { BookService } from 'src/app/services/book.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Book } from 'src/app/models/Book';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-item',
  templateUrl: './book-item.component.html',
  styleUrls: ['./book-item.component.css']
})
export class BookItemComponent implements OnInit {

  @Input() bookInput:Book;
  @Output() bookDeleteOutput: EventEmitter<Book> = new EventEmitter(); 

  constructor(private bookService:BookService, private router:Router) { }

  ngOnInit(): void {
  }

  setClasses() {
    let classes = {
      book: true
    }
    return classes;
  }

  onDelete() {
    this.bookDeleteOutput.emit(this.bookInput);
  }

  onEdit(book:Book) {
    this.router.navigateByUrl(`/books/${book.id}`);
  }

}

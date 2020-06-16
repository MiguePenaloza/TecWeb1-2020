import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Book } from 'src/app/models/Book';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  title: string;
  year: number;
  pages: number;

  @Output() addBookOutput:EventEmitter<Book> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    const addBook: Book = {
      title: this.title,
      year: this.year,
      pages: this.pages
    };
    this.addBookOutput.emit(addBook);
  }

}

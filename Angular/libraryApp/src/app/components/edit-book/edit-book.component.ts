import { BookService } from 'src/app/services/book.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/models/Book';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {

  book:Book;

  constructor(private bookService:BookService, private route:ActivatedRoute) { 
    this.book = new Book(); 
  }

  ngOnInit(): void {
    const bookId = this.route.snapshot.paramMap.get("bookId");
    this.bookService.getBook(bookId).subscribe( b => {
      this.book = b;
      console.log(this.book);
    })
  }

  onSubmit(book:Book) {
    this.bookService.updateBook(book).subscribe( b => {
      console.log(b);
    })
  }

}

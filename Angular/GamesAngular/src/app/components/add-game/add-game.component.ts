import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Game } from 'src/app/models/Game';

@Component({
  selector: 'app-add-game',
  templateUrl: './add-game.component.html',
  styleUrls: ['./add-game.component.css']
})
export class AddGameComponent implements OnInit {

  @Output() addGame:EventEmitter<Game> = new EventEmitter();

  name:string;
  price:number;
  isSoldOut:boolean;

  constructor() { }

  ngOnInit(): void {
  }

  addNewGame() {
    const game = {
      name: this.name,
      price: this.price,
      isSoldOut: this.isSoldOut
    }
    this.addGame.emit(game);
  }

}

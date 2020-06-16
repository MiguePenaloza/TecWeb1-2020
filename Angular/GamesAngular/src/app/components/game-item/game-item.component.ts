import { Component, OnInit, Input } from '@angular/core';
import { Game } from 'src/app/models/Game';

@Component({
  selector: 'app-game-item',
  templateUrl: './game-item.component.html',
  styleUrls: ['./game-item.component.css']
})
export class GameItemComponent implements OnInit {

  @Input() gameInput: Game;
  constructor() { }

  ngOnInit(): void {
  }

  setClasses() {
    let classes = {
      game: true,
      "is-sold-out": this.gameInput.isSoldOut
    }
    return classes;
  }
}

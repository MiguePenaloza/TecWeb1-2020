import { GameService } from './../../services/game.service';
import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/models/Game';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {

  gamesList: Game[];
  gamesToDelete: number[];
  
  constructor(private gameService:GameService) { }

  ngOnInit(): void {
    this.gameService.getGames().subscribe( g => {
      this.gamesList = g;
    })
  }
  
  addGameSend(gameToAdd:Game) {
    this.gameService.addGame(gameToAdd).subscribe( g => {
      this.gamesList.push(g);
    })
  }

  deleteSoldOutGames() {
    this.gamesToDelete = this.gamesList.filter( g => g.isSoldOut === true).map( i => {
      return i.id
    });
    console.log(this.gamesToDelete);
    this.gamesList = this.gamesList.filter ( g => g.isSoldOut !== true);
    this.gameService.deleteGamesSoldOuts(this.gamesToDelete).subscribe( r => {
      console.log(r);
    });
    
  }
}

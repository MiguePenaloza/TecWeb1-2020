import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Game } from '../models/Game';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class GameService {

  gamesUrl:string = 'http://localhost:57891/api/games';
  constructor(private http:HttpClient) { }

  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.gamesUrl);
  }

  addGame(game:Game): Observable<Game> {
    return this.http.post<Game>(this.gamesUrl,game,httpOptions);
  }

  deleteGamesSoldOuts(games:number[]): Observable<any> {
    return this.http.post<any>(`${this.gamesUrl}/BatchDelete`,games,httpOptions);
  }
}

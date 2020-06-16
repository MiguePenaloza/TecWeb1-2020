import { Song } from './../models/Song';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class SongService {

  songsUrl:string = 'https://localhost:44369/api/songs';

  constructor(private http:HttpClient) { }

  getSong(id: string): Observable<Song> {
    return this.http.get<Song>(`${this.songsUrl}/${id}`);
  }

  getSongs(): Observable<Song[]> {
    return this.http.get<Song[]>(this.songsUrl);
  }

  deleteSong(song: Song): Observable<Song> {
    return this.http.delete<Song>(`${this.songsUrl}/${song.id}`,httpOptions);
  }

  addSong(song: Song): Observable<Song> {
    return this.http.post<Song>(this.songsUrl,song,httpOptions);
  }

  updateSong(song: Song): Observable<Song> {
    return this.http.put<Song>(`${this.songsUrl}/${song.id}`,song,httpOptions);
  }
}

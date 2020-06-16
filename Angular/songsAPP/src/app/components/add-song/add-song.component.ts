import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Song } from 'src/app/models/Song';

@Component({
  selector: 'app-add-song',
  templateUrl: './add-song.component.html',
  styleUrls: ['./add-song.component.css']
})
export class AddSongComponent implements OnInit {

  name: string;
  artist: string;
  length: number;
  album: string;
  genre: string;

  @Output() songAdd: EventEmitter<Song> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    const songNew: Song = {
      name: this.name,
      artist: this.artist,
      length: this.length,
      album: this.album,
      genre: this.genre
    };
    
    this.songAdd.emit(songNew);
  }

}

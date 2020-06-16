import { Component, OnInit } from '@angular/core';
import { Song } from 'src/app/models/Song';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css']
})
export class SongsComponent implements OnInit {

  songsList: Song[];

  constructor(private songService:SongService) { }

  ngOnInit(): void {
    this.songService.getSongs().subscribe( s => {
      this.songsList = s;
    })
  }

  onDelete(songToDelete: Song) {
    this.songsList = this.songsList.filter( s => s.id != songToDelete.id);
    this.songService.deleteSong(songToDelete).subscribe( r => {
      console.log(r);
    })
  }

  addSongAndSend(songAdd: Song) {
    return this.songService.addSong(songAdd).subscribe( s => {
      this.songsList.push(s);
    })
  }

}

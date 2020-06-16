import { Song } from 'src/app/models/Song';
import { Component, OnInit } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-edit-song',
  templateUrl: './edit-song.component.html',
  styleUrls: ['./edit-song.component.css']
})
export class EditSongComponent implements OnInit {

  song: Song;
  

  constructor(private songService:SongService, private route: ActivatedRoute) { 
    this.song = new Song();
  }

  ngOnInit(): void {
    console.log(this.song);
    
    const songID = this.route.snapshot.paramMap.get("songId");
    this.songService.getSong(songID).subscribe( s => {
      this.song = s;
      console.log(this.song);
      
    })
  }

  onSubmit() {
    this.songService.updateSong(this.song).subscribe( s => {
      console.log(s);      
    })
  }

}

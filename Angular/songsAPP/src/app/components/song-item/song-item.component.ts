import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Song } from 'src/app/models/Song';
import { Router } from '@angular/router';

@Component({
  selector: 'app-song-item',
  templateUrl: './song-item.component.html',
  styleUrls: ['./song-item.component.css']
})
export class SongItemComponent implements OnInit {

  @Input() songInput:Song;
  @Output() songDelete:EventEmitter<Song> = new EventEmitter();

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  setClasses() {
    let classes = {
      song:true
    } 
    return classes;
  }

  onDelete() {
    this.songDelete.emit(this.songInput);
  }

  onEdit(song: Song) {
    this.router.navigateByUrl(`/songs/${song.id}`);
  }
}

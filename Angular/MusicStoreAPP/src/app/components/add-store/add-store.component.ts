import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Store } from 'src/app/models/Srore';

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.css']
})
export class AddStoreComponent implements OnInit {

  newStore :Store;

  @Output() addStore :EventEmitter<Store> = new EventEmitter();

  constructor() { 
    this.newStore = new Store();
  }

  ngOnInit(): void {
  }

  onClose() {
    this.newStore = new Store();
  }

  onAddStore() {
    this.addStore.emit(this.newStore);
  }
}

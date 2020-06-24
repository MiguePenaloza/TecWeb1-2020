import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Store } from 'src/app/models/Srore';
import { Router } from '@angular/router';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-store-item',
  templateUrl: './store-item.component.html',
  styleUrls: ['./store-item.component.css']
})
export class StoreItemComponent implements OnInit {

  @Input() storeInput :Store;
  @Output() storeDeleteOutput: EventEmitter<Store> = new EventEmitter();
  
  constructor(private router:Router) { }

  ngOnInit(): void { 
       
  }

  onEdit(store :Store) {
    this.router.navigateByUrl(`/stores/${store.id}`);
  }

  onDelete() {
    this.storeDeleteOutput.emit(this.storeInput);    
  }  
}

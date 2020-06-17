import { Component, OnInit, Input } from '@angular/core';
import { Store } from 'src/app/models/Srore';

@Component({
  selector: 'app-store-item',
  templateUrl: './store-item.component.html',
  styleUrls: ['./store-item.component.css']
})
export class StoreItemComponent implements OnInit {

  @Input() storeInput :Store;
  
  constructor() { }

  ngOnInit(): void {
  }

}

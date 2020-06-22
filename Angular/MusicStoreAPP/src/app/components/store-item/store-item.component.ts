import { Component, OnInit, Input } from '@angular/core';
import { Store } from 'src/app/models/Srore';
import { Router } from '@angular/router';

@Component({
  selector: 'app-store-item',
  templateUrl: './store-item.component.html',
  styleUrls: ['./store-item.component.css']
})
export class StoreItemComponent implements OnInit {

  @Input() storeInput :Store;
  
  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  onEdit(store :Store) {
    this.router.navigateByUrl(`/stores/${store.id}`);
  }
}

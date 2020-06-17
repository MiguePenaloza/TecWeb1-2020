import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/models/Srore';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css']
})
export class StoresComponent implements OnInit {

  storesList :Store[];

  constructor(private storeService :StoreService) { }

  ngOnInit(): void {
    this.storeService.getStores().subscribe( stores => {
      this.storesList = stores;
    });
  }

}

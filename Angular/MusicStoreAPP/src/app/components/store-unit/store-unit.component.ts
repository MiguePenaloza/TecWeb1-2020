import { Component, OnInit } from '@angular/core';
import { StoreService } from 'src/app/services/store.service';
import { ActivatedRoute } from '@angular/router';
import { Store } from 'src/app/models/Srore';

@Component({
  selector: 'app-store-unit',
  templateUrl: './store-unit.component.html',
  styleUrls: ['./store-unit.component.css']
})
export class StoreUnitComponent implements OnInit {

  store :Store;

  constructor(private storeService :StoreService, private route:ActivatedRoute) { 
    this.store = new Store();
  }

  ngOnInit(): void {
    const storeId :string = this.route.snapshot.paramMap.get("storeId");
    console.log(storeId);    
    this.storeService.getStore(storeId).subscribe( s => {
      this.store = s;
      console.log(s);
      
    })
  }

}

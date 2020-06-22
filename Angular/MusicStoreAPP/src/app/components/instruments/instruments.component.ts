import { Component, OnInit } from '@angular/core';
import { StoreService } from 'src/app/services/store.service';
import { ActivatedRoute } from '@angular/router';
import { Store } from 'src/app/models/Srore';
import { Instrument } from 'src/app/models/Instrument';
import { InstrumentService } from 'src/app/services/instrument.service';

@Component({
  selector: 'app-instruments',
  templateUrl: './instruments.component.html',
  styleUrls: ['./instruments.component.css']
})
export class InstrumentsComponent implements OnInit {

  store :Store;
  instrumentsList :Instrument[];

  constructor(private storeService :StoreService, private instrumentService :InstrumentService, private route:ActivatedRoute) { 
    this.store = new Store();
    
  }

  ngOnInit(): void {
    const storeId :string = this.route.snapshot.paramMap.get("storeId");
    this.storeService.getStore(storeId).subscribe( s => {
      this.store = s;
    })

    this.instrumentService.getInstruments(storeId).subscribe( instruments => {
      this.instrumentsList = instruments;
      console.log(this.instrumentsList);
      
    });
  }

}

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
  storeId :string = this.route.snapshot.paramMap.get("storeId");

  constructor(private storeService :StoreService, private instrumentService :InstrumentService, private route:ActivatedRoute) { 
    this.store = new Store();
  }
  

  ngOnInit(): void {

    this.storeService.getStore(this.storeId).subscribe( s => {
      this.store = s;
    })

    this.instrumentService.getInstruments(this.storeId).subscribe( instruments => {
      this.instrumentsList = instruments;
      console.log(this.instrumentsList);
    });
  }

  deleteInstrument(instrumentToDelete: Instrument): void {
    if (confirm('Are you sure you want to delete this Instrument?!')) {
      this.instrumentsList = this.instrumentsList.filter( instruments => instruments.id != instrumentToDelete.id);
      //delete from backend
      this.instrumentService.deleteInstrument(this.storeId, instrumentToDelete).subscribe( r => {
        console.log(r);
      });
    } else {
      console.log("You cancel the action");
    }
  }

}

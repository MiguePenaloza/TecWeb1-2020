import { InstrumentService } from 'src/app/services/instrument.service';
import { Instrument } from 'src/app/models/Instrument';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-instrument-edit',
  templateUrl: './instrument-edit.component.html',
  styleUrls: ['./instrument-edit.component.css']
})
export class InstrumentEditComponent implements OnInit {

  instrument :Instrument;

  constructor(private intrumentService :InstrumentService, private route:ActivatedRoute) {
    this.instrument = new Instrument();
   }

  ngOnInit(): void {
    const instrumentId = this.route.snapshot.paramMap.get("instrumentId");
    const storeId = this.route.snapshot.paramMap.get("storeId");
    this.intrumentService.getInstrument(storeId, instrumentId).subscribe( i => {
      this.instrument = i;
    })
  }

}

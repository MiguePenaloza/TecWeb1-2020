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
  originalInstrument :Instrument;
  instrumentId :string = this.route.snapshot.paramMap.get("instrumentId");
  storeId :string = this.route.snapshot.paramMap.get("storeId");

  constructor(private intrumentService :InstrumentService, private route:ActivatedRoute) {
    this.instrument = new Instrument();
    this.originalInstrument = new Instrument();
   }

  ngOnInit(): void {
    this.intrumentService.getInstrument(this.storeId, this.instrumentId).subscribe( i => {
      this.instrument = i;
    });
    this.intrumentService.getInstrument(this.storeId, this.instrumentId).subscribe( i => {
      this.originalInstrument = i;
    });
  }

  onCancel() {
    this.intrumentService.getInstrument(this.storeId, this.instrumentId).subscribe( i => {
      this.instrument = i;
    });
    document.getElementById("response").innerHTML = "";
  }

  onSubmit(updatedInstrument :Instrument) {
    this.intrumentService.updateInstrument(updatedInstrument).subscribe( response => {
      console.log(response);
      if (response === true) {
        document.getElementById("response").innerHTML = "<h5>Cambios Guardados!!</h5>";
        document.getElementById("response").setAttribute("class", "offset-3 badge badge-success");
        this.originalInstrument = this.instrument;
      } 
      
    }, (error) => {
      console.error(error.message);
      if (error.status == 400) {
        document.getElementById("response").innerHTML = "<h5>Bad Request Error!!</h5>";
        document.getElementById("response").setAttribute("class", "offset-3 badge badge-danger");
      } else if (error.status == 401) {
        document.getElementById("response").innerHTML = "<h5>Error!!</h5>";
        document.getElementById("response").setAttribute("class", "offset-5 badge badge-danger");
      }
      
    }
    )
    
  };

}

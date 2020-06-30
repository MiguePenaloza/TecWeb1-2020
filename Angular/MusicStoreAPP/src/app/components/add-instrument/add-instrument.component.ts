import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Instrument } from 'src/app/models/Instrument';

@Component({
  selector: 'app-add-instrument',
  templateUrl: './add-instrument.component.html',
  styleUrls: ['./add-instrument.component.css']
})
export class AddInstrumentComponent implements OnInit {

  newInstrument :Instrument;

  @Output() addInstrument :EventEmitter<Instrument> = new EventEmitter();

  constructor() {
    this.newInstrument = new Instrument();
   }

  ngOnInit(): void {
  }

  onClose() {
    this.newInstrument = new Instrument();
  }

  onAddInstrument() {
    this.addInstrument.emit(this.newInstrument);
  }

}

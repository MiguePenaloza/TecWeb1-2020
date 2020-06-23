import { Instrument } from 'src/app/models/Instrument';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-instrument-item',
  templateUrl: './instrument-item.component.html',
  styleUrls: ['./instrument-item.component.css']
})
export class InstrumentItemComponent implements OnInit {

  @Input() instrumentInput :Instrument;
  @Output() instrumentDeleteOutput: EventEmitter<Instrument> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onDelete() {
    this.instrumentDeleteOutput.emit(this.instrumentInput); 
  }

}

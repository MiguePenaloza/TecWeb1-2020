import { Instrument } from 'src/app/models/Instrument';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-instrument-item',
  templateUrl: './instrument-item.component.html',
  styleUrls: ['./instrument-item.component.css']
})
export class InstrumentItemComponent implements OnInit {

  @Input() instrumentInput :Instrument;
  @Output() instrumentDeleteOutput: EventEmitter<Instrument> = new EventEmitter();

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  onDelete() {
    this.instrumentDeleteOutput.emit(this.instrumentInput); 
  }

  onEdit(instrument :Instrument) {
    this.router.navigateByUrl(`/stores/${instrument.storeId}/instruments/${instrument.id}`);
  }

}

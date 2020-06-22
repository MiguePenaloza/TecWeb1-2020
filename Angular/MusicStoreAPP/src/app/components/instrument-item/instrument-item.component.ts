import { Instrument } from 'src/app/models/Instrument';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-instrument-item',
  templateUrl: './instrument-item.component.html',
  styleUrls: ['./instrument-item.component.css']
})
export class InstrumentItemComponent implements OnInit {

  @Input() instrumentInput :Instrument;
  constructor() { }

  ngOnInit(): void {
  }

}

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
  originalStore :Store;
  instrumentsList :Instrument[];
  storeId :string = this.route.snapshot.paramMap.get("storeId");

  constructor(private storeService :StoreService, private instrumentService :InstrumentService, private route:ActivatedRoute) { 
    this.store = new Store();
    this.originalStore = new Store();
  }
  

  ngOnInit(): void {
    this.storeService.getStore(this.storeId).subscribe( s => {
      this.store = s;
    })

    this.storeService.getStore(this.storeId).subscribe( s => {
      this.originalStore = s;
    })

    this.instrumentService.getInstruments(this.storeId).subscribe( instruments => {
      this.instrumentsList = instruments;
    });
  }

  deleteInstrument(instrumentToDelete: Instrument): void {
    if (confirm('Are you sure you want to delete this Instrument?!')) {
      this.instrumentService.deleteInstrument(this.storeId, instrumentToDelete).subscribe( r => {
        this.instrumentsList = this.instrumentsList.filter( instruments => instruments.id != instrumentToDelete.id);
      }, (error) => {
        if (error.status == 401) {
          alert("No tiene permisos para eliminar Instruments!!");
        }
      });
    } else {
      console.log("You cancel the action");
    }
  }

  onCancel() {
    this.storeService.getStore(this.storeId).subscribe( s => {
      this.store = s;
    });
    
    document.getElementById("response").innerHTML = "";
    console.log(this.store);
    console.log(this.originalStore);
  }

  onSubmit(updatedStore :Store) {
    this.storeService.updateStore(updatedStore).subscribe( response => {
      if (response) {
        document.getElementById("response").innerHTML = "<h5>Cambios Guardados!!</h5>";
        document.getElementById("response").setAttribute("class", "badge badge-success");
        this.originalStore = this.store;
      }
    }, (error) => {
      if (error.status == 400) {
        document.getElementById("response").innerHTML = "<h5>Campo introducido no valido!!</h5>";
        document.getElementById("response").setAttribute("class", "badge badge-danger");
      } else if (error.status == 401) {
          document.getElementById("response").innerHTML = "<h5>No tiene permisos para modificar!!</h5>";
          document.getElementById("response").setAttribute("class", "badge badge-danger");
        }
    })
  }
}

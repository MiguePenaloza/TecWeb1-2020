import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/models/Srore';

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.css']
})
export class AddStoreComponent implements OnInit {

  newStore :Store;

  constructor() { 
    this.newStore = new Store();
  }

  ngOnInit(): void {
  }

  onCancel() {
    // this.storeService.getStore(this.storeId).subscribe( s => {
    //   this.store = s;
    // });
    
    // document.getElementById("response").innerHTML = "";
    // console.log(this.store);
    // console.log(this.originalStore);
  }

  onSubmit() {
  //   this.storeService.updateStore(updatedStore).subscribe( response => {
  //     if (response) {
  //       document.getElementById("response").innerHTML = "<h5>Cambios Guardados!!</h5>";
  //     }
  //   })
  //   this.originalStore = this.store;
  console.log(this.newStore);
  
  }
}

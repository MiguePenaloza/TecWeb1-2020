import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/models/Srore';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css']
})
export class StoresComponent implements OnInit {

  storesList: Store[];

  constructor(private storeService: StoreService) { }

  ngOnInit(): void {
    this.storeService.getStores().subscribe(stores => {
      this.storesList = stores;
    });
  }

  deleteStore(storeToDelete: Store): void {
    if (confirm('Are you sure you want to delete this Store?!')) {
      this.storeService.deleteStore(storeToDelete).subscribe(r => {
        this.storesList = this.storesList.filter(stores => stores.id != storeToDelete.id);
        alert("Instrument deleted Successfully!!");
      }, (error) => {
        if (error.status == 401) {
          alert("No tiene permisos para eliminar Stores!!");
        }
      });
    } else {
      console.log("You cancel the action");
    }
  }

  addStoreAndSend(storeToAdd :Store) {
    this.storeService.addStore(storeToAdd).subscribe( store => {
      this.storesList.push(store);
      alert("Store created Successfully!!, You can close this form now.");
    }, (error) => {
      if (error.status == 401) {
        alert("No tiene permisos para añadir Stores!!");
      } else if (error.status == 400) {
        alert("Campos ingresados invalidos!!");
      }
    });
  }

  orderBy(value :string) {
    this.storeService.setQueryParam(`?orderBy=${value}`);
    this.storeService.getStores().subscribe(stores => {
      this.storesList = stores;
    });
  }
}


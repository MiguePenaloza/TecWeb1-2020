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
      }, (error) => {
        if (error.status == 401) {
          alert("No tiene permisos para eliminar Stores!!");
        }
      });
    } else {
      console.log("You cancel the action");
    }
  }
}

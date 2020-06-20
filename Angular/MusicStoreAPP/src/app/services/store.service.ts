import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Store } from '../models/Srore';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  storesUrl :string = 'https://localhost:44317/api/Stores';
  storesQueryParam :string = '?orderBy=name';
  
  constructor(private http :HttpClient) { }

  getStores() :Observable<Store[]> {
    return this.http.get<Store[]>(this.storesUrl);
  }

  getStore(id :string) :Observable<Store> {
    return this.http.get<Store>(this.storesUrl);
  }

  addStore(storeToAdd :Store) :Observable<Store> {
    return this.http.post<Store>(this.storesUrl, storeToAdd, httpOptions);
  }

  updateStore(storeToUpdate :Store) :Observable<Store> {
    return this.http.put<Store>(`${this.storesUrl}/${storeToUpdate.id}`, storeToUpdate, httpOptions);
  }

  deleteStore(storeToDelete :Store) :Observable<boolean> {
    return this.http.delete<boolean>(`${this.storesUrl}/${storeToDelete.id}`);
  }
}

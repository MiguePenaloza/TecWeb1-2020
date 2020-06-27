import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Store } from '../models/Srore';

var httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  storesUrl :string = 'https://localhost:44317/api/Stores';
  storesQueryParam :string = '?orderBy=name';
  
  constructor(private http :HttpClient) { }

  setJWT(token :string) :void {
    httpOptions.headers = httpOptions.headers.set("Authorization", `Bearer ${token}`);
  }

  getStores() :Observable<Store[]> {    
    return this.http.get<Store[]>(this.storesUrl+this.storesQueryParam);
  }

  getStore(id :string) :Observable<Store> {
    return this.http.get<Store>(`${this.storesUrl}/${id}`,httpOptions);
  }

  addStore(storeToAdd :Store) :Observable<Store> {
    return this.http.post<Store>(this.storesUrl, storeToAdd, httpOptions);
  }

  updateStore(storeToUpdate :Store) :Observable<Store> {
    return this.http.put<Store>(`${this.storesUrl}/${storeToUpdate.id}`, storeToUpdate, httpOptions);
  }

  deleteStore(storeToDelete :Store) :Observable<boolean> {
    return this.http.delete<boolean>(`${this.storesUrl}/${storeToDelete.id}`, httpOptions);
  }
}

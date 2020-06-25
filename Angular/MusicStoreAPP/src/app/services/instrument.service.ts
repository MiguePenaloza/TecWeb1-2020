import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Instrument } from '../models/Instrument';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class InstrumentService {

  storesUrl :string = 'https://localhost:44317/api/Stores';
  instrumentsQueryParam :string = '?orderBy=description';

  constructor(private http :HttpClient) { }

  getInstruments(storeId :string) :Observable<Instrument[]> {
    return this.http.get<Instrument[]>(`${this.storesUrl}/${storeId}/instruments${this.instrumentsQueryParam}`);
  }

  getInstrument(storeId :string, instrumentId :string) :Observable<Instrument> {
    return this.http.get<Instrument>(`${this.storesUrl}/${storeId}/instruments/${instrumentId}`);
  }

  addInstrument(storeId :string, instrumentToAdd :Instrument) :Observable<Instrument> {
    return this.http.post<Instrument>(`${this.storesUrl}/${storeId}/instruments/`, instrumentToAdd, httpOptions);
  }

  updateInstrument(instrumentToUpdate :Instrument) :Observable<boolean> {
    console.log(instrumentToUpdate);
    
    return this.http.put<boolean>(`${this.storesUrl}/${instrumentToUpdate.storeId}/instruments/${instrumentToUpdate.id}`, instrumentToUpdate, httpOptions);
  }

  deleteInstrument(storeId :string, instrumentToDelete :Instrument) :Observable<boolean> {
    return this.http.delete<boolean>(`${this.storesUrl}/${storeId}/instruments/${instrumentToDelete.id}`);
  }
}

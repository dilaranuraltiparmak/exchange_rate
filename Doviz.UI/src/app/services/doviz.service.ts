import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Doviz } from '../models/doviz';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class DovizService {

private url="Doviz";
constructor(private http: HttpClient) {}
public getDovizs(): Observable<Doviz[]>{
  return this.http.get<Doviz[]>(`${environment.apiUrl}/${this.url}`);
}
}

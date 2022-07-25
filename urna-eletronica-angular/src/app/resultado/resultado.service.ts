import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Votes } from '../models/Votes';

@Injectable({
  providedIn: 'root'
})
export class ResultadoService {

  urlBase = `${environment.UrlBase}/votes`;

constructor(private http: HttpClient ) { }

  getAll(): Observable<Votes[]>{
    return this.http.get<Votes[]>(`${this.urlBase}`);
  }
}

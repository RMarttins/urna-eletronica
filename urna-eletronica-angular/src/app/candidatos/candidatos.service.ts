import { Candidate } from '../models/Candidate';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CandidatosService {

  urlBase =  `${environment.UrlBase}`;

  constructor(private http: HttpClient) { }

    getAll(): Observable<Candidate[]>{
      return this.http.get<Candidate[]>(`${this.urlBase}/candidates`);
    }

    getByLegenda(legenda: number): Observable<Candidate>{
      return this.http.get<Candidate>(`${this.urlBase}/candidate/${legenda}`);
    }

    delete(id: number){
     return this.http.delete(`${this.urlBase}/candidate/${id}`);
    }

    post(candidate: Candidate){
      return this.http.post(`${this.urlBase}/candidate`, candidate);
    }

}

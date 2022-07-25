import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Vote } from '../models/Vote';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  urlBase = `${environment.UrlBase}/vote`;

constructor(private http: HttpClient) { }

  insertVote(vote : Vote){
    console.log(vote);
    return this.http.post(`${this.urlBase}`, vote);
  }

}

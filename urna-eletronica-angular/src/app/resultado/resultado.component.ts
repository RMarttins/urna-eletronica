import { ResultadoService } from './resultado.service';
import { Component, OnInit } from '@angular/core';
import { Votes } from '../models/Votes';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit {

  public title = 'Resultado da Eleição';
  public votes!: Votes[];
  public loading = true;
  public totalValidos!: Number;
  public totalBrancos!: Number;
  public totalNulos!: Number;

  constructor(private result: ResultadoService) { }

  ngOnInit() {
    this.getVotes();
  }

  getVotes(){
    this.result.getAll().subscribe({
     next:(votes : Votes[]) => {
        this.votes = votes;
        this.totalValidos = votes[0].totalValidos;
        this.totalBrancos = votes[0].totalBrancos;
        this.totalNulos = votes[0].totalNulos;
        this.loading = false;
      },
      error:(erro : any) => {
        console.error(erro);
      }
    });
  }
}

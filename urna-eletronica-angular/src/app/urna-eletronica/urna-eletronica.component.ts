import { TypeVote } from './../enums/TypeVote.enum';
import { InfoCandidateComponent } from './info-candidate/info-candidate.component';
import { VoteService } from './vote.service';
import { Component, OnInit, Output } from '@angular/core';
import { CandidatosService } from '../candidatos/candidatos.service';
import { Candidate } from '../models/Candidate';
import { Vote } from '../models/Vote';

@Component({
  selector: 'app-urna-eletronica',
  templateUrl: './urna-eletronica.component.html',
  styleUrls: ['./urna-eletronica.component.css']
})
export class UrnaEletronicaComponent implements OnInit {

  public dig1 = '';
  public dig2 = '';
  public flagFimVotacao = false;
  public flagCandidatoExist = false;
  public flagVoteNull = false;
  public flagVoteWhite = false;
  public candidate! : Candidate;
  public infocandidate = InfoCandidateComponent;
  public vote!: Vote;
  public errorMessage!: any;

  constructor(private serviceCand: CandidatosService, private serviceVote: VoteService) { }

  ngOnInit() {
  }

  typedNumber(num: string){
    if(this.dig1 == '')
      this.dig1 = num;
    else if(this.dig2 == ''){
      this.dig2 = num;
      this.getCandidateByLegenda(Number(`${this.dig1}${this.dig2}`));
    }
  }

  clean(){
    this.dig1 = '';
    this.dig2 = '';
    this.flagCandidatoExist = false;
    this.flagVoteNull = false;
    this.flagVoteWhite = false;
    this.candidate = new Candidate;
  }

  voteWhite(){
    this.flagVoteWhite = true;
    this.flagVoteNull = false;
    this.flagCandidatoExist = false;
  }

  reiniciarVotacao(){
    this.flagFimVotacao = false;
    this.clean();
  }

  getCandidateByLegenda(legenda: number){
    this.serviceCand.getByLegenda(legenda).subscribe({
        next: (result: any) => {
          this.candidate = result;
          this.flagCandidatoExist = true;
        },
        error: () => {
          this.flagVoteNull = true;
        }
      }
    )
  }

  //Função para salvar os votos
  confirmVote(){
    if(this.dig1.trim() == '' || this.dig2.trim() == '')
      console.log('Número da legenda não informadp.');
    if(this.flagCandidatoExist){
      this.serviceVote.insertVote(new Vote(this.candidate.id, TypeVote.VALIDO)).subscribe({
        next: (result: any) => {
          console.log(result);
          this.flagFimVotacao = true;
          this.clean();
        },
        error: (e : any) =>{
          if(e.error.hasError){
            this.errorMessage = e.error.errorMessage;
            console.error(this.errorMessage);
          }
          else{
            console.error(e);
            this.errorMessage = Object.values(e.error.errors);
          }
        }
      });
    }

    if(this.flagVoteWhite){
      this.serviceVote.insertVote(new Vote(0, TypeVote.BRANCO)).subscribe({
        next: (result: any) => {
          console.log(result);
          this.flagFimVotacao = true;
          this.clean();
        },
        error:(e : any) => {
            if(e.error.hasError){
              this.errorMessage = e.error.errorMessage;
              console.error(this.errorMessage);
            }
            else{
              console.error(e);
              this.errorMessage = Object.values(e.error.errors);
            }
        }
      });
    }

    if(this.flagVoteNull){
      this.serviceVote.insertVote(new Vote(0, TypeVote.NULO)).subscribe({
        next: (result: any) => {
          console.log(result);
          this.flagFimVotacao = true;
          this.clean();
        },
        error:(e : any) => {
            if(e.error.hasError){
              this.errorMessage = e.error.errorMessage;
              console.error(this.errorMessage);
            }
            else{
              console.error(e);
              this.errorMessage = Object.values(e.error.errors);
            }
        }
      });
    }

  }
}

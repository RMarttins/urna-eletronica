import { BackdropComponent } from './../backdrop/backdrop.component';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Candidate } from '../models/Candidate';
import { CandidatosService } from './candidatos.service';

@Component({
  selector: 'app-candidatos',
  templateUrl: './candidatos.component.html',
  styleUrls: ['./candidatos.component.css']
})
export class CandidatosComponent implements OnInit {

  public candidateForm!: FormGroup;
  public title = 'Candidatos Cadastrados';
  public newCandidateFlag = false;
  public candidates!: Candidate[];
  public errorMessage!: any;
  public loading = true;
  @ViewChild('error') divError!: ElementRef;
 public backdrop! : any;

  constructor(private fb: FormBuilder ,private service: CandidatosService) {
    this.createForm();
  }

  ngOnInit() {
    this.getCandidates();
  }

  getCandidates(){
    this.service.getAll().subscribe({
      next: (candidates : Candidate[]) => this.candidates = candidates,
      error: (e) => console.error(e),
      complete: () => {
        this.backdrop = null;
        this.loading = false;
      }
    })
  }

  createCandidate(){
    this.backdrop = BackdropComponent;
    this.service.post(this.candidateForm.value).subscribe({
      next: (result : any) => {
        console.log(result);
        this.getCandidates();
        this.newCandidateBtnClick(false);
      },
      error: (erro : any) => {
        this.divError.nativeElement.className = 'container-fluid mt-4 msg-error visible break-line';
        if(erro.error.hasError){
          this.errorMessage = erro.error.errorMessage;
        }
        else{
          console.error(erro);
          this.errorMessage = Object.values(erro.error.errors);
        }
        this.backdrop = null
      }
    });
  }

  deleteCandidate(id: number){
    this.backdrop = BackdropComponent;
    this.service.delete(id).subscribe(
      () => {
        this.getCandidates();
      },
      (erro : any) => {
        console.error(erro);
      }
    );
  }

  newCandidateBtnClick(act: boolean){
    this.newCandidateFlag = act;
    if(act){
      this.title = 'Novo Candidato';
      this.createForm();
    }

    else
      this.title = 'Candidatos Cadastrados';
  }

  createForm(){
    this.candidateForm = this.fb.group(
      {
        candidateName: [''],
        viceName: [''],
        legenda: [''],
        partido: ['']
      }
    );
  }
}

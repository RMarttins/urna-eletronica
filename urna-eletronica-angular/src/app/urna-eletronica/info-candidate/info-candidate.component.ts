import { Candidate } from './../../models/Candidate';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-info-candidate',
  templateUrl: './info-candidate.component.html',
  styleUrls: ['./info-candidate.component.css']
})
export class InfoCandidateComponent implements OnInit {

  @Input() candidateInput!: Candidate;

  constructor() {console.log(this.candidateInput); }

  ngOnInit() {
  }

}

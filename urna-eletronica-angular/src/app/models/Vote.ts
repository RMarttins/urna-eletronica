export class Vote {
  constructor(candidateId: number, typeVote: number){
    this.candidateId = candidateId,
    this.typeVote = typeVote
  }

  id!: number;
  candidateId: number;
  dtVote!: Date;
  typeVote!: number;
}

import { HomepageComponent } from './homepage/homepage.component';
import { UrnaEletronicaComponent } from './urna-eletronica/urna-eletronica.component';
import { ResultadoComponent } from './resultado/resultado.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidatosComponent } from './candidatos/candidatos.component';

const routes: Routes = [
  {path: '', component: HomepageComponent},
  {path: 'home', component: HomepageComponent},
  {path: 'resultado', component: ResultadoComponent},
  {path: 'candidatos', component: CandidatosComponent},
  {path: 'urna', component: UrnaEletronicaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

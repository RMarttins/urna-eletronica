import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ResultadoComponent } from './resultado/resultado.component';
import { UrnaEletronicaComponent } from './urna-eletronica/urna-eletronica.component';
import { HomepageComponent } from './homepage/homepage.component';
import { TitlePageComponent } from './title-page/title-page.component';
import { CandidatosComponent } from './candidatos/candidatos.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BackdropComponent } from './backdrop/backdrop.component';
import { InfoCandidateComponent } from './urna-eletronica/info-candidate/info-candidate.component';
import { MsgConfirmaVotoComponent } from './urna-eletronica/msg-confirma-voto/msg-confirma-voto.component';
import { MsgFimVotoComponent } from './urna-eletronica/msg-fim-voto/msg-fim-voto.component';
import { MsgVotoNuloComponent } from './urna-eletronica/msg-voto-nulo/msg-voto-nulo.component';
import { MsgVotoBrancoComponent } from './urna-eletronica/msg-voto-branco/msg-voto-branco.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
      ResultadoComponent,
      UrnaEletronicaComponent,
      HomepageComponent,
      TitlePageComponent,
      CandidatosComponent,
      BackdropComponent,
      InfoCandidateComponent,
      MsgConfirmaVotoComponent,
      MsgFimVotoComponent,
      MsgVotoNuloComponent,
      MsgVotoBrancoComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

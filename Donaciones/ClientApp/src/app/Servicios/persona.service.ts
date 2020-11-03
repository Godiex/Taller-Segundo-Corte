import { Inject, Injectable } from '@angular/core';
import { Observable  } from 'rxjs';
import { Persona } from '../Modelos/Persona/persona';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { GuardarPersonaResponse } from '../Modelos/GuardarPersonaResponse/guardar-persona-response';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;
  Personas = [];
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {this.baseUrl = baseUrl;}

  get(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.baseUrl + 'api/Persona')
    .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Persona[]>('Consulta Persona', null))
    );
  }

  ObtenerTotalDonaciones(totalDonaciones : string): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'api/Persona/'+totalDonaciones)
    .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<number>('Consulta Persona', null))
    );
  }

  post(persona: Persona): Observable<GuardarPersonaResponse>  {

        return this.http.post<GuardarPersonaResponse>(this.baseUrl + 'api/Persona', persona)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<GuardarPersonaResponse>('Registrar Persona', null))
        );
  }

}

import { from } from "rxjs";
import { Persona } from '../Persona/persona';

export class GuardarPersonaResponse {
  persona : Persona = new Persona();
  error : boolean;
  mensaje : string;
}

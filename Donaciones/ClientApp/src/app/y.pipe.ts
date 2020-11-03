import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from './Modelos/Persona/persona';

@Pipe({
  name: 'y'
})
export class YPipe implements PipeTransform {

  transform(personas: Persona[], searchText: string): any {
    if (searchText == null) return personas;
    return personas.filter(p =>
    p.nombres.toLowerCase()
    .indexOf(searchText.toLowerCase()) !== -1);
  }

}

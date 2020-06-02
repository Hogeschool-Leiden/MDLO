import { Pipe, PipeTransform } from '@angular/core';
import { Module } from '../models/module';
import { Specialisatie } from '../models/specialisatie';

@Pipe({
  name: 'moduleSanitize'
})
export class ModuleSanitizePipe implements PipeTransform {

  transform(value: any, ...args: unknown[]): Module {
    let aanbevolenVoor = this.checkIfSpecialisatiesHaveToBeAdded(value.aanbevolenVoor);
    let verplichtVoor = this.checkIfSpecialisatiesHaveToBeAdded(value.verplichtVoor);

    let module: Module = {
      id: undefined,
      moduleNaam: value.moduleNaam,
      moduleCode: value.moduleCode,
      aantalEc: parseInt(value.aantalEc),
      studiejaar: value.studiejaar,
      moduleleider: { id: undefined, naam: value.moduleleider.naam, email: value.moduleleider.email, telefoonnummer: value.moduleleider.telefoonnummer },
      studiefase: { id: undefined, fase: value.studiefase.fase, periode: { id: undefined, periodeNummer: parseInt(value.studiefase.periode) } },
      verplichtVoor: verplichtVoor,
      aanbevolenVoor: aanbevolenVoor,
      beschrijvingLeerdoelen: value.beschrijvingLeerdoelen,
      inhoudelijkeBeschrijving: value.inhoudelijkeBeschrijving,
      eindeisen: value.eindeisen,
      contacturenWerkvormen: value.contacturenWerkvormen,
      toetsvorm: value.toetsvorm,
      voorwaardenVoldoende: value.voorwaardenVoldoende,
      letOp: value.letOp,
      summatief: this.checkIfToetsvormIsTrueAndReturnResult(value.summatief),
      formatief: this.checkIfToetsvormIsTrueAndReturnResult(value.formatief),
      kwalitatief: this.checkIfToetsvormIsTrueAndReturnResult(value.kwalitatief),
      kwantitatief: this.checkIfToetsvormIsTrueAndReturnResult(value.kwantitatief),
      examinatoren: value.examinatoren
    };
    return module;
  }

  private checkIfSpecialisatiesHaveToBeAdded(specialisatieCheckboxResultaten: any): any[] {
    let ret = [];
    if(specialisatieCheckboxResultaten.SE === true){
      ret.push({id: undefined, naam: "Software Engineering", code: "SE"} as Specialisatie);
    } 
    if(specialisatieCheckboxResultaten.IAT === true){
      ret.push({id: undefined, naam: "Interactie Technologie", code: "IAT"} as Specialisatie);
    } 
    if(specialisatieCheckboxResultaten.FICT === true){
      ret.push({id: undefined, naam: "Forensische IT", code: "FICT"} as Specialisatie);
    } 
    if(specialisatieCheckboxResultaten.BDAM === true){
      ret.push({id: undefined, naam: "Big Data and Management", code: "BDAM"} as Specialisatie);
    } 
    return ret;
  }

  private checkIfToetsvormIsTrueAndReturnResult(input: any): boolean {
    if(input === true){
      return true;
    } 
    return false;
  }

}

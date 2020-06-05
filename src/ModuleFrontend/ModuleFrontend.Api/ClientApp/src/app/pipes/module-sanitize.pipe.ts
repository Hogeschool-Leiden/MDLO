import { Pipe, PipeTransform } from '@angular/core';
import { Module } from '../models/module';
import { Specialisatie } from '../models/specialisatie';
import { Matrix } from '../models/matrix';

@Pipe({
  name: 'moduleSanitize'
})
export class ModuleSanitizePipe implements PipeTransform {

  transform(unsanitizedValue: any, ...args: unknown[]): Module {
    let aanbevolenVoor = this.checkIfSpecialisatiesHaveToBeAdded(unsanitizedValue.aanbevolenVoor);
    let verplichtVoor = this.checkIfSpecialisatiesHaveToBeAdded(unsanitizedValue.verplichtVoor);

    let module: Module = {
      id: undefined,
      moduleNaam: unsanitizedValue.moduleNaam,
      moduleCode: unsanitizedValue.moduleCode,
      aantalEc: parseInt(unsanitizedValue.aantalEc),
      studiejaar: unsanitizedValue.studiejaar,
      moduleleider: { id: undefined, naam: unsanitizedValue.moduleleider.naam, email: unsanitizedValue.moduleleider.email, telefoonnummer: unsanitizedValue.moduleleider.telefoonnummer },
      studiefase: { id: undefined, fase: unsanitizedValue.studiefase.fase, periode: { id: undefined, periodeNummer: parseInt(unsanitizedValue.studiefase.periode) } },
      verplichtVoor: verplichtVoor,
      aanbevolenVoor: aanbevolenVoor,
      competenties: this.getMatrixWithCorrectValues(unsanitizedValue.competenties),
      beschrijvingLeerdoelen: unsanitizedValue.beschrijvingLeerdoelen,
      inhoudelijkeBeschrijving: unsanitizedValue.inhoudelijkeBeschrijving,
      eindeisen: unsanitizedValue.eindeisen,
      contacturenWerkvormen: unsanitizedValue.contacturenWerkvormen,
      toetsvorm: unsanitizedValue.toetsvorm,
      voorwaardenVoldoende: unsanitizedValue.voorwaardenVoldoende,
      letOp: unsanitizedValue.letOp,
      summatief: this.checkIfToetsvormIsTrueAndReturnResult(unsanitizedValue.summatief),
      formatief: this.checkIfToetsvormIsTrueAndReturnResult(unsanitizedValue.formatief),
      kwalitatief: this.checkIfToetsvormIsTrueAndReturnResult(unsanitizedValue.kwalitatief),
      kwantitatief: this.checkIfToetsvormIsTrueAndReturnResult(unsanitizedValue.kwantitatief),
      examinatoren: unsanitizedValue.examinatoren
    };
    return module;
  }

  private checkIfSpecialisatiesHaveToBeAdded(specialisatieCheckboxResultaten: any): any[] {
    let ret = [];
    if (specialisatieCheckboxResultaten.SE === true) {
      ret.push({ id: undefined, naam: "Software Engineering", code: "SE" } as Specialisatie);
    }
    if (specialisatieCheckboxResultaten.IAT === true) {
      ret.push({ id: undefined, naam: "Interactie Technologie", code: "IAT" } as Specialisatie);
    }
    if (specialisatieCheckboxResultaten.FICT === true) {
      ret.push({ id: undefined, naam: "Forensische IT", code: "FICT" } as Specialisatie);
    }
    if (specialisatieCheckboxResultaten.BDAM === true) {
      ret.push({ id: undefined, naam: "Big Data and Management", code: "BDAM" } as Specialisatie);
    }
    return ret;
  }

  private checkIfToetsvormIsTrueAndReturnResult(input: any): boolean {
    if (input === true) {
      return true;
    }
    return false;
  }

  private getMatrixWithCorrectValues(unsanitizedMatrixJson: any): Matrix {
    let mtx = {} as Matrix;
    mtx.xHeaders = ["gebruikersinteractie", "organisatieprocessen", "infrastructuur", "software", "hardware interfacing"]
    mtx.yHeaders = ["analyseren", "adviseren", "ontwerpen", "realiseren", "manage&control"]
    mtx.cells = new Array(5);
    for (let index = 0; index < mtx.cells.length; index++) {
      mtx.cells[index] = new Array(5);
    }

    mtx.cells[0][0]=unsanitizedMatrixJson.GIAN;
    mtx.cells[0][1]=unsanitizedMatrixJson.GIAD;
    mtx.cells[0][2]=unsanitizedMatrixJson.GION;
    mtx.cells[0][3]=unsanitizedMatrixJson.GIRE;
    mtx.cells[0][4]=unsanitizedMatrixJson.GIBE;

    mtx.cells[1][0]=unsanitizedMatrixJson.BPAN;
    mtx.cells[1][1]=unsanitizedMatrixJson.BPAD;
    mtx.cells[1][2]=unsanitizedMatrixJson.BPON;
    mtx.cells[1][3]=unsanitizedMatrixJson.BPRE;
    mtx.cells[1][4]=unsanitizedMatrixJson.BPBE;

    mtx.cells[2][0]=unsanitizedMatrixJson.ISAN;
    mtx.cells[2][1]=unsanitizedMatrixJson.ISAD;
    mtx.cells[2][2]=unsanitizedMatrixJson.ISON;
    mtx.cells[2][3]=unsanitizedMatrixJson.ISRE;
    mtx.cells[2][4]=unsanitizedMatrixJson.ISBE;

    mtx.cells[3][0]=unsanitizedMatrixJson.SWAN;
    mtx.cells[3][1]=unsanitizedMatrixJson.SWAD;
    mtx.cells[3][2]=unsanitizedMatrixJson.SWON;
    mtx.cells[3][3]=unsanitizedMatrixJson.SWRE;
    mtx.cells[3][4]=unsanitizedMatrixJson.SWBE;

    mtx.cells[4][0]=unsanitizedMatrixJson.HIAN;
    mtx.cells[4][1]=unsanitizedMatrixJson.HIAD;
    mtx.cells[4][2]=unsanitizedMatrixJson.HION;
    mtx.cells[4][3]=unsanitizedMatrixJson.HIRE;
    mtx.cells[4][4]=unsanitizedMatrixJson.HIBE;


    return mtx;
  }

}

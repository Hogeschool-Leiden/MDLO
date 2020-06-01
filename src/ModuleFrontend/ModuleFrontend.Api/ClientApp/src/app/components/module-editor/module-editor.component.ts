import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpService } from 'src/app/services/http.service';
import { Module } from '../../models/module';

@Component({
  selector: 'app-module-editor',
  templateUrl: './module-editor.component.html',
  styleUrls: ['./module-editor.component.css']
})
export class ModuleEditorComponent {
  constructor(private httpService: HttpService) {

  }

  jsonValue = null;
  jsonValueReturnes = null;
  moduleForm = new FormGroup({
    id: new FormControl({ value: '', disabled: true }),
    moduleNaam: new FormControl(''),
    moduleCode: new FormControl(''),
    aantalEc: new FormControl(''),
    studiejaar: new FormControl(''),
    moduleleider: new FormGroup({
      naam: new FormControl(''),
      email: new FormControl(''),
      telefoonnummer: new FormControl(''),
    }),
    studiefase: new FormGroup({
      fase: new FormControl(''),
      periode: new FormControl(''),
    }),
    verplichtVoor: new FormGroup({
      SE: new FormControl(''),
      FICT: new FormControl(''),
      BDAM: new FormControl(''),
      IAT: new FormControl(''),
    }),
    aanbevolenVoor: new FormGroup({
      SE: new FormControl(''),
      FICT: new FormControl(''),
      BDAM: new FormControl(''),
      IAT: new FormControl(''),
    }),
    beschrijvingLeerdoelen: new FormControl(''),
    inhoudelijkeBeschrijving: new FormControl(''),
    eindeisen: new FormControl(''),
    contacturenWerkvormen: new FormControl(''),
    toetsvorm: new FormControl(''),
    voorwaardenVoldoende: new FormControl(''),
    letOp: new FormControl(''),
    summatief: new FormControl(''),
    formatief: new FormControl(''),
    kwalitatief: new FormControl(''),
    kwantitatief: new FormControl(''),
    examinatoren: new FormControl(''),
  })

  onSubmit() {
    this.jsonValue = this.moduleForm.value as Module;
    this.httpService.postModule(this.moduleForm.value as Module).subscribe(
      data =>{
        this.jsonValueReturnes = data as Module;
      }, err =>{
        console.log(err);
      }
    )
  }
}

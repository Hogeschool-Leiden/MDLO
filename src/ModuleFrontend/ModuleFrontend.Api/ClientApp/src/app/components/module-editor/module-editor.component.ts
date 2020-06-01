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
  moduleForm = new FormGroup({
    Id: new FormControl({ value: '', disabled: true }),
    ModuleNaam: new FormControl(''),
    ModuleCode: new FormControl(''),
    AantalEc: new FormControl(''),
    Studiejaar: new FormControl(''),
    Moduleleider: new FormGroup({
      Naam: new FormControl(''),
      Email: new FormControl(''),
      Telefoonnummer: new FormControl(''),
    }),
    Studiefase: new FormGroup({
      Fase: new FormControl(''),
      Periode: new FormControl(''),
    }),
    VerplichtVoor: new FormGroup({
      SE: new FormControl(''),
      FICT: new FormControl(''),
      BDAM: new FormControl(''),
      IAT: new FormControl(''),
    }),
    AanbevolenVoor: new FormGroup({
      SE: new FormControl(''),
      FICT: new FormControl(''),
      BDAM: new FormControl(''),
      IAT: new FormControl(''),
    }),
    BeschrijvingLeerdoelen: new FormControl(''),
    InhoudelijkeBeschrijving: new FormControl(''),
    Eindeisen: new FormControl(''),
    ContacturenWerkvormen: new FormControl(''),
    Toetsvorm: new FormControl(''),
    VoorwaardenVoldoende: new FormControl(''),
    LetOp: new FormControl(''),
    Summatief: new FormControl(''),
    Formatief: new FormControl(''),
    Kwalitatief: new FormControl(''),
    Kwantitatief: new FormControl(''),
    Examinatoren: new FormControl(''),
  })

  onSubmit() {
    this.jsonValue = this.moduleForm.value as Module;
    this.httpService.postModule(this.moduleForm.value as Module).subscribe(
      data =>{
        console.log(data);
      }, err =>{
        console.log(err);
      }
    )
  }
}

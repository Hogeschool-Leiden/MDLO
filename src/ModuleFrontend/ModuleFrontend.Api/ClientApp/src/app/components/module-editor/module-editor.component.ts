import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpService } from 'src/app/services/http.service';
import { Module } from '../../models/module';
import { ModuleSanitizePipe } from 'src/app/pipes/module-sanitize.pipe';
import { MatSnackBar } from '@angular/material/snack-bar';
import { config } from 'process';

@Component({
  selector: 'app-module-editor',
  templateUrl: './module-editor.component.html',
  styleUrls: ['./module-editor.component.css']
})
export class ModuleEditorComponent {
  constructor(private snackBar: MatSnackBar, private httpService: HttpService, private sanitizePipe: ModuleSanitizePipe) {

  }
  jsonValue: null;
  jsonValueAfterPipe: null;
  moduleForm = new FormGroup({
    id: new FormControl({ value: '', disabled: true }),
    moduleNaam: new FormControl('', Validators.required),
    moduleCode: new FormControl('', Validators.required),
    aantalEc: new FormControl('', Validators.required),
    studiejaar: new FormControl('', Validators.required),
    moduleleider: new FormGroup({
      naam: new FormControl('', [Validators.minLength(2), Validators.required]),
      email: new FormControl('', [Validators.email, Validators.required]),
      telefoonnummer: new FormControl('', [Validators.minLength(10), Validators.required]),
    }),
    studiefase: new FormGroup({
      fase: new FormControl(''),
      periode: new FormControl(''),
    }),
    verplichtVoor: new FormGroup({
      SE: new FormControl(false),
      FICT: new FormControl(false),
      BDAM: new FormControl(false),
      IAT: new FormControl(false),
    }),
    aanbevolenVoor: new FormGroup({
      SE: new FormControl(false),
      FICT: new FormControl(false),
      BDAM: new FormControl(false),
      IAT: new FormControl(false),
    }), //GI = gebruiksinteractie, BP = bedrijfsprocessen, IS = infractructuur, SW = sotware, HI = hardware interfacing
    //BE = beheren, AN = analyseren, AD = adviseren, ON = ontwerpen, RE = realiseren
    competenties: new FormGroup({

      GIAN: new FormControl(0),
      GIAD: new FormControl(0),
      GION: new FormControl(0),
      GIRE: new FormControl(0),
      GIBE: new FormControl(0),
      BPAN: new FormControl(0),
      BPAD: new FormControl(0),
      BPON: new FormControl(0),
      BPRE: new FormControl(0),
      BPBE: new FormControl(0),
      ISAN: new FormControl(0),
      ISAD: new FormControl(0),
      ISON: new FormControl(0),
      ISRE: new FormControl(0),
      ISBE: new FormControl(0),
      SWAN: new FormControl(0),
      SWAD: new FormControl(0),
      SWON: new FormControl(0),
      SWRE: new FormControl(0),
      SWBE: new FormControl(0),
      HIAN: new FormControl(0),
      HIAD: new FormControl(0),
      HION: new FormControl(0),
      HIRE: new FormControl(0),
      HIBE: new FormControl(0),
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
    this.jsonValue = this.moduleForm.value;
    this.jsonValueAfterPipe = this.sanitizePipe.transform(this.moduleForm.value) as any;
    this.httpService.postModule(this.sanitizePipe.transform(this.moduleForm.value)).subscribe(
      data => {
      }, err => {
        if (err.error[0].errors[0].errorMessage.includes("Duplicate ModuleCode")) {
          var snackBarRef = this.snackBar.open('Modulecode bestaat al.', '', { duration: 3000 });
        }
      }
    )
  }
}

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

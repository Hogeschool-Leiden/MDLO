import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { HttpService } from 'src/app/services/http.service';
import { Module } from '../../models/module';
import { ModuleSanitizePipe } from 'src/app/pipes/module-sanitize.pipe';
import { MatSnackBar } from '@angular/material/snack-bar';
import { config } from 'process';
import { Cohort } from 'src/app/models/cohort';

@Component({
  selector: 'app-module-editor',
  templateUrl: './module-editor.component.html',
  styleUrls: ['./module-editor.component.css']
})
export class ModuleEditorComponent implements OnInit{
  constructor(private snackBar: MatSnackBar, private httpService: HttpService, private sanitizePipe: ModuleSanitizePipe) {

  }
  ngOnInit(): void {
    this.addEindeis();
    this.addPeriode();
  }
  
  availableCohorts: Cohort[] =[{ naam: "2017/2018", beginjaar: "2017/2018" }, { naam: "2018/2019", beginjaar: "2018/2019" }, { naam: "2019/2020", beginjaar: "2019/2020" },]
  jsonValue: null;
  jsonValueAfterPipe: null;
  moduleForm = new FormGroup({
    id: new FormControl({ value: '', disabled: true }),
    moduleNaam: new FormControl(''),
    moduleCode: new FormControl(''),
    cohort: new FormControl(''),
    aantalEc: new FormControl(0),
    studiejaar: new FormControl(''),
    moduleleider: new FormGroup({
      naam: new FormControl(''),
      email: new FormControl(''),
      telefoonnummer: new FormControl(),
    }),
    studiefase: new FormGroup({
      fase: new FormControl(''),
      periode: new FormArray([]),
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
    eindeisen: new FormArray([

    ]),
  })

  onSubmit() {
    this.jsonValue = this.moduleForm.value;
    this.jsonValueAfterPipe = this.sanitizePipe.transform(this.moduleForm.value) as any;
    this.httpService.postModule(this.sanitizePipe.transform(this.moduleForm.value)).subscribe(
      data => {
      }, err => {
        if (err.error[0].errors[0].errorMessage.includes("Duplicate ModuleCode")) {
          var snackBarRef = this.snackBar.open('Modulecode bestaat al.', '', { duration: 3000 });
          console.log(err);
        }
      }
    )
  }
  addEindeis(){
    this.eindeisen.push(new FormControl(''));
  }

  changeCohort(e){
    this.moduleForm.get('cohort').setValue(e.target.value,{onlySelf: true})
  }
  get eindeisen(){
    return this.moduleForm.get('eindeisen') as FormArray;
  }

  get periode(){
    return this.moduleForm.get('studiefase').get('periode') as FormArray;
  }

  addPeriode(){
    this.periode.push(new FormControl(0));
  }
}

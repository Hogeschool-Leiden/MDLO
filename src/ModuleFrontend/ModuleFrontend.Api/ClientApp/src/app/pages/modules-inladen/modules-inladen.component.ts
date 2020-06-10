import { Component } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-modules-inladen',
  templateUrl: './modules-inladen.component.html',
  styleUrls: ['./modules-inladen.component.css']
})
export class ModulesInladenComponent{
  selectedFile: File = null;
  constructor(private fb: FormBuilder, private httpService: HttpService) { }

  modulesInladenForm = this.fb.group({
    cohort: ['', Validators.required],
  })

  onFileChange(fileInput: any) {
    this.selectedFile = <File>fileInput.target.files[0];
    console.log('onFileChange called')
  }

  onSubmit(){
    const formData = new FormData();
    formData.append('cohort', this.modulesInladenForm.get('cohort').value)
    formData.append('file', this.selectedFile)

    this.httpService.PostCsvFile(formData).subscribe(
      data =>{
        console.log(data)
      },
      err =>{
        console.log(err)
      }
    )
  }
}

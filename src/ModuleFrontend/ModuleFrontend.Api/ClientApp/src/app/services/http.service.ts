import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Module } from '../models/module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) {

  }

  postModule(module: Module): Observable<Module>{
    return this.http.post<Module>(this.baseUrl+'module', module)
  }

}

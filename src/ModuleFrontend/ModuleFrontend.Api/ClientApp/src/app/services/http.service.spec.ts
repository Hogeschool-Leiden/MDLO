import { TestBed } from '@angular/core/testing';

import { HttpService } from './http.service';

describe('HttpService', () => {
  let service: HttpService;
  let httpClientSpy: {get: jasmine.Spy};
  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get'])
    TestBed.configureTestingModule({});
    service = new HttpService(<any> httpClientSpy, 'url');
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

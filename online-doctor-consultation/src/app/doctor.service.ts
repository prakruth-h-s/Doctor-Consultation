import { Injectable } from '@angular/core';
import { HttpClient,HttpErrorResponse  } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Doctor} from './doctor';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  private baseUrl = "http://localhost:16612/api/Doctors";

  constructor(private http: HttpClient) { }

  getDoctoremail(email:string): Observable<any> {
    return this.http.get(`${this.baseUrl}/${email}`);
  }

  createDoctor(doctor: Doctor): Observable<any> {
    return this.http.post(this.baseUrl, doctor);
  }
}

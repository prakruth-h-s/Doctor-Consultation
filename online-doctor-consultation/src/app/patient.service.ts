import { Injectable } from '@angular/core';
import{Patient} from './patient';
import {HttpClient , HttpErrorResponse} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private purl="http://localhost:16612/api/patients";
  private Durl:string="http://localhost:16612/api/doctors" ;

    constructor(private http:HttpClient) { }
    getSpecializeDoctor(specialization:string):Observable<any>{
      this.Durl=this.Durl+"/doctor/"+specialization;
      return this.http.get(this.Durl);
    }
    getPatientemail(email:string): Observable<any> {
    return this.http.get(`${this.purl}/${email}`);
    }
 
  createPatient(patient: Patient): Observable<any> {
    return this.http.post(this.purl, patient);
  }
}

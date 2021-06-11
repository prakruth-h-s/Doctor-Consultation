import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Appointment} from '../app/appointment';
@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
   
  private baseUrl="http://localhost:16612/api/Appointments";
  constructor(private http: HttpClient) { }
  
  getAppointmentByDoctorId(doctor_id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/doctor/${doctor_id}`);
  }
  getAppointment(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/appointment/${id}`);
  }

  updateAppointment(id: number, value: any): Observable<Object> {
    return this.http.put(`${this.baseUrl}/${id}`, value);
  }

  deleteAppointment(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`, { responseType: 'text' });
  }
  getAppointmentList(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }
  bookAppointment(appointment:Appointment):Observable<any>{
    return this.http.post(this.baseUrl,appointment);
  }

  //Get Prescription:
  getPrescription(id:number):Observable<any>{
    console.log(id);
    return this.http.get(this.baseUrl+"/"+id);
  } 

  addRating(aid:number,rev:string):Observable<any>{
    console.log(aid);
    console.log(rev);
    return this.http.put(this.baseUrl+"/"+aid+"/"+rev,rev);
  }
  
}

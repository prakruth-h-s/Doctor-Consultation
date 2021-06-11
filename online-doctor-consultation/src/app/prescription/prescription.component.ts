import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Appointment } from '../appointment';
import {AppointmentService} from '../appointment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-prescription',
  templateUrl: './prescription.component.html',
  styleUrls: ['./prescription.component.css']
})
export class PrescriptionComponent implements OnInit {

  public prescription:Observable<Appointment[]>;


  constructor(private _appointmentservice:AppointmentService,private router:Router) { 
    
  }

  ngOnInit(){
    console.log(Number(sessionStorage.getItem('id')));
  this._appointmentservice.getPrescription(Number(sessionStorage.getItem('id'))).subscribe(data=>this.prescription=data);
   
    
  }
  onSelect(id:number){
    this.router.navigate(['/review/'+id]); 
    }
    logout(){
      // window.sessionStorage.clear();
       sessionStorage.clear();
       this.router.navigate(['/login']);
      }
  }

import { Component, OnInit } from '@angular/core';
import { Appointment } from '../appointment';
import { Doctor } from '../doctor';
import { Patient } from '../patient';
import {AppointmentService} from '../appointment.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import {FormGroup,FormControl, Validators} from '@angular/forms';
import { DatePipe, getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-book-appointment',
  templateUrl: './book-appointment.component.html',
  styleUrls: ['./book-appointment.component.css']
})
export class BookAppointmentComponent implements OnInit {

  form:any;
 appointment:Appointment;
  constructor(private _appointmentservice:AppointmentService,private route: ActivatedRoute,private router:Router) {
    this.appointment=new Appointment();
   
    
   }
  
  ngOnInit(): void {
    
   
    this.form=new FormGroup({
     Date:new FormControl(""),
     HealthIssue:new FormControl('')  
    });    
}
onSubmit(form:any){
  this.appointment.doctorID=Number(this.route.snapshot.paramMap.get('did'));
  this.appointment.patientID=Number(sessionStorage.getItem('id'));
  console.log(this.appointment);
  this._appointmentservice.bookAppointment(this.appointment).subscribe();
  this.router.navigate(['/report']);
}
logout(){
  // window.sessionStorage.clear();
   sessionStorage.clear();
   this.router.navigate(['/login']);
  }
}

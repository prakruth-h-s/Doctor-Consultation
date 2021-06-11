import { AppointmentDetailsComponent } from '../appointment-details/appointment-details.component';
import{Appointment} from '../appointment';
import { Component, OnInit,ViewChild,ElementRef} from '@angular/core';
import { Observable } from "rxjs";
import { Router } from '@angular/router';
import{AppointmentService} from '../appointment.service';

import {NgForm,FormGroup} from '@angular/forms';


@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {
  appointments: Observable<Appointment[]>;
   appointment:Appointment;
   //var getSession=window.sessionStorage.getItem("id");
  constructor(private appointmentService: AppointmentService,
    private router: Router) { }

  ngOnInit() {
      this.reloadData();
  }
  reloadData() {
    
    this.appointmentService.getAppointmentByDoctorId(Number(sessionStorage.getItem('id'))).subscribe(data=>{this.appointments=data,console.log(data)});
    console.log(Number(sessionStorage.getItem('id')));
  }

  deleteAppointment(id: number) {
    this.appointmentService.deleteAppointment(id)
      .subscribe(
        data => {
          console.log(data);
          this.reloadData();
        },
        error => console.log(error));
  }
  AppointmentUpdate(id: number){
    this.appointmentService.updateAppointment(id, this.appointment)
      .subscribe(data => {
        this.appointment = new Appointment();        
      }, error => console.log(error));
    this.router.navigate(['update', id]);
  }
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }

  
}



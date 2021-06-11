import{Appointment} from '../appointment';
import { Component, OnInit,ViewChild,ElementRef} from '@angular/core';
import { Observable } from "rxjs";
import { Router } from '@angular/router';
import{AppointmentService} from '../appointment.service';
import {NgForm,FormGroup} from '@angular/forms';


@Component({
  selector: 'app-check-history',
  templateUrl: './check-history.component.html',
  styleUrls: ['./check-history.component.css']
})
export class CheckHistoryComponent implements OnInit {
  appointments: Observable<Appointment[]>;
   appointment:Appointment;
   
   constructor(private appointmentService: AppointmentService,
    private router: Router) { }

  ngOnInit() {
      this.reloadData();
  }
  reloadData() {
    this.appointmentService.getAppointmentByDoctorId(Number(sessionStorage.getItem('id'))).subscribe(data=>{this.appointments=data,console.log(data)});
    
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

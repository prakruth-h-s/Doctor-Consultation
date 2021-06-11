import { Component, OnInit } from '@angular/core';
import { Appointment } from '../appointment';
import {AppointmentService} from '../appointment.service';
import { Doctor } from '../doctor';
import {DoctorService} from '../doctor.service';
import {Observable} from 'rxjs';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-patient-report',
  templateUrl: './patient-report.component.html',
  styleUrls: ['./patient-report.component.css']
})
export class PatientReportComponent implements OnInit {

  $appointments1:Observable<Appointment[]>;
  appointments1:any;
  doctor:Doctor;
  Status:string;
  form:any;
  temp:any;
  
  constructor(private _appointmentservice:AppointmentService,private _doctor:DoctorService,private router: Router) {
    //Number(sessionStorage.getItem('id'));
    this._appointmentservice.getPrescription(Number(sessionStorage.getItem('id'))).subscribe(data=>{this.$appointments1=data,
      console.log(data)
      this.temp="Pending";
    });
   }

  ngOnInit(): void {
    console.log(this.$appointments1);
    this.form = new FormGroup({
      Status: new FormControl('Pending')
    });
    
  }
  onSelect(did:any){

  }
  onsubmit(form1:any){
    this.Status=this.form.value;
    this.temp=form1.Status;
  }
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }
}

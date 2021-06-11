import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { Patient } from '../patient';
import {PatientService} from '../patient.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-create-patient',
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.css']
})
export class CreatePatientComponent implements OnInit {

  patient: Patient = new Patient();
  submitted = false;
 
  constructor(private patientService: PatientService,
    private router: Router, private toastr:ToastrService) { }
 
  ngOnInit() {
  }
 
  newPatient(): void {
    this.submitted = false;
    this.patient = new Patient();
  }
 
  save() {
    this.patientService
    .createPatient(this.patient).subscribe(data => {
      console.log(data)
      this.patient = new Patient();
      this.gotoList();
    }, 
    error => console.log(error));
  }
 
  onSubmit() {
    this.submitted = true;
    this.save();  
    this.toastr.success('Submitted Successfully', 'Patient Registered');  
  }
 
  gotoList() {
    this.router.navigate(['/login']);
 
  } 
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }
}
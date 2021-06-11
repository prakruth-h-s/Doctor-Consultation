import { DoctorService } from '../doctor.service';
import { Doctor } from '../doctor';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-doctor',
  templateUrl: './create-doctor.component.html',
  styleUrls: ['./create-doctor.component.css']
})
export class CreateDoctorComponent implements OnInit {

  doctor: Doctor = new Doctor();
  submitted = false;

  constructor(private doctorService: DoctorService,
    private router: Router,
    private toastr:ToastrService) { }

  ngOnInit() {
  }

  newPatient(): void {
    this.submitted = false;
    this.doctor = new Doctor();
  }

  save() {
    this.doctorService
    .createDoctor(this.doctor).subscribe(data => {
      console.log(data)
      this.doctor = new Doctor();
      this.gotoList();
    }, 
    error => console.log(error));
  }

  onSubmit() {
    this.submitted = true;
    this.save();   
    this.toastr.success('Submitted Successfully', 'Doctor Registered'); 
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

import { DoctorService } from '../doctor.service';
import { Doctor } from '../doctor';
import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {FormGroup,FormControl, Validators} from '@angular/forms';
import {Observable,Subscription} from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { HostListener } from '@angular/core';
import { PatientService } from '../patient.service';
import { Patient } from '../patient';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router,private _doctorservice:DoctorService, private toastr:ToastrService,private _patientservice:PatientService) { 
    this.role="Patient";
  }
  doctor:Doctor;
  form:any;
  sub$:Subscription;
  email:string;
  password:string;
  public errorMsg;
  patient:Patient;
  role:any;
 
  
    ngOnInit() {
      
      this.form=new FormGroup({
        email:new FormControl("",Validators.compose([Validators.required,Validators.email])),
        password:new FormControl("",Validators.compose([Validators.required,Validators.minLength(5)])),
        Role:new FormControl("Patient")
  
      });
    
    }
   onSubmit(form1:any){
     this.errorMsg="";
     
    console.log(form1.Role);
     this.email=form1.email;
     this.password=form1.password;
     console.log(this.email);
     this.role=form1.Role;
     if(this.role=="Doctor")
     {
      this._doctorservice.getDoctoremail(this.email).subscribe(data=>{
      this.doctor=data, 
      console.log(data),
      this.toastr.success('LoggedIn Successfully', 'Doctor logged in')
     // this.router.navigate(['/appointments'])
      //this.gotoList();
      if(data==null){
        this.errorMsg="email wrong"
      }
      });
    }
    else{
      this._patientservice.getPatientemail(this.email).subscribe(data=>{
        this.patient=data,
        this.toastr.success('LoggedIn Successfully', 'Patient logged in')
        if(data==null){
          this.errorMsg="email wrong"
        }
      });
      
    }
     
    }
/*
     gotoList(){
      this.router.navigate(['/appointments'])
     }*/

    enroute()   {  
      if(this.role=="Doctor")
      {
      sessionStorage.setItem('id', this.doctor.doctorID.toString());
      
      sessionStorage.setItem('role', "Doctor");
      console.log(Number(sessionStorage.getItem('id')));
     // this.router.navigate(['/appointments']);
     this.router.navigate(['/home']);
    }
    else{
      sessionStorage.setItem('id', this.patient.patientID.toString());
    
      sessionStorage.setItem('role', "Patient");
       // this.router.navigate(['/specialization']);
      this.router.navigate(['/home']);
    }
    }
    
  
 }
   
    



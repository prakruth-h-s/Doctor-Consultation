import { Component, OnInit } from '@angular/core';
import {PatientService} from '../patient.service';
import {Doctor} from '../doctor';
import {Observable} from 'rxjs';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-view-doctors',
  templateUrl: './view-doctors.component.html',
  styleUrls: ['./view-doctors.component.css']
})
export class ViewDoctorsComponent implements OnInit {

  doctors:Observable<Doctor[]>;
  public specialization:string;
  constructor(private _patientsevice:PatientService, private route: ActivatedRoute, private router:Router) { 
    this.specialization=this.route.snapshot.paramMap.get('specialization');
    console.log(this.specialization);
    this._patientsevice.getSpecializeDoctor(this.specialization).subscribe(data=>this.doctors=data); 
  }

  ngOnInit(){
    
     
  }
  onSelectDoctor(id:number){
    this.router.navigate(['/bookappointment/'+id]);
  }
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }

}

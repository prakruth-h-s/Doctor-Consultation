import { Component, OnInit } from '@angular/core';
import{AppointmentService} from '../appointment.service'
import{Appointment} from '../appointment';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-appointment-update',
  templateUrl: './appointment-update.component.html',
  styleUrls: ['./appointment-update.component.css']
})
export class AppointmentUpdateComponent implements OnInit {
  id:number;
  submitted=false;
  appointment:Appointment;

  constructor(private route: ActivatedRoute,private router: Router,
    private appointmentService:AppointmentService
    ) { }

  ngOnInit(){
    this.appointment=new Appointment();
   this.id=this.route.snapshot.params['id'];
   

   this.appointmentService.getAppointment(this.id)
   .subscribe(data=>{
     console.log(data),
     this.appointment=data
   },error=>console.log(error));
  }
  updateAppointment() {
    this.appointmentService.updateAppointment(this.id, this.appointment)
      .subscribe(data => {
        console.log(data);
        this.appointment = new Appointment();
        
       this.appointment.status="Accepted";
        //this.gotoConsulationForm();
      }, error => console.log(error));
  }


  updatePrescription() {
    this.appointmentService.updateAppointment(this.id, this.appointment)
      .subscribe(data => {
        console.log(data);
        this.appointment = new Appointment();
        //this.gotoList();
      }, error => console.log(error));
  }
  onClick(){
    this.updateAppointment();
  }
  onSubmit() {
    this.submitted = true;
    this.updatePrescription();    
  }

  /*gotoConsulationForm() {
    this.router.navigate(['/consultation']);
  }*/
  gotoList()
  {
    this.router.navigate(['/appointments']);
  }
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }
  }
  


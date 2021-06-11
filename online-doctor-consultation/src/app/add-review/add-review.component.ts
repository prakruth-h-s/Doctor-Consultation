import { Component, OnInit } from '@angular/core';
import {FormGroup,FormControl, Validators} from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import {AppointmentService} from '../appointment.service';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  aid:any;
  form:any;
  review:string;
  constructor(private _appointmentservice:AppointmentService,private route: ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.form=new FormGroup({
      review:new FormControl("",Validators.compose([Validators.required]))
    });
  }
  onSubmit(form1:any){
    this.aid=Number(this.route.snapshot.paramMap.get('aid'));
    this._appointmentservice.addRating(this.aid,form1.review).subscribe();
    this.router.navigate(['/report']);
  }
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }

}

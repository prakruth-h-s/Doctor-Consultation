import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  arole:any;
  visibility:boolean;
  constructor(private router: Router) {
    this.arole=sessionStorage.getItem('role');
    if(this.arole=="Patient")
    {
        this.visibility=true;
    }
    else{
      this.visibility=false;
    }
   }

  ngOnInit(): void {
  }
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }

}

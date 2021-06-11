import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-specialization',
  templateUrl: './view-specialization.component.html',
  styleUrls: ['./view-specialization.component.css']
})
export class ViewSpecializationComponent implements OnInit {

  constructor(private router:Router) {this.router.navigate(['/specialization']); }

  ngOnInit(): void {
   
  }
  onSelect(spec:string){
    this.router.navigate(['/specializedoctor',spec]);
  }
  logout(){
    // window.sessionStorage.clear();
     sessionStorage.clear();
     this.router.navigate(['/login']);
    }

}

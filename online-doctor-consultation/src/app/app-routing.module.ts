import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppointmentListComponent} from './appointment-list/appointment-list.component';
import { AppointmentUpdateComponent } from './appointment-update/appointment-update.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { CheckHistoryComponent } from './check-history/check-history.component';
import { LoginComponent } from './login/login.component';
import { CreateDoctorComponent } from './create-doctor/create-doctor.component';
import { CreatePatientComponent } from './create-patient/create-patient.component';
import {BookAppointmentComponent} from './book-appointment/book-appointment.component';
import {PrescriptionComponent} from './prescription/prescription.component';
import {ViewSpecializationComponent} from '../app/view-specialization/view-specialization.component';
import {ViewDoctorsComponent} from '../app/view-doctors/view-doctors.component';
import {AddReviewComponent} from './add-review/add-review.component';
import { PatientReportComponent } from './patient-report/patient-report.component';
import {HomeComponent} from './home/home.component'

const routes: Routes = [

  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'appointments', component: AppointmentListComponent },
  { path: 'update/:id', component: AppointmentUpdateComponent },
  { path: 'details/:id', component: AppointmentDetailsComponent },
  { path: 'history', component: CheckHistoryComponent },
  {path:'login',component:LoginComponent},
  {path: 'add1', component:CreateDoctorComponent },
  {​​​​​​​​path:'add', component:CreatePatientComponent }​​​​​​​​,
  {path:'bookappointment/:did' , component:BookAppointmentComponent},
  {path:'viewprescription' , component:PrescriptionComponent},
  {path:'specialization',component:ViewSpecializationComponent},
  {path:'specializedoctor/:specialization',component:ViewDoctorsComponent},
  {path:'review/:aid' , component:AddReviewComponent},
  {path:'report' , component:PatientReportComponent},
  {path:'home',component:HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentUpdateComponent } from './appointment-update/appointment-update.component';
import { CheckHistoryComponent } from './check-history/check-history.component';
import { CreateDoctorComponent } from './create-doctor/create-doctor.component';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AddReviewComponent } from './add-review/add-review.component';
import { BookAppointmentComponent } from './book-appointment/book-appointment.component';
import { CreatePatientComponent } from './create-patient/create-patient.component';
import { PatientReportComponent } from './patient-report/patient-report.component';
import { PrescriptionComponent } from './prescription/prescription.component';
import { ViewDoctorsComponent } from './view-doctors/view-doctors.component';
import { ViewSpecializationComponent } from './view-specialization/view-specialization.component';
import { HomeComponent } from './home/home.component';
@NgModule({
  declarations: [
    AppComponent,
    AppointmentListComponent,
    AppointmentDetailsComponent,
    AppointmentUpdateComponent,
    CheckHistoryComponent,
    CreateDoctorComponent,
    LoginComponent,
    AddReviewComponent,
    BookAppointmentComponent,
    CreatePatientComponent,
    PatientReportComponent,
    PrescriptionComponent,
    ViewDoctorsComponent,
    ViewSpecializationComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

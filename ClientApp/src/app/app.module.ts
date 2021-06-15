import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { AddContactFormComponent } from './add-contact-form/add-contact-form.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastContainerComponent } from './toast-container/toast-container.component';
import { EditContactFormComponent } from './edit-contact-form/edit-contact-form.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';


@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    AddContactFormComponent,
    ToastContainerComponent,
    EditContactFormComponent,
    ContactDetailsComponent,
    
  ],
  imports: [
    
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ContactListComponent },
      { path: 'add-contact', component: AddContactFormComponent },
      { path: ':id', component: ContactDetailsComponent },
      { path: 'edit-contact/:id', component: EditContactFormComponent },]),
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

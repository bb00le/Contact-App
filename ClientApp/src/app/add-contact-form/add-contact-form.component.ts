import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ContactListService } from '../shared/contact-list.service';
import { Router } from '@angular/router';
import { ToastService } from '../shared/toast.service';

@Component({
  selector: 'app-edit-contact-form',
  templateUrl: './add-contact-form.component.html',
  
})
export class AddContactFormComponent implements OnInit {

  contactFormGroup: FormGroup;
  contactEmails: FormArray;
  contactPhones: FormArray;
  contactTags: FormArray;

  constructor(public service: ContactListService, private fb: FormBuilder, private router: Router, private toast: ToastService) {
    this.contactFormGroup = this.fb.group({
      contactId: 0,
      contactFirstName: '',
      contactLastName: '',
      contactAdress: '',
      contactWorkInfo: '',
      contactDateOfBirth: '',
      contactEmails: this.fb.array([this.createEmails()]),
      contactPhones: this.fb.array([this.createPhones()]),
      contactTags: this.fb.array([this.createTags()]),
    });
  }

  ngOnInit() {
    
  }

  createEmails(): FormGroup {
    return this.fb.group({ emailId: 0, email: "", contactId: 0 });
  }
  createPhones(): FormGroup {
    return this.fb.group({ phoneId: 0, phone: "", contactId: 0 });
  }
  createTags(): FormGroup {
    return this.fb.group({ tagId: 0, tag: "", contactId: 0 });
  }

  addEmails() {
    this.contactEmails = this.contactFormGroup.get('contactEmails') as FormArray;
    this.contactEmails.push(this.createEmails());
  }
  addPhones() {
    this.contactPhones = this.contactFormGroup.get('contactPhones') as FormArray;
    this.contactPhones.push(this.createPhones());
    
  }
  addTags() {
    this.contactTags = this.contactFormGroup.get('contactTags') as FormArray;
    this.contactTags.push(this.createTags());
  }

  removePhone(index: number) {
    this.contactPhones = this.contactFormGroup.get('contactPhones') as FormArray;

    const id: number = this.contactPhones.at(index).get('phoneId').value as number;

    if (id == 0) {
      this.contactPhones.removeAt(index);
    }
    else {
      this.service.deletePhone(id).subscribe(
        res => {
          this.contactPhones.removeAt(index);
          this.toast.show('Phone number removed', { classname: 'bg-success text-light' });
        },
        err => {
          console.log(err);
          this.toast.show('Error attempting to delete phone number', { classname: 'bg-warning text-light' });
        }
      );
    }

    

  }

  removeEmail(index: number) {
    this.contactEmails = this.contactFormGroup.get('contactEmails') as FormArray;

    const id: number = this.contactEmails.at(index).get('emailId').value as number;

    if (id == 0) {
      this.contactEmails.removeAt(index);
    }
    else {
      this.service.deleteEmail(id).subscribe(
        res => {
          this.contactEmails.removeAt(index);
          this.toast.show('Email removed', { classname: 'bg-success text-light' });
        },
        err => {
          console.log(err);
          this.toast.show('Error attempting to delete email', { classname: 'bg-warning text-light' });
        }
      );
    }

   
  }

  removeTag(index: number) {
    this.contactTags = this.contactFormGroup.get('contactTags') as FormArray;

    const id: number = this.contactTags.at(index).get('tagId').value as number;

    if (id == 0) {
      this.contactTags.removeAt(index);
    }
    else {
      this.service.deleteTag(id).subscribe(
        res => {
          this.contactTags.removeAt(index);
          this.toast.show('Tag removed', { classname: 'bg-success text-light' });
        },
        err => {
          console.log(err);
          this.toast.show('Error attempting to delete tag', { classname: 'bg-warning text-light' });
        }
      );
    }
  }

  onSubmit(form: NgForm) {
     this.service.postContactCreate(form.value).subscribe(
       res => {
         this.toast.show('Contact added', { classname: 'bg-success text-light' });
         this.router.navigate([''])
      },
      err => {
        console.log(err);
        this.toast.show('Error attempting to add contact', { classname: 'bg-warning text-light' });
      }
    );
  }

}

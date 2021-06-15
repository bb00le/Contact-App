import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactList } from '../shared/contact-list.model';
import { ContactListService } from '../shared/contact-list.service';
import { ToastService } from '../shared/toast.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
})
export class ContactDetailsComponent implements OnInit {

  contact: ContactList;
  contactFormGroup: FormGroup;
  contactEmails: FormArray;
  contactPhones: FormArray;
  contactTags: FormArray;

  constructor(public service: ContactListService, private router: Router, private fb: FormBuilder, private route: ActivatedRoute, private toast: ToastService) {
    let id: number = +this.route.snapshot.paramMap.get('id');
    this.getEditContact(id);
    this.initFormGroup(this.contactFormGroup);
  }

  ngOnInit() {
  }

  assignFormGroup() {
    this.contactFormGroup.patchValue({
      contactId: this.contact.contactId,
      contactFirstName: this.contact.contactFirstName,
      contactLastName: this.contact.contactLastName,
      contactAdress: this.contact.contactAdress,
      contactWorkInfo: this.contact.contactWorkInfo,
      contactDateOfBirth: this.contact.contactDateOfBirth,
    });
    this.contactEmails = this.contactFormGroup.get('contactEmails') as FormArray;
    this.contact.contactEmails.forEach(email => this.contactEmails.push(this.fb.group(email)));

    this.contactPhones = this.contactFormGroup.get('contactPhones') as FormArray;
    this.contact.contactPhones.forEach(phone => this.contactPhones.push(this.fb.group(phone)));

    this.contactTags = this.contactFormGroup.get('contactTags') as FormArray;
    this.contact.contactTags.forEach(tag => this.contactTags.push(this.fb.group(tag)));
  }

  initFormGroup(contactFormGroup: any) {
    this.contactFormGroup = this.fb.group({
      contactId: 0,
      contactFirstName: '',
      contactLastName: '',
      contactAdress: '',
      contactWorkInfo: '',
      contactDateOfBirth: '',
      contactEmails: this.fb.array([]),
      contactPhones: this.fb.array([]),
      contactTags: this.fb.array([]),
    });
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

  
  getEditContact(id: number) {

    this.service.getContact(id).subscribe(
      res => {
        this.contact = res;
        this.assignFormGroup();
      },
      err => {
        console.log(err);
        this.toast.show('Error attempting to get contact details', { classname: 'bg-warning text-light' });
      }
    );

  }
}

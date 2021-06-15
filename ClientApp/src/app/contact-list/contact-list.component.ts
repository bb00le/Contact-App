import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { ContactList } from '../shared/contact-list.model';
import { ContactListService } from '../shared/contact-list.service';
import { ToastService } from '../shared/toast.service';


@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
})
export class ContactListComponent implements OnInit {

  contactList: ContactList[];
  searchOption: string;
  searchText: string;
  constructor(public service: ContactListService, private router: Router, private toast:ToastService) {}



  ngOnInit() {
    this.getContactList();
  }

  searchContacts() {
    this.service.searchContacts(this.searchOption, this.searchText).subscribe(
      res => {
        this.contactList = res;
      },
      err => {
        console.log(err);
        this.toast.show('Error attempting to get contacts', { classname: 'bg-warning text-light' });
      }
    )
  }

  getContactList() {

    this.service.getContacts().subscribe(
      res => {
        this.contactList = res;
      },
      err => {
        console.log(err);
        this.toast.show('Error attempting to get contacts', { classname: 'bg-warning text-light' });
      }
    );

  }

  deleteContact(id: number) {
    this.service.deleteContact(id).subscribe(
      res => {
        this.toast.show('Contact Deleted', { classname: 'bg-success text-light' });
        this.getContactList();
      },
      err => {
        console.log(err);
        this.toast.show('Error attempting to delete contact', { classname: 'bg-warning text-light' });
      }
    );
  }
  
  
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ContactList } from './contact-list.model';


@Injectable({
  providedIn: 'root'
})
export class ContactListService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44310/api/ContactInfo'

  searchContacts(option:string,query:string) {
    return this.http.get<any>("https://localhost:44310/api/search?searchType=" + option + "&searchString=" + query);
  }

  getContacts() {
    return this.http.get<any>(this.baseURL);
  }

  getContact(id: number) {
    return this.http.get<any>(this.baseURL + "/" + id);
  }

  postContactCreate(formData: ContactList) {
    return this.http.post(this.baseURL,formData);
  }

  putContactUpdate(formData: ContactList) {
    return this.http.put(this.baseURL + "/" + formData.contactId, formData);
  }

  deleteContact(id: number) {
    return this.http.delete(this.baseURL + "/" + id);
  }

  deletePhone(id: number) {
    return this.http.delete("https://localhost:44310/api/ContactPhones/"+id)
  }

  deleteEmail(id: number) {
    return this.http.delete("https://localhost:44310/api/ContactEmails/" + id)
  }

  deleteTag(id: number) {
    return this.http.delete("https://localhost:44310/api/ContactTags/" + id)
  }

}

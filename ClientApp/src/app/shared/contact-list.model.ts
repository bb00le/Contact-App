export class ContactList {

  public constructor() {}


  contactId: number=0;
  contactFirstName: string='';
  contactLastName: string='';
  contactAdress: string='';
  contactWorkInfo: string='';
  contactDateOfBirth: string='';
  contactEmails: any[] = [{ "emailId": 0, "email": "", "contactId": 0}];
  contactPhones: any[] = [{ "phoneId": 0, "phone": "", "contactId": 0 }];
  contactTags: any[] = [{ "tagId": 0, "tag": "", "contactId": 0 }];
}

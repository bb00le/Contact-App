"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ContactList = void 0;
var ContactList = /** @class */ (function () {
    function ContactList() {
        this.contactId = 0;
        this.contactFirstName = '';
        this.contactLastName = '';
        this.contactAdress = '';
        this.contactWorkInfo = '';
        this.contactDateOfBirth = '';
        this.contactEmails = [{ "emailId": 0, "email": "", "contactId": 0 }];
        this.contactPhones = [{ "phoneId": 0, "phone": "", "contactId": 0 }];
        this.contactTags = [{ "tagId": 0, "tag": "", "contactId": 0 }];
    }
    return ContactList;
}());
exports.ContactList = ContactList;
//# sourceMappingURL=contact-list.model.js.map
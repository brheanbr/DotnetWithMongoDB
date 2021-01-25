import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})

export class ContactService {
  contact: any[];
  constructor(private http: HttpClient) { }

  getContacts() {
    return this.http.get('Contacts/GetContacts',
      { headers: { 'Content-Type': 'application/json' } });
  }

  addContact(contact) {
    return this.http.post('Contacts/AddContact', JSON.stringify(contact),
      { headers: { 'Content-Type': 'application/json' } });
  }
}

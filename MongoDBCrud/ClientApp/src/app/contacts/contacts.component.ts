import { Component, OnInit } from '@angular/core';
import { ContactService } from '../add-contact/ContactService';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styles: []
})
export class ContactsComponent implements OnInit {
  contact: any[];

  constructor(public contactService: ContactService) { }

  ngOnInit() {
    this.contactService.getContacts().subscribe((res: any) => {
      this.contactService.contact = res;
    }
    );
  }

}

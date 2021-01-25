import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ContactService } from './ContactService';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styles: []
})
export class AddContactComponent implements OnInit {
  contactForm: FormGroup;
  constructor(public fb: FormBuilder, public contactService: ContactService) { }

  ngOnInit() {
    this.createAccountForm();
  }

  createAccountForm() {
    this.contactForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      contactNumber: ['', Validators.required],
      address: ['', Validators.required]
    })
  }


  submit() {
    var data = Object.assign({}, this.contactForm.value);
    this.contactService.addContact(data).subscribe( (res:any) => this.contactService.contact.push(res));
  }
}

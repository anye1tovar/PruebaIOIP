import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, Validators, FormGroup } from '@angular/forms';
import { PersonService } from '../shared/person.service';

@Component({
  selector: 'app-person-table',
  templateUrl: './person-table.component.html',
  styles: []
})
export class PersonTableComponent implements OnInit {

  personForms: FormArray = this.fb.array([]);
  personList = [];
  notification = null;

  constructor(private fb: FormBuilder, private personService: PersonService) { }

  ngOnInit() {
    this.personService.getPersonList().subscribe(
      res => {
        if (res === []) {
          this.addPersonForm();
        } else {
          (res as []).forEach((person: any) => {
            this.personForms.push(this.fb.group({
              personID: [person.personID],
              name: [person.name, Validators.required],
              lastname: [person.lastname, Validators.required],
              address: [person.address, Validators.required],
              phone: [person.phone, Validators.required]
            }));
          });
        }
      }
    );
    this.addPersonForm();
  }

  addPersonForm() {
    this.personForms.push(this.fb.group({
      personID: [0],
      name: ['', Validators.required],
      lastname: ['', Validators.required],
      address: ['', Validators.required],
      phone: ['', Validators.required]
    }));
  }

  recordSubmit(fg: FormGroup) {
    if (fg.value.personID === 0) {
    this.personService.postPerson(fg.value)
      .subscribe(
        (res: any) => {
          fg.patchValue({ personID: res.personID });
          this.showNotification('insert');
        });
    } else {
      this.personService.putPerson(fg.value).subscribe(
        (res: any) => {
          this.showNotification('update');
        });
    }
  }
  onDelete(personID, i) {
    if (personID === 0) {
      this.personForms.removeAt(i);
    } else if (confirm('¿Está seguro de querer eliminar este registro?')) {
      this.personService.deletePerson(personID).subscribe(
        res => {
          this.personForms.removeAt(i);
          this.showNotification('delete');
        });
 }
  }

  showNotification(category) {
    switch (category) {
      case 'insert':
        this.notification = { class: 'text-success', message: 'Guardado!' };
        break;
      case 'update':
        this.notification = { class: 'text-primary', message: 'Actualizado!' };
        break;
      case 'delete':
        this.notification = { class: 'text-danger', message: 'Eliminado!' };
        break;

      default:
        break;
    }
    setTimeout(() => {
      this.notification = null;
    }, 3000);

}
}

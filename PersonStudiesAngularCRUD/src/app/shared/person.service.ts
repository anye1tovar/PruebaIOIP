import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient) { }

  getPersonList() {
    return this.http.get(environment.apiBaseURI + '/Person');
  }
  postPerson(formData) {
    return this.http.get(environment.apiBaseURI + '/Person/', formData);
  }
  putPerson(formData){
    return this.http.get(environment.apiBaseURI + '/Person/' + formData.personID, formData);
  }
  deletePerson(id){
    return this.http.get(environment.apiBaseURI + '/Person/' + id);
  }
}

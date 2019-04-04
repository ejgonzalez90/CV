import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public personBasicData: PersonBasicData[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    let personId = 4;
    http.get<PersonBasicData[]>('https://localhost:6004/' + 'api/People/GetPersonBasicData?personId=' + personId).subscribe(result => {
      this.personBasicData = result;
    }, error => console.error(error));
  }
}

interface PersonBasicData {
  firstName: string;
  middleName: string;
  lastName: string;
  fullName: string;
  brithDate: Date;
  civilStatus: Int16Array;
  civilStatusDescription: string;
  description: string;
  webSite: string;
  emailAddress: string;
  profilePicture: string;
}

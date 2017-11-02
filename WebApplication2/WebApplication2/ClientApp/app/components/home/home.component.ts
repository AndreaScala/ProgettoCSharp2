// Imports
import { Injectable, Component }     from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import {Observable} from 'rxjs/Rx';

// Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { NgForm } from "@angular/forms/src/forms";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

@Injectable()
export class HomeComponent {

     constructor (private http: Http) {}
     private url = 'http://localhost:5000/api/users';

     insertUser(values: NgForm): Observable<User[]> {
         console.log("cane" + JSON.stringify(values.value));

        // var u = new User("", "", 55);
         //let bodyString = JSON.stringify(u);
        
       


         let headers = new Headers({ 'Content-Type': 'application/json' });
         let options = new RequestOptions({ headers: headers });
     this.http.put(this.url, JSON.stringify(values.value), options).map((res: Response) => res.json());
         return this.http.put(this.url, JSON.stringify(values.value), options).map((res: Response) => res.json());

     }

}

export class User {
    constructor(
        public name: string,
        public surname: string,
        public age: number
    ) { }
}
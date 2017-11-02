import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'concerts',
    templateUrl: './concerts.component.html'
})
export class ConcertsComponent {
    public concerts: Concert[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get('http://localhost:5000/api/concerts').subscribe(result => {
            this.concerts = result.json() as Concert[];
        }, error => console.error(error));
    }
}

interface Concert {
    name: string;
    place: string;
    date: string;
}

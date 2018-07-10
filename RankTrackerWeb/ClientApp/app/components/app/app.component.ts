import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    //public ranknumbers: RankNumber;
    private apiUrl = 'http://localhost:20511/api/RankTracker?keyWords=';
    public showLoading: boolean = false;
   
    constructor(private http: Http) {
           
    }
    getRankNumber() {           
        this.ShowLoader();
             this.http.get(this.apiUrl + this.keywords + '&url=' + this.urlToBeSearched).subscribe(result => {
                this.results=  result.json();
        }, error => console.error(error));   
        this.HideLoader();
    }

    ShowLoader() {
        this.showLoading = true;
    }
    HideLoader() {
        this.showLoading = false;
    }

    keywords: string = '';
    urlToBeSearched: string = '';
    results: string = '';
}





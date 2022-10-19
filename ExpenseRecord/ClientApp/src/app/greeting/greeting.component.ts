import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-greeting',
  templateUrl: './greeting.component.html',
  styleUrls: ['./greeting.component.css']
})
export class GreetingComponent implements OnInit {
  name!: string;
  greeting!: string;

  private baseUrl: string;
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
  }

  greet() {
    this.callApi(this.name);
  }

  callApi(name: string) {
    this.http.get<string>(this.baseUrl + 'api/items?name=' + name, {responseType: 'text' as 'json'})
      .subscribe((result: string) => {
        this.greeting = result;
      }, (error: any) => console.error(error));
    //this.http.get<string>(this.baseUrl + 'greeting?name=' + name, { responseType: 'text' as 'json' })
    //  .subscribe((result: string) => {
    //    this.greeting = result;
    //  }, (error: any) => console.error(error));
  }
}

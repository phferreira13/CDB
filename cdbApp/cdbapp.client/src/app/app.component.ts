import { HttpClient, HttpParams } from '@angular/common/http';
import { Component } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent{
  initialValue: number = 0;
  months: number = 0;
  result: any;

  constructor(private http: HttpClient) { }

  calculate() {
    const params = new HttpParams()
      .set('initialValue', this.initialValue.toString())
      .set('months', this.months.toString());

    this.http.get('/api/cdb', { params }).subscribe({
      next: (data: any) => {
        this.result = data;
      },
      error: (error: any) => {
        console.error('Error:', error);
      }
    });
  }

  title = 'cdbapp.client';
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { CdbResult } from '../models/cdbResult.model';
import { MatTable } from '@angular/material/table';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent{
  results: CdbResult[] = [];
  displayedColumns: string[] = ['initialValue', 'months', 'finalValue', 'finalValueWithTax'];

  valueControl: FormControl = new FormControl(1, [Validators.min(1), Validators.required])
  monthControl: FormControl = new FormControl(1, [Validators.min(1), Validators.required])

  cdbForm: FormGroup = new FormGroup({
    initialValue: this.valueControl,
    months: this.monthControl
  })

  @ViewChild(MatTable)
    table!: MatTable<CdbResult>;

  constructor(private http: HttpClient) { }

  calculate() {
    const initialValue = this.valueControl.value;
    const months = this.monthControl.value;

    const params = new HttpParams()
      .set('initialValue', initialValue.toString())
      .set('months', months.toString());

    this.http.get<CdbResult>('/api/cdb', { params }).subscribe({
      next: (data: CdbResult) => {
        this.results.push(data);
        this.table.renderRows();
      },
      error: (error: any) => {
        console.error('Error:', error);
      }
    });
  }

  title = 'Calculador de CDB';
}

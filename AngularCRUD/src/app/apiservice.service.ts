import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  readonly apiUrl = '<your api url>';

  constructor(private http: HttpClient) { }

  // GeneralCost
  getGeneralCostList(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'generalCost/GetGeneralCost');
  }

  addGeneralCost(dept: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.apiUrl + 'generalCost/AddGeneralCost', dept, httpOptions);
  }

  updateGeneralCost(dept: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.apiUrl + 'generalCost/UpdateGeneralCost/', dept, httpOptions);
  }

  deleteGeneralCost(deptId: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + 'generalCost/DeleteGeneralCost/' + deptId, httpOptions);
  }
}
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private apiUrl = 'https://localhost:7183/api/accounts'; 

  constructor(private http: HttpClient) {}


  getTransactions(accountId: string, startDate: string, endDate: string): Observable<any> {
    let params = new HttpParams();
    if (startDate) params = params.set('startDate', startDate.replace(/-/g, '/'));
    if (endDate) params = params.set('endDate', endDate.replace(/-/g, '/'));

    return this.http.get(`${this.apiUrl}/${accountId}/Statements`, { params });
  }

  
  exportTransactions(accountId: string, startDate: string, endDate: string): Observable<Blob> {
    let params = new HttpParams();
    if (startDate) params = params.set('startDate', startDate.replace(/-/g, '/'));
    if (endDate) params = params.set('endDate', endDate.replace(/-/g, '/'));

    return this.http.get(`${this.apiUrl}/${accountId}/Statements/export`, {
      params,
      responseType: 'blob' 
    });
  }
}

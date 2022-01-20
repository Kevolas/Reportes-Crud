import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReporteService {
  private myAppUrl = 'http://kevin13-001-site1.dtempurl.com/';
   private myApiUrl = 'api/Reporte2/'

  constructor(private http: HttpClient) { }

  getListReportes(): Observable<any> {
    return this.http.get<any>(this.myAppUrl + this.myApiUrl);
  }

  deleteReporte(id: number): Observable<any> {
    return this.http.delete(this.myAppUrl + this.myApiUrl + id)
  }

  saveReporte(reporte: any): Observable<any> {
    return this.http.post(this.myAppUrl + this.myApiUrl, reporte);
  }

  updateReporte(id: number, reporte: any): Observable<any> {
    return this.http.put(this.myAppUrl + this.myApiUrl + id, reporte);
  }
}

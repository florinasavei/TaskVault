import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  constructor(private http: HttpClient) { }

  private apiUrl = 'http://localhost:8080/api/Items';

  create(data: any) {
    return this.http.post(this.apiUrl, data);
  }

  list() {
    return this.http.get(this.apiUrl);
  }
}

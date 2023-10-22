import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  private apiUrl = 'http://localhost:8080/api/auths';

  login(data: any) {
    return this.http.post(this.apiUrl, data);
  }
}

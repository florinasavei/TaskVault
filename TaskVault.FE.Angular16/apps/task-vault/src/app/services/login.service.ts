import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'http://localhost:8080/api/auths';

  // Create a Subject of type boolean to notify subscribers when the list changes (true for success, false for failure)
  private isLoggedIn = new Subject<boolean>();

  constructor(private http: HttpClient) {}

  // This method will allow components to subscribe to list update results
  onLogin(): Observable<boolean> {
    return this.isLoggedIn.asObservable();
  }

  login(data: any) {
    this.isLoggedIn.next(true);
    return this.http.post(this.apiUrl, data);
  }

  logout() {
    this.isLoggedIn.next(false);
  }
}

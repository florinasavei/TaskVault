import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ItemsService {
  constructor(private http: HttpClient) {}

  private apiUrl = 'http://localhost:8080/api/Items';

  private listInit = new Subject<void>();
  private listUpdated = new Subject<void>();

  onListInit() {
    return this.listInit.asObservable();
  }
  onListUpdated() {
    return this.listUpdated.asObservable();
  }

  create(data: any) {
    this.listInit.next();
    return this.http.post(this.apiUrl, data).subscribe(() => {
      // After successfully adding a new item, notify subscribers
      this.listUpdated.next();
    });
  }

  delete(id: number) {
    this.listInit.next();
    return this.http.delete(`${this.apiUrl}/${id}`).subscribe(() => {
      // After successfully adding a new item, notify subscribers
      this.listUpdated.next();
    });
  }

  count() {
    return this.http.get(`${this.apiUrl}/count`);
  }

  list(index: number, pageSize: number) {
    return this.http.get(`${this.apiUrl}?$skip=${index}&$top=${pageSize}`);
  }

  summary(id:number) {
    return this.http.get(this.apiUrl + "/" + id + "/details");
  }
}

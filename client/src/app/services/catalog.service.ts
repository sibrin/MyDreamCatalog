import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Catalog } from './models/Catalog';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CatalogService {

  private API: string;

  constructor(private http: HttpClient) {
    this.API = environment.ApiUrl;
  }

  getRoot(): Observable<Catalog[]> {
    return this.http.get<Catalog[]>(`${this.API}/catalogs`);
  }

  getChild(id: number): Observable<Catalog[]> {
    return this.http.get<Catalog[]>(`${this.API}/catalogs/${id}`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CocktailDetail, CocktailSummary, SaveCocktailRequest } from './models';

@Injectable({ providedIn: 'root' })
export class CocktailService {
  constructor(private http: HttpClient) {}

  search(term: string = '', category: string = '') {
    let params = new HttpParams();
    if (term) params = params.set('search', term);
    if (category) params = params.set('category', category);
    return this.http.get<CocktailSummary[]>('/api/cocktails', { params });
  }

  getById(id: number) {
    return this.http.get<CocktailDetail>(`/api/cocktails/${id}`);
  }

  create(request: SaveCocktailRequest) {
    return this.http.post<number>('/api/cocktails', request);
  }

  update(id: number, request: SaveCocktailRequest) {
    return this.http.put(`/api/cocktails/${id}`, request);
  }

  delete(id: number) {
    return this.http.delete(`/api/cocktails/${id}`);
  }
}

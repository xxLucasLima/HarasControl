import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AnimalDto } from './models/animal-dto'; // importa do caminho certo


@Injectable({
  providedIn: 'root'
})
export class AnimalService {
  private readonly apiUrl = '/api/animals';

  constructor(private http: HttpClient) {}

  getAll(): Observable<AnimalDto[]> {
    return this.http.get<AnimalDto[]>(this.apiUrl);
  }

  getById(id: string): Observable<AnimalDto> {
    return this.http.get<AnimalDto>(`${this.apiUrl}/${id}`);
  }

  create(data: Partial<AnimalDto>): Observable<AnimalDto> {
    return this.http.post<AnimalDto>(this.apiUrl, data);
  }

  update(id: string, data: Partial<AnimalDto>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

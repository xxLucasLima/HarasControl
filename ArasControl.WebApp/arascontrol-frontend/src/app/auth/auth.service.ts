import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://seu-backend/api/auth'; // Ajusta pra URL do teu back

  constructor(private http: HttpClient) {}

  login(credentials: { email: string; password: string }): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, credentials).pipe(
      tap((res: any) => {
        localStorage.setItem('token', res.token); // Salva o token
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
  }

  // Outras funções: verificar login, pegar user, etc.
}

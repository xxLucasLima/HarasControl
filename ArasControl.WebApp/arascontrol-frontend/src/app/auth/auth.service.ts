import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://localhost:7004/api/auth';

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

  getUserRole(): string {
    const token = localStorage.getItem('token');
    if (!token) return '';

    // Decode a segunda parte do JWT (payload)
    const payload = token.split('.')[1];
    if (!payload) return '';

    try {
      const decoded = JSON.parse(atob(payload));
      return decoded.role
        || decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
        || '';
    } catch {
      return '';
    }
  }
}


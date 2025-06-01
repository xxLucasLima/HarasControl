import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://localhost:7004/api/auth';
  private tokenKey = 'jwt_token'; 

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
  getDecodedToken(): any {
    const token = localStorage.getItem('token');
    if (!token) return null;

    const payload = token.split('.')[1];
    if (!payload) return null;

    try {
      return JSON.parse(atob(payload));
    } catch {
      return null;
    }
  }

  getOwnerId(): string | null {
    const decoded = this.getDecodedToken();
    console.log(decoded);
    return decoded.OwnerId || null ;
  }

  getHarasId(): string | null {
    const decoded = this.getDecodedToken();
    return decoded ? decoded.HarasId || null : null;
  }
}


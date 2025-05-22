import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const token = localStorage.getItem('token');
  // Se tiver token, libera acesso à rota
  if (token) return true;

  // Senão, manda pro login (ou usa Router se preferir)
  window.location.href = '/login';
  return false;
};
import { Component } from '@angular/core';
import { SideMenuComponent } from '../shared/side-menu/side-menu.component';
import { RouterOutlet, Router } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  standalone: true,
  imports: [
    SideMenuComponent,
    RouterOutlet,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule
  ],
})
export class DashboardComponent {
  drawerOpened = true;

  constructor(private authService: AuthService, private router: Router) { }

  toggleDrawer() {
    this.drawerOpened = !this.drawerOpened;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}

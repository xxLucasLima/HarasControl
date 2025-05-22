import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatNavList, MatListItem } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../auth/auth.service';
import { MatExpansionModule } from '@angular/material/expansion';

interface MenuOption {
  label: string;
  icon: string;
  route?: string;        // Usado para links simples
  roles: string[];       // Roles que podem ver
  children?: MenuOption[]; // Para submenus
}

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    MatNavList,
    MatListItem,
    MatIconModule,
    RouterModule,
    MatExpansionModule
  ]
})
export class SideMenuComponent {
  userRole: string;
  dropdownOpenLabel: string | null = null;

  menuOptions: MenuOption[] = [
    {
      label: 'Haras Owner',
      icon: 'person',
      route: '/haras-owner',
      roles: ['HarasOwner'],
    },
    {
      label: 'Animal Owners',
      icon: 'groups',
      route: '/animal-owners',
      roles: ['HarasOwner'],
    },
    {
      label: 'Animals',
      icon: 'pets',
      roles: ['HarasOwner'],
      children: [
        { label: 'Home', icon: 'dashboard', route: '/animals/home', roles: ['HarasOwner'] },
        { label: 'Vaccines', icon: 'vaccines', route: '/animals/vaccines', roles: ['HarasOwner'] },
        { label: 'Vitamins', icon: 'science', route: '/animals/vitamins', roles: ['HarasOwner'] },
        { label: 'Feed Record', icon: 'restaurant', route: '/animals/feedrecord', roles: ['HarasOwner'] },
      ],
    }
  ];

  constructor(private authService: AuthService) {
    this.userRole = this.authService.getUserRole();
  }

  get filteredOptions(): MenuOption[] {
    return this.menuOptions.filter(option => option.roles.includes(this.userRole));
  }

  toggleDropdown(option: MenuOption) {
    this.dropdownOpenLabel =
      this.dropdownOpenLabel === option.label ? null : option.label;
  }

  isDropdownOpen(option: MenuOption): boolean {
    return this.dropdownOpenLabel === option.label;
  }
}

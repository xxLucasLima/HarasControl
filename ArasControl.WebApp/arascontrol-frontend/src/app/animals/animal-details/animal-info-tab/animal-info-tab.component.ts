import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-animal-info-tab',
  imports: [],
  templateUrl: './animal-info-tab.component.html',
  styleUrl: './animal-info-tab.component.scss'
})
export class AnimalInfoTabComponent {
  @Input() animalId!: string;

}

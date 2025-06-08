import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-vitamin-doses-tab',
  imports: [],
  templateUrl: './vitamin-doses-tab.component.html',
  styleUrl: './vitamin-doses-tab.component.scss'
})
export class VitaminDosesTabComponent {
  @Input() animalId!: string;

}

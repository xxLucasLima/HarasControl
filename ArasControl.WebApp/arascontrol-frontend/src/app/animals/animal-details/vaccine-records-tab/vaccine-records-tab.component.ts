import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-vaccine-records-tab',
  imports: [],
  templateUrl: './vaccine-records-tab.component.html',
  styleUrl: './vaccine-records-tab.component.scss'
})
export class VaccineRecordsTabComponent {
  @Input() animalId!: string;

}

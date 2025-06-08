import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-feed-inventory-tab',
  imports: [],
  templateUrl: './feed-inventory-tab.component.html',
  styleUrl: './feed-inventory-tab.component.scss'
})
export class FeedInventoryTabComponent {
  @Input() animalId!: string;

}

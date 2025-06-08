import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-feed-records-tab',
  imports: [],
  templateUrl: './feed-records-tab.component.html',
  styleUrl: './feed-records-tab.component.scss'
})
export class FeedRecordsTabComponent {
  @Input() animalId!: string;

}

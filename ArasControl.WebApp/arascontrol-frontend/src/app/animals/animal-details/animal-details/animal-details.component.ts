import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatTabsModule } from '@angular/material/tabs';
import { AnimalInfoTabComponent } from '../animal-info-tab/animal-info-tab.component';
import { FeedRecordsTabComponent } from '../feed-records-tab/feed-records-tab.component';
import { VaccineRecordsTabComponent } from '../vaccine-records-tab/vaccine-records-tab.component';
import { VitaminDosesTabComponent } from '../vitamin-doses-tab/vitamin-doses-tab.component';
import { FeedInventoryTabComponent } from '../feed-inventory-tab/feed-inventory-tab.component';

@Component({
  selector: 'app-animal-details',
  templateUrl: './animal-details.component.html',
  styleUrls: ['./animal-details.component.scss'],
  standalone: true,
  imports: [
    MatTabsModule,
    AnimalInfoTabComponent,
    FeedRecordsTabComponent,
    VaccineRecordsTabComponent,
    VitaminDosesTabComponent,
    FeedInventoryTabComponent
  ]
})
export class AnimalDetailsComponent implements OnInit {
  @Input() animalId!: string;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.animalId = this.route.snapshot.paramMap.get('id')!;
  }
}

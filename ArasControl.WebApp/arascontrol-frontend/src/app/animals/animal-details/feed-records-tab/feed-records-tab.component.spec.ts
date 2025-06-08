import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedRecordsTabComponent } from './feed-records-tab.component';

describe('FeedRecordsTabComponent', () => {
  let component: FeedRecordsTabComponent;
  let fixture: ComponentFixture<FeedRecordsTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeedRecordsTabComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeedRecordsTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

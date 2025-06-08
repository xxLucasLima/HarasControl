import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedInventoryTabComponent } from './feed-inventory-tab.component';

describe('FeedInventoryTabComponent', () => {
  let component: FeedInventoryTabComponent;
  let fixture: ComponentFixture<FeedInventoryTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeedInventoryTabComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeedInventoryTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

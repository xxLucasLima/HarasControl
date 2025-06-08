import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VaccineRecordsTabComponent } from './vaccine-records-tab.component';

describe('VaccineRecordsTabComponent', () => {
  let component: VaccineRecordsTabComponent;
  let fixture: ComponentFixture<VaccineRecordsTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VaccineRecordsTabComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VaccineRecordsTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

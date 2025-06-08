import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VitaminDosesTabComponent } from './vitamin-doses-tab.component';

describe('VitaminDosesTabComponent', () => {
  let component: VitaminDosesTabComponent;
  let fixture: ComponentFixture<VitaminDosesTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VitaminDosesTabComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VitaminDosesTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

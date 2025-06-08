import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimalInfoTabComponent } from './animal-info-tab.component';

describe('AnimalInfoTabComponent', () => {
  let component: AnimalInfoTabComponent;
  let fixture: ComponentFixture<AnimalInfoTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnimalInfoTabComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnimalInfoTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ZooDetailsComponent } from './zoo-details.component';

describe('DetailsComponent', () => {
  let component: ZooDetailsComponent;
  let fixture: ComponentFixture<ZooDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ZooDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ZooDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

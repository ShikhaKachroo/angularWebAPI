import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilecreationComponent } from './profilecreation.component';

describe('ProfilecreationComponent', () => {
  let component: ProfilecreationComponent;
  let fixture: ComponentFixture<ProfilecreationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfilecreationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfilecreationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { AlertiyfService } from './alertiyf.service';

describe('AlertiyfService', () => {
  let service: AlertiyfService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlertiyfService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

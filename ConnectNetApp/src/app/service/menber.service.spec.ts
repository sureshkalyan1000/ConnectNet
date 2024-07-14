import { TestBed } from '@angular/core/testing';

import { MenberService } from './menber.service';

describe('MenberService', () => {
  let service: MenberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MenberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

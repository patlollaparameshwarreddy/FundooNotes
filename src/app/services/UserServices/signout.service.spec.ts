import { TestBed } from '@angular/core/testing';

import { SignoutService } from './signout.service';

describe('SignoutService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SignoutService = TestBed.get(SignoutService);
    expect(service).toBeTruthy();
  });
});

import { MortgageHouseService } from './mortgage-house.service';
import { TestBed } from '@angular/core/testing';

describe('MortgageHouseService', () => {
  let service: MortgageHouseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MortgageHouseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionPurchaseComponent } from './transaction-purchase.component';

describe('TransactionPurchaseComponent', () => {
  let component: TransactionPurchaseComponent;
  let fixture: ComponentFixture<TransactionPurchaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransactionPurchaseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransactionPurchaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

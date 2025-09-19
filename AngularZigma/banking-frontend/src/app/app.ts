import { Component } from '@angular/core';
import { TransactionsComponent } from './transactions/transactions';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TransactionsComponent],
  template: `
    <div class="container mt-4">
      <h1 class="mb-4">Banking Dashboard</h1>
      <app-transactions></app-transactions>
    </div>
  `
})
export class AppComponent {}

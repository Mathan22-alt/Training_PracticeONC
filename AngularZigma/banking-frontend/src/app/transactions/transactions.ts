import { Component } from '@angular/core';
import { TransactionService } from '../services/transactions';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-transactions',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './transactions.html',
  styleUrls: ['./transactions.css']
})
export class TransactionsComponent {

  transactions: any[] = [];
  bookingId: string = '';
  startDate: string = '';
  endDate: string = '';

  constructor(private transactionService: TransactionService) {}

  // Fetch transactions JSON
  fetchTransactions() {
  if (!this.bookingId || !this.startDate || !this.endDate) {
    console.warn('Please fill all fields: Booking ID, Start Date, End Date.');
    return;
  }

  this.transactionService.getTransactions(this.bookingId, this.startDate, this.endDate)
    .subscribe({
      next: (data: any) => {
        // Flatten each transaction line with account info
        this.transactions = (data.lines || []).map((line: any, index: number) => ({
          id: index + 1,                   // sequential ID
          accountId: data.accountId,
          accountName: data.accountName,
          accountNumber: data.accountNumber,
          currentBalance: data.currentBalance,
          date: line.date,
          debit: line.debit,
          credit: line.credit,
          amount: line.credit || line.debit || 0,
          type: line.type,
          description: line.description,
          balance: line.balance
        }));
      },
      error: (err) => {
        console.error('Error fetching transactions', err);
      }
    });
}



  // Download Excel using backend export endpoint
  downloadExcel() {
    if (!this.bookingId) {
      console.warn('Booking ID is required to export.');
      return;
    }

    this.transactionService.exportTransactions(this.bookingId, this.startDate, this.endDate)
      .subscribe({
        next: (blob: Blob) => {
          import("file-saver").then(fs => {
            fs.saveAs(blob, `transactions_${this.bookingId}.xlsx`);
          });
        },
        error: (err) => {
          console.error('Error exporting transactions', err);
        }
      });
  }
}

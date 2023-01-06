using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Repository
{
    public class SBTransaction
    {
        private int transactionId;
        private DateTime transactionDate;
        private int accountNumber;
        private double amount;
        private string transactionType;

        public int TransactionId { get { return transactionId; } set { transactionId = value; } }
        public DateTime TransactionDate { get { return transactionDate; } set { transactionDate = value; } }
        public int AccountNumber { get { return accountNumber; } set { accountNumber = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public string TransactionType { get { return transactionType; } set { transactionType = value; } }
    }
}

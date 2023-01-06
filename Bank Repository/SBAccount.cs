using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Repository
{
    public class SBAccount
    {
        private int accountNumber;
        private string accountName;
        private string customerAddress;
        private double currentBalance;

        public int AccountNumber { get { return accountNumber; } set { accountNumber = value; } }
        public string AccountName { get { return accountName; } set { accountName = value; } }
        public string CustomerAddress { get { return customerAddress; } set { customerAddress = value; } }
        public double CurrentBalance { get { return currentBalance; } set { currentBalance = value; } }
    }
}
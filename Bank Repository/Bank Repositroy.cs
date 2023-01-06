using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank_Repository
{
    public class BankRepository : IBankRepository
    {
        public static List<SBTransaction> _sBTransactionsList = new List<SBTransaction>();
        public static List<SBAccount> _sBAccountList = new List<SBAccount>();
        public static int i = 101;        //transaction id counter
        public static int j = 0;        //transaction index
        public static List<SBTransaction> transactions = new List<SBTransaction>();
        SBAccount sbAccount = new SBAccount();


        public void NewAccount(SBAccount acc)
        {
            //var sbAccount = new SBAccount();
            /*_sBAccountList.Add(new SBAccount
            {
                AccountNumber = acc.AccountNumber,
                AccountName = acc.AccountName,
                CustomerAddress = acc.CustomerAddress,
                CurrentBalance = acc.CurrentBalance
            });*/

            //acc = new SBAccount();
            _sBAccountList.Add(acc);
            Console.WriteLine();
            Console.WriteLine("bank account added");
            Console.WriteLine();
        }

        public List<SBAccount> GetAllAccounts()
        {
            return _sBAccountList;
        }

        public SBAccount GetAccountDetails(int accno)
        {
            /*try
            {
                if (_sBAccount == null)
                    return _sBAccount.FirstOrDefault();
                else
                    throw new ArgumentNullException(nameof(accno));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            //var index = list.FindIndex(c => c.Number == someTextBox.Text);
            //list[index] = new SomeClass(...);

            /*if (_sBAccount.Any(a => a.AccountNumber == accno) && _sBAccount != null)
            {
                var index = _sBAccount.FindIndex(c => c.AccountNumber == accno);
                //list[index] = new SomeClass(...);
                return _sBAccount[index];
                //Your logic goes here;
                //return _sBAccount.FirstOrDefault(z => z.AccountNumber == accno);
            }*/
            //Console.WriteLine(accno);

            /*if(_sBAccountList.Any(a => a.AccountNumber == accno))
            {
                var index = _sBAccountList.FindIndex(c => c.AccountNumber == accno);
                //list[index] = new SomeClass(...);
                //Console.WriteLine(index);
                
                sbAccount.AccountNumber = accno;
                sbAccount.AccountName = _sBAccountList[index].AccountName;
                sbAccount.CustomerAddress = _sBAccountList[index].CustomerAddress;
                sbAccount.CurrentBalance = _sBAccountList[index].CurrentBalance;
                return sbAccount;
                //Your logic goes here;
                //return _sBAccount.FirstOrDefault(z => z.AccountNumber == accno);
            }*/

            foreach (var account in _sBAccountList)
            {
                if (account.AccountNumber == accno)
                {
                    return account;
                }
            }

            throw new BankingException("No account with number exists");
        }

        public void DepositAmount(int accno, decimal amt)
        {

            var index = _sBAccountList.FindIndex(c => c.AccountNumber == accno);
            _sBAccountList[index].CurrentBalance += Convert.ToDouble(amt);
            //Console.WriteLine(index);

            //var sbTransaction = new SBTransaction();
            //_sBTransactionsList.Add(sbTransaction);

            _sBTransactionsList.Add(new SBTransaction
            {

                TransactionId = i,
                TransactionType = "credit",
                TransactionDate = DateTime.Now.Date,
                AccountNumber = accno,
                Amount = Convert.ToDouble(amt)
            });

            //Console.WriteLine(_sBTransactionsList[i].TransactionId);
            Console.WriteLine();
            Console.WriteLine("Amount of {0} deposited to acc no {1} with " +
                "transaction id {2}", amt, accno, _sBTransactionsList[j].TransactionId);
            Console.WriteLine();
            i++;
            j++;
        }

        public void WithdrawAmount(int accno, Decimal amt)
        {
            var index = _sBAccountList.FindIndex(c => c.AccountNumber == accno);
            if (_sBAccountList[index].CurrentBalance >= Convert.ToDouble(amt))
            {
                _sBAccountList[index].CurrentBalance -= Convert.ToDouble(amt);
                //Console.WriteLine(index);


                //var sbTransaction = new SBTransaction();

                //_sBTransactionsList.Add(sbTransaction);

                _sBTransactionsList.Add(new SBTransaction
                {

                    TransactionId = i,
                    TransactionType = "debit",
                    TransactionDate = DateTime.Now.Date,
                    AccountNumber = accno,
                    Amount = Convert.ToDouble(amt)
                });

                //Console.WriteLine(_sBTransactionsList[i].TransactionId);
                Console.WriteLine();
                Console.WriteLine("Amount of {0} is withdrawn from acc no {1} with id {2}",
                amt, accno, _sBTransactionsList[j].TransactionId);
                Console.WriteLine();
                i++;
                j++;
            }

            else
            {
                //Console.WriteLine("insufficient balance");
                throw new BankingException("Insufficient balance");
            }
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            //var index = _sBTransactionsList.FindIndex(c => c.AccountNumber == accno);
            /*
            {
                List<SBTransaction> transactions = new List<SBTransaction>();
                //var transaction = new List<SBTransaction>();
                for (int i = 0; i < _sBTransactionsList.Count; i++)
                {
                    if (_sBTransactionsList[i].AccountNumber == accno)
                    {
                        transactions = new List<SBTransaction>();
                        transactions.Add(_sBTransactionsList[i]);

                    }
                }

                return transactions;
            }

            */

            //Console.WriteLine("no of elements are {0}",_sBTransactionsList.Count);
            if (_sBAccountList.Any(a => a.AccountNumber == accno))
            {
                transactions.Clear();
                foreach (var transaction in _sBTransactionsList)
                {
                    if (transaction.AccountNumber == accno)
                    {

                        //List<SBTransaction> transactions = new List<SBTransaction>();
                        transactions.Add(transaction);
                        //return transactions;
                    }

                    /*if (transaction.AccountNumber == accno)
                    {
                        //transactions = new List<SBTransaction>();
                        transactions = new List<SBTransaction>();
                        transactions.Add(transaction);
                        return transactions;

                    }*/


                    //transactions =new List<SBTransaction> { transaction };
                    //transactions.Add(transaction);


                }
                return transactions;
            }


            throw new BankingException("No Transactions found for this account number");
        }
    }
}

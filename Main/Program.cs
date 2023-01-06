using Bank_Repository;
using System.Security.Principal;

namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                int choice;
                var sbAccount = new SBAccount();
                do
                {
                    Console.WriteLine("Available Operations");
                    Console.WriteLine("1. Open new account");
                    Console.WriteLine("2. Get Details of an account");
                    Console.WriteLine("3. Get Details of all accounts");
                    Console.WriteLine("4. Deposit Amount");
                    Console.WriteLine("5. Withdraw Amount");
                    Console.WriteLine("6. Get Transactions of an Account");
                    Console.WriteLine("7. Exit");
                    Console.WriteLine();
                    Console.WriteLine("Enter your choice:");
                    choice = int.Parse(Console.ReadLine());
                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                NewAccount(sbAccount);
                                break;

                            case 2:
                                GetAccountDetails();
                                break;

                            case 3:
                                GetAllAccounts();
                                break;

                            case 4:
                                DepositAmount();
                                break;

                            case 5:
                                WithdrawAmount();
                                break;

                            case 6:
                                GetTransactions();
                                break;

                            case 7:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                    }
                    catch (BankingException ex)
                    {
                        Console.WriteLine("Exception thrown : " + ex.Message);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message);
                    }
                } while (choice != 7);
            }

            void NewAccount(SBAccount sbAccount)
            {
                var bankRepository = new BankRepository();
                sbAccount = new SBAccount();
                Console.WriteLine("Enter account number");
                sbAccount.AccountNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter name");
                sbAccount.AccountName = Console.ReadLine();
                Console.WriteLine("Enter your address");
                sbAccount.CustomerAddress = Console.ReadLine();
                sbAccount.CurrentBalance = 0;
                bankRepository.NewAccount(sbAccount);
            }

            void GetAccountDetails()
            {
                var bankRepository = new BankRepository();
                Console.WriteLine("Enter account number");
                int accno = int.Parse(Console.ReadLine());
                var account = bankRepository.GetAccountDetails(accno);
                //Console.WriteLine(account);
                Console.WriteLine();
                Console.WriteLine("Account Name " + " " + account.AccountName);
                Console.WriteLine("Account Number " + " " + account.AccountNumber);
                Console.WriteLine("Customer Address " + " " + account.CustomerAddress);
                Console.WriteLine("Current Balance " + " " + account.CurrentBalance);
                Console.WriteLine();
            }

            void GetAllAccounts()
            {
                var bankRepository = new BankRepository();
                var bankDetails = bankRepository.GetAllAccounts();
                //int i = 0;
                foreach (var account in bankDetails)
                {
                    Console.WriteLine();
                    Console.WriteLine("Account Name " + " " + account.AccountName);
                    Console.WriteLine("Account Number " + " " + account.AccountNumber);
                    Console.WriteLine("Customer Address " + " " + account.CustomerAddress);
                    Console.WriteLine("Current Balance " + " " + account.CurrentBalance);
                    Console.WriteLine();
                }
            }

            void DepositAmount()
            {
                Console.WriteLine("Enter account number");
                var sbAccount = new SBAccount();
                var sbTransaction = new SBTransaction();

                int accno = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter amount");
                Decimal amt = Decimal.Parse(Console.ReadLine());
                BankRepository bankRepository = new BankRepository();

                bankRepository.DepositAmount(accno, amt);
            }

            void WithdrawAmount()
            {
                Console.WriteLine("Enter account number");
                var sbAccount = new SBAccount();
                var sbTransaction = new SBTransaction();

                int accno = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter amount");
                Decimal amt = Decimal.Parse(Console.ReadLine());
                BankRepository bankRepository = new BankRepository();

                bankRepository.WithdrawAmount(accno, amt);


            }
            void GetTransactions()
            {
                BankRepository bankRepository = new BankRepository();
                Console.WriteLine("Enter account number");
                int accno = int.Parse(Console.ReadLine());
                var transactions = bankRepository.GetTransactions(accno);
                foreach (var transaction in transactions)
                {
                    Console.WriteLine();
                    Console.WriteLine("Transaction Id " + " " + transaction.TransactionId);
                    Console.WriteLine("Transaction Date " + " " + transaction.TransactionDate);
                    Console.WriteLine("Account Number " + " " + transaction.AccountNumber);
                    Console.WriteLine("Amount " + " " + transaction.Amount);
                    Console.WriteLine("TransactionType " + " " + transaction.TransactionType);
                    Console.WriteLine();
                }
            }
        }
    }
}
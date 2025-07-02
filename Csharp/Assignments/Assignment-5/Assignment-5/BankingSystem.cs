using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    Exception Handling :  
    Question-1:
    You have a class which has methods for transaction for a banking system. (created earlier)
    Define your own methods for deposit money, withdraw money and balance in the account.
    Write your own new application Exception class called InsuffientBalanceException.
	This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
    Identify and categorize all possible checked and unchecked exception.
*/

namespace Assignment_5
{
    public class InsuffientBalanceException:Exception
    {
        public InsuffientBalanceException(string message) : base(message) { }
    }
    class BankingSystem
    {
        int AccountNo;
        string CustomerName;
        string AccountType;
        char TransactionType;
        int Amount, Balance;
        //Constructor
        public BankingSystem(int AccountNo, string CustomerName, string AccountType)
        {
            this.AccountNo = AccountNo ;
            this.CustomerName = CustomerName ?? throw new ArgumentNullException(nameof(CustomerName));
            this.AccountType = AccountType ?? throw new ArgumentNullException(nameof(AccountType));
            GetData();
        }
        public void GetData()
        {
                Console.WriteLine("Enter Transaction Type:(Either Deposit(D/d) or Withdrawal(W/w)");
                TransactionType = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.WriteLine("Enter Transaction Amount:");
                Amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Balance:");
                Balance = Convert.ToInt32(Console.ReadLine());

                if (TransactionType == 'D')
                {
                    Credit(Amount);
                }
                else if (TransactionType == 'W')
                {
                    Debit(Amount);
                }
                else
                {
                    Console.WriteLine("Invalid Transaction Type");
                }
            
        }
        public void Credit(int amount)
        {
            Balance += amount;
        }
        public void Debit(int amount)
        {
            if (amount <= Balance)
                Balance -= amount;
            else
                throw new InsuffientBalanceException("Insufficient funds for withdrawal.");
        }
        public void ShowData()
        {
            Console.WriteLine("--------The Account Details are:-------");
            Console.WriteLine("AccountNo: " + AccountNo);
            Console.WriteLine("CustomerName: " + CustomerName);
            Console.WriteLine("AccountType: " + AccountType);
            Console.WriteLine("TransactionType: " + TransactionType);
            Console.WriteLine("TransactionAmount: " + Amount);
            Console.WriteLine("Updated Balance:" + Balance);
        }
        static void Main(string[] args)
        {
            try
            {
                int accno;
                Console.WriteLine("Enter Account No:");
                accno = Convert.ToInt32(Console.ReadLine());
                string name;
                Console.WriteLine("Enter Customer Name:");
                name = Console.ReadLine();
                string type;
                Console.WriteLine("Enter Account Type:");
                type = Console.ReadLine();
                BankingSystem bs = new BankingSystem(accno, name, type);
                bs.ShowData();
            }
            catch (InsuffientBalanceException ex)
            {
                Console.WriteLine($"Transaction Failed: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input was not in the correct format. Please enter valid numbers and characters.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value is too large. Please enter a smaller number.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Missing input: {ex.ParamName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }



            Console.Read();

        }
    }
}

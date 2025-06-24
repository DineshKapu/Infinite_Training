using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Accounts
    {
        int AccountNo;
        string CustomerName;
        string AccountType;
        char TransactionType;
        int Amount, Balance;
        //Constructor
        public Accounts(int AccountNo,string CustomerName, string AccountType)
        {
            this.AccountNo = AccountNo;
            this.CustomerName = CustomerName;
            this.AccountType = AccountType;
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
                Console.WriteLine("Don't have enough balance to withdrawl the Money");
        }
        public void ShowData()
        {
            Console.WriteLine("--------The Account Details are:-------");
            Console.WriteLine("AccountNo: "+AccountNo);
            Console.WriteLine("CustomerName: "+CustomerName);
            Console.WriteLine("AccountType: "+AccountType);
            Console.WriteLine("TransactionType: "+TransactionType);
            Console.WriteLine("TransactionAmount: "+Amount);
            Console.WriteLine("Updated Balance:"+ Balance);
        }
        static void Main(string[] args)
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
            Accounts acc = new Accounts(accno,name,type);
            acc.ShowData();
            /*Console.WriteLine("-------------------");
            Accounts acc1 = new Accounts(10178453, "Dinesh", "Salary");
            acc.GetData();
            acc1.ShowData();*/
   
            Console.Read();


        }
    }
}

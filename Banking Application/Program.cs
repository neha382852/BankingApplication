using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class Program
    {

        public static int searchAccountId(Account[] accountobject)
        {
            Console.WriteLine("Enter Account Number :- ");
            int accountNumber = int.Parse(Console.ReadLine());
            for (int index = 0; index < accountobject.Length; index++)
            {
                if (accountNumber == accountobject[index].displayAccountId())
                {
                    return index;
                }
            }
            return 0;
        }
        public static void withdrawl(Account[] obj)
        {
            int index = searchAccountId(obj);
            Console.WriteLine("Enter Amount To Be Withdrawn from the account");
            int withdrawlAmount = int.Parse(Console.ReadLine());
            if (obj[index].displayAccountType().Equals("Saving") && obj[index].displayTotalAmount() < 1000)
            {
                    Console.WriteLine("Insufficient balance ");
                    Console.WriteLine();

            }
                else if (obj[index].displayAccountType().Equals("Current") && obj[index].displayTotalAmount() < 0)
                {
                    Console.WriteLine("Insufficient balance ");
                    Console.WriteLine();
            }
                else if (obj[index].displayAccountType().Equals("DMAT") && obj[index].displayTotalAmount() < -10000)
                {
                    Console.WriteLine("Balance Must Be Greater Than -10000.You cannot withdraw");
                    Console.WriteLine();
            }
                else
                {
                    Console.WriteLine("Your balance before withdrawl");
                    Console.WriteLine(accountobject[index].displayTotalAmount());
                    obj[index].SetWithdrawAmount(obj[index].displayTotalAmount() - withdrawlAmount);
                    Console.WriteLine("Your balance after withdrawl");
                    Console.WriteLine(accountobject[index].displayTotalAmount());
                    Console.WriteLine();


            }
         }
        

        public static void Interest(Account[] obj)
        {
            int index = searchAccountId(obj);
            int principalAmount = obj[index].displayTotalAmount();
            float simpleInterest = 0.0f;
            if (obj[index].displayAccountType().Equals("Saving"))
            { 
                simpleInterest = (float)((obj[index].displayTotalAmount() * 4) / 100);
                Console.WriteLine("Your Total Balance Before Interest " + obj[index].displayTotalAmount());
                Console.WriteLine("Interest " + simpleInterest);
                Console.WriteLine("Your Total Balance After Interest " + (obj[index].displayTotalAmount() + simpleInterest));
                Console.WriteLine();
            }
           
             else if (obj[index].displayAccountType().Equals("Current") )
            {
                simpleInterest = (float)((obj[index].displayTotalAmount() * 1) / 100);
                Console.WriteLine("Your Total Balance Before Interest " + obj[index].displayTotalAmount());
                Console.WriteLine("Interest " + simpleInterest);
                Console.WriteLine("Your Total Balance After Interest " + (obj[index].displayTotalAmount() + simpleInterest));
                Console.WriteLine();
            }
          
            else if(obj[index].displayAccountType().Equals("DMAT"))
            {
                Console.WriteLine("Interest is non applicable on DMAT's Account");
                Console.WriteLine();
            }
        }
        public static void checkAccountDetails(Account[] obj)
        {
            int index = searchAccountId(obj);
            Console.WriteLine("Account Id: " + obj[index].displayAccountId());
            Console.WriteLine("Customer Name: " + obj[index].displayCustomerName());
            Console.WriteLine("Account Type: " + obj[index].displayAccountType());
            Console.WriteLine("Available Balance: " + obj[index].displayTotalAmount());
            Console.WriteLine();
        }
        static Account[] accountobject;
        static void Main(string[] args)
        {
            
            int accountId, depositAmount;
            string customerName, accountType;
          
          
             Console.WriteLine("Enter Number of Records to be Added");
            int noofrecords = int.Parse(Console.ReadLine());
            accountobject = new Account[noofrecords];
            for (int index = 0; index < noofrecords; index++)
            {
                Console.WriteLine("Enter {0} Account Id",index+1);
                accountId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter {0} Customer Name",index+1);
                customerName = Console.ReadLine();
                Console.WriteLine("Enter Account Type:-\n Saving\n Current\n DMAT");
                accountType = Console.ReadLine();
                Console.WriteLine();
                accountobject[index] = new Account();  //default constructor is called.
                accountobject[index].inputAccountId(accountId);  //value parameters passed
                accountobject[index].inputCustomerName(customerName);
                accountobject[index].inputAccountType(accountType);
           

            }
            int flag = 1;
            do
            {
                Console.Write("Enter \n 1. To check Account Details\n 2. Search by Account ID \n 3. To deposit money\n 4. To withdraw money\n 5. To Calulate Interest on an account \n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        checkAccountDetails(accountobject); //Reference parameter passed
                        break;
                    case 2:
                        int accountNumber = searchAccountId(accountobject);
                        Console.WriteLine("Account Id:" + accountobject[accountNumber].displayAccountId());
                        Console.WriteLine("Customer Name:" + accountobject[accountNumber].displayCustomerName());
                        Console.WriteLine("Account Type:" + accountobject[accountNumber].displayAccountType());
                        Console.WriteLine("Available Balance:" + accountobject[accountNumber].displayTotalAmount());
                        break;
                    case 3:
                        int index = searchAccountId(accountobject);
                        Console.WriteLine("Enter Deposit");
                        depositAmount = int.Parse(Console.ReadLine());
                        accountobject[index].inputTotalAmount(depositAmount);
                        Console.WriteLine("Your balance after depositing");
                        Console.WriteLine(accountobject[index].displayTotalAmount());
                        break;
                    case 4:
                        withdrawl(accountobject);
                        break;
                    case 5:
                        Interest(accountobject);
                        break;
                    default:
                        Console.WriteLine("Invalid Entry!");
                        break;

                }
                Console.WriteLine("Enter 1 to Continue and 0 To Stop :- ");
                Console.WriteLine();
                flag = int.Parse(Console.ReadLine());
            }
            while (flag == 1);
            Console.ReadKey();
        }
    }
}
